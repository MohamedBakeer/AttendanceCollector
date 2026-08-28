using AttendanceCollector.Cls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceCollector.Helper
{
    public static class N8nHelper
    {
        // =====================================================
        // HttpClient واحد طوال عمر البرنامج
        // =====================================================

        private static readonly HttpClient httpClient =
            new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(20)
            };

        // =====================================================
        // إرسال جميع السجلات المعلقة على دفعات
        // =====================================================

        public static async Task<int> SendPendingAsync()
        {
            // -------------------------------------------------
            // هل n8n مفعّل؟
            // -------------------------------------------------

            string enabled =
                Database.GetSetting(
                    "n8n_enabled",
                    "0"
                );

            if (enabled != "1")
            {
                return 0;
            }

            // -------------------------------------------------
            // Webhook URL
            // -------------------------------------------------

            string webhookUrl =
                Database.GetSetting(
                    "n8n_webhook_url",
                    ""
                );

            if (string.IsNullOrWhiteSpace(webhookUrl))
            {
                return 0;
            }

            // -------------------------------------------------
            // التحقق من الرابط
            // -------------------------------------------------

            Uri webhookUri;

            if (!Uri.TryCreate(
                webhookUrl,
                UriKind.Absolute,
                out webhookUri))
            {
                return 0;
            }

            // -------------------------------------------------
            // Batch Size
            // -------------------------------------------------

            int batchSize = 50;

            int parsedBatchSize;

            if (int.TryParse(
                Database.GetSetting(
                    "n8n_batch_size",
                    "50"
                ),
                out parsedBatchSize))
            {
                batchSize =
                    parsedBatchSize;
            }

            if (batchSize < 1)
            {
                batchSize = 1;
            }

            if (batchSize > 500)
            {
                batchSize = 500;
            }

            // -------------------------------------------------
            // Pending Queue
            // -------------------------------------------------

            DataTable pending =
                Database.GetPendingQueue();

            if (pending == null ||
                pending.Rows.Count == 0)
            {
                return 0;
            }

            int totalSent = 0;

            // =================================================
            // تقسيم السجلات إلى Batches
            // =================================================

            for (
                int startIndex = 0;
                startIndex < pending.Rows.Count;
                startIndex += batchSize
            )
            {
                List<long> queueIds =
                    new List<long>();

                List<string> payloads =
                    new List<string>();

                int endIndex =
                    Math.Min(
                        startIndex + batchSize,
                        pending.Rows.Count
                    );

                // ---------------------------------------------
                // تجهيز Batch
                // ---------------------------------------------

                for (
                    int i = startIndex;
                    i < endIndex;
                    i++
                )
                {
                    DataRow row =
                        pending.Rows[i];

                    long queueId =
                        Convert.ToInt64(
                            row["id"]
                        );

                    string payload =
                        row["payload"] == DBNull.Value
                            ? ""
                            : row["payload"]
                                .ToString()
                                .Trim();

                    if (string.IsNullOrWhiteSpace(payload))
                    {
                        continue;
                    }

                    queueIds.Add(
                        queueId
                    );

                    payloads.Add(
                        payload
                    );
                }

                if (payloads.Count == 0)
                {
                    continue;
                }

                // ---------------------------------------------
                // إنشاء JSON النهائي للـBatch
                // ---------------------------------------------

                string batchPayload =
                    BuildBatchPayload(
                        payloads
                    );

                try
                {
                    HttpSendResult sendResult =
                        await SendPayloadAsync(
                            webhookUri.ToString(),
                            batchPayload
                        );

                    // =========================================
                    // Success
                    // =========================================

                    if (sendResult.Success)
                    {
                        foreach (long queueId in queueIds)
                        {
                            Database.MarkQueueSent(
                                queueId
                            );

                            totalSent++;
                        }
                    }

                    // =========================================
                    // Failure
                    // =========================================

                    else
                    {
                        string error =
                            "HTTP " +
                            sendResult.StatusCode +
                            " - " +
                            sendResult.ResponseText;

                        foreach (long queueId in queueIds)
                        {
                            Database.MarkQueueFailed(
                                queueId,
                                error
                            );
                        }
                    }
                }
                catch (Exception ex)
                {
                    // -----------------------------------------
                    // Internet / timeout / n8n unavailable
                    // -----------------------------------------

                    foreach (long queueId in queueIds)
                    {
                        Database.MarkQueueFailed(
                            queueId,
                            ex.Message
                        );
                    }
                }
            }

            return totalSent;
        }

        // =====================================================
        // إنشاء Batch JSON
        // =====================================================

        private static string BuildBatchPayload(
    List<string> payloads)
        {
            string collectorCode =
                Database.GetSetting(
                    "collector_code",
                    "COL-MAIN-01"
                );

            string batchId =
                collectorCode +
                "-" +
                DateTime.Now.ToString(
                    "yyyyMMdd-HHmmss"
                ) +
                "-" +
                Guid.NewGuid()
                    .ToString("N")
                    .Substring(0, 8);

            string sentAt =
                DateTimeOffset.Now
                    .ToString(
                        "yyyy-MM-ddTHH:mm:sszzz"
                    );

            StringBuilder json =
                new StringBuilder();

            json.Append("{");

            json.Append(
                "\"source\":\"AttendanceCollector\","
            );

            json.Append(
                "\"type\":\"attendance_batch\","
            );

            json.Append(
                "\"batch_id\":\"" +
                EscapeJson(batchId) +
                "\","
            );

            json.Append(
                "\"collector_code\":\"" +
                EscapeJson(collectorCode) +
                "\","
            );

            json.Append(
                "\"sent_at\":\"" +
                EscapeJson(sentAt) +
                "\","
            );

            json.Append(
                "\"count\":" +
                payloads.Count +
                ","
            );

            json.Append(
                "\"records\":["
            );

            for (int i = 0;
                 i < payloads.Count;
                 i++)
            {
                if (i > 0)
                {
                    json.Append(",");
                }

                json.Append(
                    payloads[i]
                );
            }

            json.Append("]");

            json.Append("}");

            return json.ToString();
        }
        // =====================================================
        // HTTP POST
        // =====================================================

        private static async Task<HttpSendResult> SendPayloadAsync(
            string url,
            string payload)
        {
            using (StringContent content =
                   new StringContent(
                       payload,
                       Encoding.UTF8,
                       "application/json"
                   ))
            {
                HttpResponseMessage response =
                    await httpClient.PostAsync(
                        url,
                        content
                    );

                string responseText =
                    "";

                try
                {
                    responseText =
                        await response.Content
                            .ReadAsStringAsync();
                }
                catch
                {
                    responseText =
                        "";
                }

                return new HttpSendResult
                {
                    Success =
                        response.IsSuccessStatusCode,

                    StatusCode =
                        (int)response.StatusCode,

                    ResponseText =
                        LimitText(
                            responseText,
                            1000
                        )
                };
            }
        }

        // =====================================================
        // اختبار Webhook من شاشة الإعدادات
        // =====================================================

        public static async Task<HttpSendResult> TestConnectionAsync()
        {
            string webhookUrl =
                Database.GetSetting(
                    "n8n_webhook_url",
                    ""
                );

            if (string.IsNullOrWhiteSpace(webhookUrl))
            {
                return new HttpSendResult
                {
                    Success = false,
                    StatusCode = 0,
                    ResponseText =
                        "Webhook URL غير موجود."
                };
            }

            Uri webhookUri;

            if (!Uri.TryCreate(
                webhookUrl,
                UriKind.Absolute,
                out webhookUri))
            {
                return new HttpSendResult
                {
                    Success = false,
                    StatusCode = 0,
                    ResponseText =
                        "Webhook URL غير صحيح."
                };
            }

            string payload =
                "{"
                +
                "\"source\":\"AttendanceCollector\","
                +
                "\"type\":\"connection_test\","
                +
                "\"sent_at\":\""
                +
                DateTime.Now.ToString(
                    "yyyy-MM-dd HH:mm:ss"
                )
                +
                "\""
                +
                "}";

            try
            {
                return await SendPayloadAsync(
                    webhookUri.ToString(),
                    payload
                );
            }
            catch (Exception ex)
            {
                return new HttpSendResult
                {
                    Success = false,
                    StatusCode = 0,
                    ResponseText =
                        ex.Message
                };
            }
        }

        // =====================================================
        // اختصار النصوص الطويلة
        // =====================================================

        private static string LimitText(
            string value,
            int maxLength)
        {
            if (string.IsNullOrEmpty(value))
            {
                return "";
            }

            if (value.Length <= maxLength)
            {
                return value;
            }

            return value.Substring(
                0,
                maxLength
            );
        }

        public static string GetSamplePayload(
    int maxRecords = 3)
        {
            if (maxRecords < 1)
                maxRecords = 1;

            if (maxRecords > 3)
                maxRecords = 3;

            DataTable sample =
                Database.GetLatestAttendanceSample(
                    maxRecords
                );

            if (sample == null ||
                sample.Rows.Count == 0)
            {
                return "";
            }

            List<string> payloads =
                new List<string>();

            foreach (DataRow row in sample.Rows)
            {
                string employeeId =
                    row["fingerprint_id"]
                    .ToString();

                string deviceCode =
    row["device_code"]
    .ToString();

                string deviceName =
                    row["device_name"]
                    .ToString();

                string connectionType =
                    row["connection_type"]
                    .ToString();


                int verifyMode = 0;

                if (row["verify_mode"] != DBNull.Value)
                {
                    verifyMode =
                        Convert.ToInt32(
                            row["verify_mode"]
                        );
                }

                DateTime punchDateTime =
    Convert.ToDateTime(
        row["punch_time"]
    );

                DateTime unspecified =
                    DateTime.SpecifyKind(
                        punchDateTime,
                        DateTimeKind.Unspecified
                    );

                DateTimeOffset punchOffset =
                    new DateTimeOffset(
                        unspecified,
                        TimeSpan.FromHours(2)
                    );

                string punchTime =
                    punchOffset.ToString(
                        "yyyy-MM-ddTHH:mm:sszzz"
                    );

                string payload =
                    "{"
                    +
                    "\"employee_id\":\"" +
                    EscapeJson(employeeId) +
                    "\","
                    +
                    "\"device_code\":\"" +
                    EscapeJson(deviceCode) +
                    "\","
                    +
                    "\"device_name\":\"" +
                    EscapeJson(deviceName) +
                    "\","
                    +
                    "\"connection_type\":\"" +
                    EscapeJson(connectionType) +
                    "\","
                    +
                    "\"punch_time\":\"" +
                    EscapeJson(punchTime) +
                    "\","
                    +
                    "\"verify_mode\":" +
                    verifyMode +
                    ","
                    +
                    "\"in_out_mode\":0,"
                    +
                    "\"work_code\":0"
                    +
                    "}";

                payloads.Add(
                    payload
                );
            }

            return BuildBatchPayload(
                payloads
            );
        }

        private static string EscapeJson(
    string value)
        {
            if (string.IsNullOrEmpty(value))
                return "";

            return value
                .Replace("\\", "\\\\")
                .Replace("\"", "\\\"");
        }

    }

    // =========================================================
    // نتيجة HTTP
    // =========================================================

    public class HttpSendResult
    {
        public bool Success { get; set; }

        public int StatusCode { get; set; }

        public string ResponseText { get; set; }
    }
}