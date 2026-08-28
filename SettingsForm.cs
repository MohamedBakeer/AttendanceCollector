using AttendanceCollector.Cls;
using AttendanceCollector.Helper;
using Microsoft.Win32;
using System;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AttendanceCollector
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        // =====================================================
        // Load
        // =====================================================

        private void SettingsForm_Load(
            object sender,
            EventArgs e)
        {
            LoadSettings();
        }

        // =====================================================
        // Load Settings
        // =====================================================

        private void LoadSettings()
        {
            // =================================================
            // Automatic Sync
            // =================================================

            chkAutoSync.Checked =
                Database.GetSetting(
                    "auto_sync_enabled",
                    "1"
                ) == "1";

            int minutes = 5;

            int.TryParse(
                Database.GetSetting(
                    "auto_sync_minutes",
                    "5"
                ),
                out minutes
            );

            if (minutes < 1)
            {
                minutes = 1;
            }

            if (minutes > 1440)
            {
                minutes = 1440;
            }

            numAutoSyncMinutes.Value =
                minutes;

            // =================================================
            // n8n
            // =================================================

            chkN8nEnabled.Checked =
                Database.GetSetting(
                    "n8n_enabled",
                    "0"
                ) == "1";

            txtWebhookUrl.Text =
                Database.GetSetting(
                    "n8n_webhook_url",
                    ""
                );

            // =================================================
            // Collector
            // =================================================

            string collectorCode =
                Database.GetSetting(
                    "collector_code",
                    "COL-MAIN-01"
                );

            if (string.IsNullOrWhiteSpace(
                collectorCode))
            {
                Database.SetSetting(
                    "collector_code",
                    "COL-MAIN-01"
                );
            }

            // =================================================
            // Program
            // =================================================

            chkStartWithWindows.Checked =
                Database.GetSetting(
                    "start_with_windows",
                    "0"
                ) == "1";

            chkStartMinimized.Checked =
                Database.GetSetting(
                    "start_minimized",
                    "0"
                ) == "1";

            chkRunInBackground.Checked =
                Database.GetSetting(
                    "run_in_background",
                    "1"
                ) == "1";

            // =================================================
            // Refresh controls
            // =================================================

            UpdateAutoSyncControls();
            UpdateN8nControls();
            UpdateBackgroundControls();
        }

        // =====================================================
        // Auto Sync
        // =====================================================

        private void chkAutoSync_CheckedChanged(
            object sender,
            EventArgs e)
        {
            UpdateAutoSyncControls();
        }

        private void UpdateAutoSyncControls()
        {
            numAutoSyncMinutes.Enabled =
                chkAutoSync.Checked;

            lblAutoSyncMinutes.Enabled =
                chkAutoSync.Checked;

            lblMinutes.Enabled =
                chkAutoSync.Checked;
        }

        // =====================================================
        // n8n
        // =====================================================

        private void chkN8nEnabled_CheckedChanged(
            object sender,
            EventArgs e)
        {
            UpdateN8nControls();
        }

        private void UpdateN8nControls()
        {
            txtWebhookUrl.Enabled =
                chkN8nEnabled.Checked;

            btnTestN8n.Enabled =
                chkN8nEnabled.Checked;
        }

        // =====================================================
        // Run In Background
        // =====================================================

        private void chkRunInBackground_CheckedChanged(
            object sender,
            EventArgs e)
        {
            UpdateBackgroundControls();
        }

        private void UpdateBackgroundControls()
        {
            chkStartMinimized.Enabled =
                chkRunInBackground.Checked;

            if (!chkRunInBackground.Checked)
            {
                chkStartMinimized.Checked =
                    false;
            }
        }

        // =====================================================
        // Test n8n
        // =====================================================

        private async void btnTestN8n_Click(
            object sender,
            EventArgs e)
        {
            string url =
                txtWebhookUrl.Text.Trim();

            if (string.IsNullOrWhiteSpace(url))
            {
                MessageBox.Show(
                    "أدخل Webhook URL أولاً.",
                    "n8n",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtWebhookUrl.Focus();

                return;
            }

            Uri uri;

            if (!Uri.TryCreate(
                url,
                UriKind.Absolute,
                out uri))
            {
                MessageBox.Show(
                    "رابط Webhook غير صحيح.",
                    "n8n",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtWebhookUrl.Focus();

                return;
            }

            btnTestN8n.Enabled =
                false;

            btnTestN8n.Text =
                "جاري الاختبار...";

            lblN8nTestStatus.Text =
                "جاري محاولة الاتصال...";

            lblN8nTestStatus.ForeColor =
                Color.DarkOrange;

            try
            {
                bool result =
                    await TestN8nAsync(
                        uri.ToString()
                    );

                if (result)
                {
                    lblN8nTestStatus.Text =
                        "تم الاتصال بـ n8n بنجاح";

                    lblN8nTestStatus.ForeColor =
                        Color.Green;
                }
                else
                {
                    lblN8nTestStatus.Text =
                        "n8n لم يقبل طلب الاختبار";

                    lblN8nTestStatus.ForeColor =
                        Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblN8nTestStatus.Text =
                    "فشل الاتصال: " +
                    ex.Message;

                lblN8nTestStatus.ForeColor =
                    Color.Red;
            }
            finally
            {
                btnTestN8n.Enabled =
                    chkN8nEnabled.Checked;

                btnTestN8n.Text =
                    "اختبار الاتصال";
            }
        }

        // =====================================================
        // Test n8n HTTP
        // =====================================================

        private async Task<bool> TestN8nAsync(
            string url)
        {
            using (HttpClient client =
                   new HttpClient())
            {
                client.Timeout =
                    TimeSpan.FromSeconds(10);

                string collectorCode =
                    Database.GetSetting(
                        "collector_code",
                        "COL-MAIN-01"
                    );

                string sentAt =
                    DateTimeOffset.Now.ToString(
                        "yyyy-MM-ddTHH:mm:sszzz"
                    );

                string json =
                    "{"
                    +
                    "\"source\":\"AttendanceCollector\","
                    +
                    "\"type\":\"collector_test\","
                    +
                    "\"collector_code\":\""
                    +
                    EscapeJson(
                        collectorCode
                    )
                    +
                    "\","
                    +
                    "\"sent_at\":\""
                    +
                    EscapeJson(
                        sentAt
                    )
                    +
                    "\""
                    +
                    "}";

                using (StringContent content =
                       new StringContent(
                           json,
                           Encoding.UTF8,
                           "application/json"
                       ))
                {
                    HttpResponseMessage response =
                        await client.PostAsync(
                            url,
                            content
                        );

                    return
                        response.IsSuccessStatusCode;
                }
            }
        }

        // =====================================================
        // Save
        // =====================================================

        private void btnSave_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                string webhookUrl =
                    txtWebhookUrl.Text.Trim();

                // =================================================
                // Validate n8n
                // =================================================

                if (
                    chkN8nEnabled.Checked &&
                    string.IsNullOrWhiteSpace(
                        webhookUrl
                    )
                )
                {
                    MessageBox.Show(
                        "مزامنة n8n مفعلة، لذلك يجب إدخال Webhook URL.",
                        "تنبيه",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    txtWebhookUrl.Focus();

                    return;
                }

                if (
                    chkN8nEnabled.Checked &&
                    !Uri.TryCreate(
                        webhookUrl,
                        UriKind.Absolute,
                        out _
                    )
                )
                {
                    MessageBox.Show(
                        "Webhook URL غير صحيح.",
                        "تنبيه",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    txtWebhookUrl.Focus();

                    return;
                }

                // =================================================
                // Auto Sync
                // =================================================

                Database.SetSetting(
                    "auto_sync_enabled",
                    chkAutoSync.Checked
                        ? "1"
                        : "0"
                );

                Database.SetSetting(
                    "auto_sync_minutes",
                    numAutoSyncMinutes.Value
                        .ToString()
                );

                // =================================================
                // n8n
                // =================================================

                Database.SetSetting(
                    "n8n_enabled",
                    chkN8nEnabled.Checked
                        ? "1"
                        : "0"
                );

                Database.SetSetting(
                    "n8n_webhook_url",
                    webhookUrl
                );

                // =================================================
                // Collector
                // =================================================

                string collectorCode =
                    Database.GetSetting(
                        "collector_code",
                        "COL-MAIN-01"
                    );

                if (string.IsNullOrWhiteSpace(
                    collectorCode))
                {
                    Database.SetSetting(
                        "collector_code",
                        "COL-MAIN-01"
                    );
                }

                // =================================================
                // Program
                // =================================================

                Database.SetSetting(
                    "start_with_windows",
                    chkStartWithWindows.Checked
                        ? "1"
                        : "0"
                );

                Database.SetSetting(
                    "start_minimized",
                    chkStartMinimized.Checked
                        ? "1"
                        : "0"
                );

                Database.SetSetting(
                    "run_in_background",
                    chkRunInBackground.Checked
                        ? "1"
                        : "0"
                );

                // =================================================
                // Windows Startup
                // =================================================

                ApplyWindowsStartup(
                    chkStartWithWindows.Checked
                );

                // =================================================
                // Success
                // =================================================

                MessageBox.Show(
                    "تم حفظ الإعدادات بنجاح.",
                    "الإعدادات",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                DialogResult =
                    DialogResult.OK;

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "حدث خطأ أثناء حفظ الإعدادات:\n\n" +
                    ex.Message,
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // =====================================================
        // Windows Startup
        // =====================================================

        private void ApplyWindowsStartup(
            bool enabled)
        {
            const string appName =
                "AttendanceCollector";

            string exePath =
                Application.ExecutablePath;

            using (RegistryKey key =
                   Registry.CurrentUser.OpenSubKey(
                       @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run",
                       true
                   ))
            {
                if (key == null)
                {
                    return;
                }

                if (enabled)
                {
                    key.SetValue(
                        appName,
                        "\"" +
                        exePath +
                        "\""
                    );
                }
                else
                {
                    if (
                        key.GetValue(
                            appName
                        ) != null
                    )
                    {
                        key.DeleteValue(
                            appName,
                            false
                        );
                    }
                }
            }
        }

        // =====================================================
        // Close
        // =====================================================

        private void btnCancel_Click(
            object sender,
            EventArgs e)
        {
            Close();
        }

        private void btnClose_Click(
            object sender,
            EventArgs e)
        {
            Close();
        }

        // =====================================================
        // Preview Sample
        // =====================================================

        private void btnPreviewSample_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                string sample =
                    N8nHelper.GetSamplePayload(
                        3
                    );

                if (string.IsNullOrWhiteSpace(
                    sample))
                {
                    MessageBox.Show(
                        "لا توجد سجلات حضور محفوظة لعرض عينة منها.",
                        "معاينة الإرسال",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    return;
                }

                ShowPayloadPreview(
                    sample
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "حدث خطأ أثناء تجهيز العينة:\n\n" +
                    ex.Message,
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // =====================================================
        // Payload Preview Form
        // =====================================================

        private void ShowPayloadPreview(
            string payload)
        {
            Form preview =
                new Form();

            preview.Text =
                "معاينة البيانات المرسلة إلى n8n";

            preview.StartPosition =
                FormStartPosition.CenterParent;

            preview.Size =
                new Size(
                    820,
                    650
                );

            preview.MinimumSize =
                new Size(
                    700,
                    550
                );

            preview.BackColor =
                Color.FromArgb(
                    244,
                    247,
                    245
                );

            preview.Font =
                new Font(
                    "Cairo",
                    8.25F
                );

            preview.RightToLeft =
                RightToLeft.Yes;

            preview.RightToLeftLayout =
                true;

            // =================================================
            // Header
            // =================================================

            Panel header =
                new Panel();

            header.Dock =
                DockStyle.Top;

            header.Height =
                80;

            header.BackColor =
                Color.FromArgb(
                    23,
                    95,
                    62
                );

            Label title =
                new Label();

            title.Dock =
                DockStyle.Top;

            title.Height =
                42;

            title.Font =
                new Font(
                    "Cairo",
                    14F,
                    FontStyle.Bold
                );

            title.ForeColor =
                Color.White;

            title.TextAlign =
                ContentAlignment.MiddleCenter;

            title.Text =
                "معاينة Webhook Payload";

            Label description =
                new Label();

            description.Dock =
                DockStyle.Fill;

            description.ForeColor =
                Color.FromArgb(
                    218,
                    235,
                    226
                );

            description.TextAlign =
                ContentAlignment.MiddleCenter;

            description.Text =
                "آخر 3 سجلات كحد أقصى - لن يتم إرسال أي بيانات";

            header.Controls.Add(
                description
            );

            header.Controls.Add(
                title
            );

            // =================================================
            // JSON
            // =================================================

            TextBox txtJson =
                new TextBox();

            txtJson.Dock =
                DockStyle.Fill;

            txtJson.Multiline =
                true;

            txtJson.ScrollBars =
                ScrollBars.Both;

            txtJson.ReadOnly =
                true;

            txtJson.WordWrap =
                false;

            txtJson.RightToLeft =
                RightToLeft.No;

            txtJson.Font =
                new Font(
                    "Consolas",
                    10F
                );

            txtJson.BackColor =
                Color.White;

            txtJson.Text =
                FormatJsonForPreview(
                    payload
                );

            // =================================================
            // Footer
            // =================================================

            Panel footer =
                new Panel();

            footer.Dock =
                DockStyle.Bottom;

            footer.Height =
                65;

            footer.BackColor =
                Color.White;

            Button btnCopy =
                new Button();

            btnCopy.Text =
                "نسخ JSON";

            btnCopy.Size =
                new Size(
                    160,
                    38
                );

            btnCopy.Location =
                new Point(
                    620,
                    13
                );

            btnCopy.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Right;

            btnCopy.BackColor =
                Color.FromArgb(
                    23,
                    95,
                    62
                );

            btnCopy.ForeColor =
                Color.White;

            btnCopy.FlatStyle =
                FlatStyle.Flat;

            btnCopy.FlatAppearance.BorderSize =
                0;

            btnCopy.Click +=
                (s, e) =>
                {
                    Clipboard.SetText(
                        payload
                    );

                    MessageBox.Show(
                        "تم نسخ JSON.",
                        "معاينة الإرسال",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                };

            Button btnClosePreview =
                new Button();

            btnClosePreview.Text =
                "إغلاق";

            btnClosePreview.Size =
                new Size(
                    160,
                    38
                );

            btnClosePreview.Location =
                new Point(
                    440,
                    13
                );

            btnClosePreview.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Right;

            btnClosePreview.BackColor =
                Color.White;

            btnClosePreview.FlatStyle =
                FlatStyle.Flat;

            btnClosePreview.Click +=
                (s, e) =>
                {
                    preview.Close();
                };

            footer.Controls.Add(
                btnCopy
            );

            footer.Controls.Add(
                btnClosePreview
            );

            preview.Controls.Add(
                txtJson
            );

            preview.Controls.Add(
                footer
            );

            preview.Controls.Add(
                header
            );

            preview.ShowDialog(
                this
            );
        }

        // =====================================================
        // JSON Formatter
        // =====================================================

        private string FormatJsonForPreview(
            string json)
        {
            if (string.IsNullOrWhiteSpace(
                json))
            {
                return "";
            }

            StringBuilder result =
                new StringBuilder();

            bool insideString =
                false;

            bool escaped =
                false;

            int indent =
                0;

            foreach (char c in json)
            {
                if (escaped)
                {
                    result.Append(c);

                    escaped = false;

                    continue;
                }

                if (
                    c == '\\' &&
                    insideString
                )
                {
                    result.Append(c);

                    escaped = true;

                    continue;
                }

                if (c == '"')
                {
                    insideString =
                        !insideString;

                    result.Append(c);

                    continue;
                }

                if (insideString)
                {
                    result.Append(c);

                    continue;
                }

                switch (c)
                {
                    case '{':
                    case '[':

                        result.Append(c);
                        result.AppendLine();

                        indent++;

                        result.Append(
                            new string(
                                ' ',
                                indent * 4
                            )
                        );

                        break;

                    case '}':
                    case ']':

                        result.AppendLine();

                        indent--;

                        if (indent < 0)
                        {
                            indent = 0;
                        }

                        result.Append(
                            new string(
                                ' ',
                                indent * 4
                            )
                        );

                        result.Append(c);

                        break;

                    case ',':

                        result.Append(c);
                        result.AppendLine();

                        result.Append(
                            new string(
                                ' ',
                                indent * 4
                            )
                        );

                        break;

                    case ':':

                        result.Append(": ");

                        break;

                    default:

                        if (!char.IsWhiteSpace(c))
                        {
                            result.Append(c);
                        }

                        break;
                }
            }

            return result.ToString();
        }

        // =====================================================
        // JSON Escape
        // =====================================================

        private static string EscapeJson(
            string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return "";
            }

            return value
                .Replace("\\", "\\\\")
                .Replace("\"", "\\\"");
        }
    }
}