using AttendanceCollector.Cls;
using AttendanceCollector.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AttendanceCollector
{
    public partial class MainForm : Form
    {
        // =====================================================
        // Timers
        // =====================================================

        private System.Windows.Forms.Timer statusTimer;
        private System.Windows.Forms.Timer autoSyncTimer;
        private NotifyIcon trayIcon;

        // =====================================================
        // منع تشغيل سحبين في نفس الوقت
        // =====================================================

        private bool syncRunning = false;

        // =====================================================
        // Main Form
        // =====================================================

        public MainForm()
        {
            InitializeComponent();
            InitializeTrayIcon();

            this.Load += MainForm_Load;
        }

        // =====================================================
        // Form Load
        // =====================================================

        private async void MainForm_Load(
            object sender,
            EventArgs e)
        {
            try
            {
                Database.Initialize();

                EnsureDefaultSettings();

                PrepareGrid();

                PrepareProgressBar();

                InitializeStatusTimer();

                InitializeAutoSyncTimer();

                await RefreshDashboard();

                string startMinimized =
                    Database.GetSetting(
                        "start_minimized",
                        "0"
                    );

                if (startMinimized == "1")
                {
                    BeginInvoke(
                        new Action(
                            () =>
                            {
                                Hide();

                                ShowInTaskbar =
                                    false;
                            }
                        )
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "حدث خطأ أثناء تشغيل البرنامج:\n\n" +
                    ex.Message,
                    "Attendance Collector",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // =====================================================
        // Admin Password
        // =====================================================

        private bool RequireAdminPassword()
        {
            using (AdminPasswordForm passwordForm =
                   new AdminPasswordForm())
            {
                DialogResult result =
                    passwordForm.ShowDialog(this);

                return
                    result == DialogResult.OK &&
                    passwordForm.Authenticated;
            }
        }

        // =====================================================
        // Default Settings
        // =====================================================

        private void EnsureDefaultSettings()
        {
            // ---------------------------------------------
            // Admin Password
            // ---------------------------------------------

            string adminPasswordHash =
                Database.GetSetting(
                    "admin_password_hash",
                    ""
                );

            if (string.IsNullOrWhiteSpace(
                adminPasswordHash))
            {
                Database.SetSetting(
                    "admin_password_hash",
                    SecurityHelper.HashPassword(
                        "1234"
                    )
                );
            }

            // ---------------------------------------------
            // Collector Code
            // ---------------------------------------------

            string collectorCode =
                Database.GetSetting(
                    "collector_code",
                    ""
                );

            if (string.IsNullOrWhiteSpace(
                collectorCode))
            {
                Database.SetSetting(
                    "collector_code",
                    "COL-MAIN-01"
                );
            }

            // ---------------------------------------------
            // Auto Sync Enabled
            // ---------------------------------------------

            string enabled =
                Database.GetSetting(
                    "auto_sync_enabled",
                    ""
                );

            if (string.IsNullOrWhiteSpace(enabled))
            {
                Database.SetSetting(
                    "auto_sync_enabled",
                    "1"
                );
            }

            // ---------------------------------------------
            // Auto Sync Minutes
            // ---------------------------------------------

            string minutes =
                Database.GetSetting(
                    "auto_sync_minutes",
                    ""
                );

            if (string.IsNullOrWhiteSpace(minutes))
            {
                Database.SetSetting(
                    "auto_sync_minutes",
                    "5"
                );
            }

            // ---------------------------------------------
            // n8n Enabled
            // ---------------------------------------------

            string n8nEnabled =
                Database.GetSetting(
                    "n8n_enabled",
                    ""
                );

            if (string.IsNullOrWhiteSpace(
                n8nEnabled))
            {
                Database.SetSetting(
                    "n8n_enabled",
                    "0"
                );
            }

            // ---------------------------------------------
            // Run In Background
            // ---------------------------------------------

            string runInBackground =
                Database.GetSetting(
                    "run_in_background",
                    ""
                );

            if (string.IsNullOrWhiteSpace(
                runInBackground))
            {
                Database.SetSetting(
                    "run_in_background",
                    "1"
                );
            }

            // ---------------------------------------------
            // Start With Windows
            // ---------------------------------------------

            string startWithWindows =
                Database.GetSetting(
                    "start_with_windows",
                    ""
                );

            if (string.IsNullOrWhiteSpace(
                startWithWindows))
            {
                Database.SetSetting(
                    "start_with_windows",
                    "0"
                );
            }

            // ---------------------------------------------
            // Start Minimized
            // ---------------------------------------------

            string startMinimized =
                Database.GetSetting(
                    "start_minimized",
                    ""
                );

            if (string.IsNullOrWhiteSpace(
                startMinimized))
            {
                Database.SetSetting(
                    "start_minimized",
                    "0"
                );
            }
        }

        // =====================================================
        // Prepare Grid
        // =====================================================

        private void PrepareGrid()
        {
            dgvToday.AutoGenerateColumns =
                false;

            colFingerprintId.DataPropertyName =
                "fingerprint_id";

            // اسم الـControl ما زال colBranch في Designer
            // لكن البيانات أصبحت device_code
            colBranch.DataPropertyName =
                "device_code";

            colDevice.DataPropertyName =
                "device_name";

            colFirstPunch.DataPropertyName =
                "first_punch";

            colLastPunch.DataPropertyName =
                "last_punch";

            colPunchCount.DataPropertyName =
                "punch_count";

            // تغيير العنوان الظاهر فقط
            colBranch.HeaderText =
                "رمز الجهاز";
        }

        // =====================================================
        // Progress Bar
        // =====================================================

        private void PrepareProgressBar()
        {
            progressBar_PullStatus.Minimum =
                0;

            progressBar_PullStatus.Maximum =
                100;

            progressBar_PullStatus.Value =
                0;

            progressBar_PullStatus.Visible =
                false;
        }

        // =====================================================
        // Dashboard Timer
        // =====================================================

        private void InitializeStatusTimer()
        {
            if (statusTimer != null)
            {
                statusTimer.Stop();
                statusTimer.Dispose();
            }

            statusTimer =
                new System.Windows.Forms.Timer();

            statusTimer.Interval =
                30000;

            statusTimer.Tick +=
                async (s, e) =>
                {
                    if (!syncRunning)
                    {
                        await RefreshDashboard();
                    }
                };

            statusTimer.Start();
        }

        // =====================================================
        // Automatic Sync Timer
        // =====================================================

        private void InitializeAutoSyncTimer()
        {
            if (autoSyncTimer != null)
            {
                autoSyncTimer.Stop();
                autoSyncTimer.Dispose();

                autoSyncTimer =
                    null;
            }

            string enabled =
                Database.GetSetting(
                    "auto_sync_enabled",
                    "1"
                );

            if (enabled != "1")
            {
                return;
            }

            int minutes =
                5;

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

            autoSyncTimer =
                new System.Windows.Forms.Timer();

            autoSyncTimer.Interval =
                minutes * 60 * 1000;

            autoSyncTimer.Tick +=
                async (s, e) =>
                {
                    await RunAutomaticSyncAsync();
                };

            autoSyncTimer.Start();
        }

        // =====================================================
        // Automatic Sync
        // =====================================================

        private async Task RunAutomaticSyncAsync()
        {
            if (syncRunning)
            {
                return;
            }

            try
            {
                SetSyncStatus(
                    "مزامنة تلقائية: جاري سحب البيانات...",
                    true
                );

                PullResult result =
                    await PullAttendanceAsync(
                        automatic: true
                    );

                // ---------------------------------------------
                // إرسال Queue إلى n8n
                // ---------------------------------------------

                await N8nHelper.SendPendingAsync();

                await RefreshDashboard();

                if (result.FailedDevices == 0)
                {
                    SetSyncStatus(
                        "تمت المزامنة تلقائيًا - " +
                        DateTime.Now.ToString(
                            "HH:mm:ss"
                        ),
                        false
                    );
                }
                else
                {
                    SetSyncStatus(
                        "اكتملت المزامنة مع " +
                        result.FailedDevices +
                        " جهاز به مشكلة",
                        false
                    );
                }
            }
            catch
            {
                // لا MessageBox في الوضع التلقائي

                SetSyncStatus(
                    "تعذر إكمال المزامنة التلقائية",
                    false
                );
            }
        }

        // =====================================================
        // Pull Attendance Engine
        // =====================================================

        private async Task<PullResult>
            PullAttendanceAsync(
                bool automatic)
        {
            PullResult result =
                new PullResult();

            result.StartedAt =
                DateTime.Now;

            if (syncRunning)
            {
                return result;
            }

            syncRunning =
                true;

            try
            {
                DataTable devices =
                    Database.GetActiveDevices();

                result.TotalDevices =
                    devices.Rows.Count;

                if (devices.Rows.Count == 0)
                {
                    result.FinishedAt =
                        DateTime.Now;

                    return result;
                }

                // ---------------------------------------------
                // Progress
                // ---------------------------------------------

                progressBar_PullStatus.Visible =
                    true;

                progressBar_PullStatus.Minimum =
                    0;

                progressBar_PullStatus.Maximum =
                    devices.Rows.Count;

                progressBar_PullStatus.Value =
                    0;

                int deviceNumber =
                    0;

                // =============================================
                // Each Device
                // =============================================

                foreach (DataRow row in devices.Rows)
                {
                    deviceNumber++;

                    // -----------------------------------------
                    // Copy values before worker thread
                    // -----------------------------------------

                    int deviceId =
                        Convert.ToInt32(
                            row["id"]
                        );

                    string deviceName =
                        row["name"]
                        .ToString();

                    // =========================================
                    // الجديد: Device Code
                    // =========================================

                    string deviceCode =
                        row["device_code"]
                        .ToString();

                    string connectionType =
                        row["connection_type"]
                        .ToString();

                    string host =
                        row["host"]
                        .ToString();

                    int port =
                        Convert.ToInt32(
                            row["port"]
                        );

                    int password =
                        Convert.ToInt32(
                            row["password"]
                        );

                    // -----------------------------------------
                    // UI Status
                    // -----------------------------------------

                    SetSyncStatus(
                        "جاري سحب البيانات من " +
                        deviceName +
                        " - " +
                        deviceCode +
                        "  (" +
                        deviceNumber +
                        "/" +
                        devices.Rows.Count +
                        ")",
                        true
                    );

                    if (!automatic)
                    {
                        btnPullNow.Text =
                            "جاري السحب " +
                            deviceNumber +
                            "/" +
                            devices.Rows.Count;
                    }

                    // =========================================
                    // ZKTeco + SQLite in STA Thread
                    // =========================================

                    DevicePullResult deviceResult =
                        await RunStaAsync(
                            () =>
                            {
                                return PullOneDevice(
                                    deviceId,
                                    deviceName,
                                    deviceCode,
                                    connectionType,
                                    host,
                                    port,
                                    password
                                );
                            }
                        );

                    // -----------------------------------------
                    // Aggregate
                    // -----------------------------------------

                    result.Devices.Add(
                        deviceResult
                    );

                    if (deviceResult.Connected)
                    {
                        result.ConnectedDevices++;
                    }
                    else
                    {
                        result.FailedDevices++;
                    }

                    result.TotalRead +=
                        deviceResult.ReadCount;

                    result.NewRecords +=
                        deviceResult.NewCount;

                    result.DuplicateRecords +=
                        deviceResult.DuplicateCount;

                    // -----------------------------------------
                    // Progress
                    // -----------------------------------------

                    if (
                        progressBar_PullStatus.Value <
                        progressBar_PullStatus.Maximum
                    )
                    {
                        progressBar_PullStatus.Value++;
                    }

                    LoadTodayStatistics();
                    LoadTodayGrid();
                }

                result.FinishedAt =
                    DateTime.Now;

                return result;
            }
            finally
            {
                syncRunning =
                    false;

                progressBar_PullStatus.Value =
                    0;

                progressBar_PullStatus.Visible =
                    false;
            }
        }

        // =====================================================
        // Pull One Device
        // =====================================================

        private DevicePullResult PullOneDevice(
            int deviceId,
            string deviceName,
            string deviceCode,
            string connectionType,
            string host,
            int port,
            int password)
        {
            DevicePullResult result =
                new DevicePullResult();

            result.DeviceName =
                deviceName;

            result.DeviceCode =
                deviceCode;

            result.ConnectionType =
                connectionType;

            result.Status =
                "جاري الاتصال";

            ZktecoHelper zk =
                null;

            try
            {
                zk =
                    new ZktecoHelper();

                // ---------------------------------------------
                // Connect
                // ---------------------------------------------

                bool connected =
                    zk.Connect(
                        host,
                        port,
                        password
                    );

                if (!connected)
                {
                    result.Connected =
                        false;

                    result.Status =
                        "فشل الاتصال";

                    result.ErrorCode =
                        zk.LastErrorCode;

                    result.Error =
                        "ZK Error: " +
                        zk.LastErrorCode;

                    return result;
                }

                result.Connected =
                    true;

                // ---------------------------------------------
                // Read Logs
                // ---------------------------------------------

                List<ZkAttendanceRecord> logs =
                    zk.GetAttendanceLogs();

                result.ReadCount =
                    logs.Count;

                // ---------------------------------------------
                // Save New Records Only
                // ---------------------------------------------

                foreach (
                    ZkAttendanceRecord log
                    in logs
                )
                {
                    bool inserted =
                        Database.AddAttendance(
                            deviceId,
                            log.FingerprintId,
                            log.PunchTime,
                            log.VerifyMode
                        );

                    if (inserted)
                    {
                        result.NewCount++;

                        // =====================================
                        // Payload الحقيقي الذي يدخل Queue
                        // =====================================

                        string payload =
                            "{"

                            + "\"employee_id\":\""
                            + EscapeJson(
                                log.FingerprintId
                            )
                            + "\","

                            + "\"device_code\":\""
                            + EscapeJson(
                                deviceCode
                            )
                            + "\","

                            + "\"device_name\":\""
                            + EscapeJson(
                                deviceName
                            )
                            + "\","

                            + "\"connection_type\":\""
                            + EscapeJson(
                                connectionType
                            )
                            + "\","

                            + "\"punch_time\":\""
                            + FormatLibyaDateTime(
                                log.PunchTime
                            )
                            + "\","

                            + "\"verify_mode\":"
                            + log.VerifyMode
                            + ","

                            + "\"in_out_mode\":"
                            + log.InOutMode
                            + ","

                            + "\"work_code\":"
                            + log.WorkCode

                            + "}";

                        Database.AddToQueue(
                            payload
                        );
                    }
                    else
                    {
                        result.DuplicateCount++;
                    }
                }

                result.Status =
                    "تم السحب";

                return result;
            }
            catch (Exception ex)
            {
                result.Connected =
                    false;

                result.Status =
                    "خطأ";

                result.Error =
                    ex.Message;

                return result;
            }
            finally
            {
                if (zk != null)
                {
                    try
                    {
                        zk.Disconnect();
                    }
                    catch
                    {
                    }
                }
            }
        }

        // =====================================================
        // Libya ISO DateTime
        // =====================================================

        private string FormatLibyaDateTime(
            DateTime value)
        {
            /*
             * أجهزة البصمة تعطي وقتًا محليًا.
             * ليبيا UTC+02 حاليًا.
             *
             * النتيجة:
             * 2026-08-28T08:02:14+02:00
             */

            DateTime unspecified =
                DateTime.SpecifyKind(
                    value,
                    DateTimeKind.Unspecified
                );

            DateTimeOffset offsetValue =
                new DateTimeOffset(
                    unspecified,
                    TimeSpan.FromHours(2)
                );

            return offsetValue.ToString(
                "yyyy-MM-ddTHH:mm:sszzz"
            );
        }

        // =====================================================
        // JSON Escape
        // =====================================================

        private string EscapeJson(
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

        // =====================================================
        // Run ZKTeco COM in STA Background Thread
        // =====================================================

        private Task<T> RunStaAsync<T>(
            Func<T> action)
        {
            TaskCompletionSource<T> tcs =
                new TaskCompletionSource<T>();

            Thread thread =
                new Thread(
                    () =>
                    {
                        try
                        {
                            T result =
                                action();

                            tcs.SetResult(
                                result
                            );
                        }
                        catch (Exception ex)
                        {
                            tcs.SetException(
                                ex
                            );
                        }
                    }
                );

            thread.IsBackground =
                true;

            thread.SetApartmentState(
                ApartmentState.STA
            );

            thread.Start();

            return tcs.Task;
        }

        // =====================================================
        // Sync Status UI
        // =====================================================

        private void SetSyncStatus(
            string text,
            bool working)
        {
            lblLastUpdate.Text =
                text;

            if (working)
            {
                lblLastUpdate.ForeColor =
                    Color.FromArgb(
                        255,
                        235,
                        160
                    );
            }
            else
            {
                lblLastUpdate.ForeColor =
                    Color.FromArgb(
                        218,
                        235,
                        226
                    );
            }
        }

        // =====================================================
        // Manual Pull
        // =====================================================

        private async void btnPullNow_Click(
            object sender,
            EventArgs e)
        {
            if (syncRunning)
            {
                MessageBox.Show(
                    "توجد عملية سحب أو مزامنة تعمل حاليًا.",
                    "سحب البيانات",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                return;
            }

            btnPullNow.Enabled =
                false;

            btnPullNow.Text =
                "جاري السحب...";

            try
            {
                PullResult result =
                    await PullAttendanceAsync(
                        automatic: false
                    );

                // ---------------------------------------------
                // إرسال Queue إلى n8n
                // ---------------------------------------------

                await N8nHelper.SendPendingAsync();

                await RefreshDashboard();

                ShowPullPreview(
                    result
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "حدث خطأ أثناء سحب البيانات:\n\n" +
                    ex.Message,
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                btnPullNow.Enabled =
                    true;

                btnPullNow.Text =
                    "سحب الآن";

                lblLastUpdate.Text =
                    "آخر تحديث: " +
                    DateTime.Now.ToString(
                        "yyyy-MM-dd HH:mm:ss"
                    );
            }
        }

        // =====================================================
        // Pull Preview
        // =====================================================

        private void ShowPullPreview(
            PullResult result)
        {
            Form preview =
                new Form();

            preview.Text =
                "نتيجة سحب البيانات";

            preview.StartPosition =
                FormStartPosition.CenterParent;

            preview.Size =
                new Size(
                    850,
                    500
                );

            preview.MinimumSize =
                new Size(
                    750,
                    450
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

            // ---------------------------------------------
            // Header
            // ---------------------------------------------

            Panel header =
                new Panel();

            header.Dock =
                DockStyle.Top;

            header.Height =
                90;

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
                "نتيجة سحب بيانات الحضور";

            Label summary =
                new Label();

            summary.Dock =
                DockStyle.Fill;

            summary.ForeColor =
                Color.White;

            summary.TextAlign =
                ContentAlignment.MiddleCenter;

            summary.Text =
                "الأجهزة: " +
                result.TotalDevices +

                "    |    متصل: " +
                result.ConnectedDevices +

                "    |    فشل: " +
                result.FailedDevices +

                "    |    المقروء: " +
                result.TotalRead +

                "    |    الجديد: " +
                result.NewRecords;

            header.Controls.Add(
                summary
            );

            header.Controls.Add(
                title
            );

            // ---------------------------------------------
            // Grid
            // ---------------------------------------------

            DataGridView grid =
                new DataGridView();

            grid.Dock =
                DockStyle.Fill;

            grid.ReadOnly =
                true;

            grid.AllowUserToAddRows =
                false;

            grid.AllowUserToDeleteRows =
                false;

            grid.AllowUserToResizeRows =
                false;

            grid.RowHeadersVisible =
                false;

            grid.MultiSelect =
                false;

            grid.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            grid.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            grid.BackgroundColor =
                Color.White;

            grid.BorderStyle =
                BorderStyle.None;

            grid.ColumnHeadersHeight =
                40;

            grid.EnableHeadersVisualStyles =
                false;

            grid.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(
                    23,
                    95,
                    62
                );

            grid.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            grid.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            grid.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            grid.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(
                    225,
                    239,
                    232
                );

            grid.DefaultCellStyle.SelectionForeColor =
                Color.FromArgb(
                    23,
                    95,
                    62
                );

            grid.Columns.Add(
                "Device",
                "الجهاز"
            );

            // =============================================
            // بدل رمز الفرع
            // =============================================

            grid.Columns.Add(
                "DeviceCode",
                "رمز الجهاز"
            );

            grid.Columns.Add(
                "Type",
                "الاتصال"
            );

            grid.Columns.Add(
                "Read",
                "المقروء"
            );

            grid.Columns.Add(
                "New",
                "الجديد"
            );

            grid.Columns.Add(
                "Duplicate",
                "موجود سابقًا"
            );

            grid.Columns.Add(
                "Status",
                "الحالة"
            );

            foreach (
                DevicePullResult device
                in result.Devices
            )
            {
                grid.Rows.Add(
                    device.DeviceName,
                    device.DeviceCode,
                    device.ConnectionType,
                    device.ReadCount,
                    device.NewCount,
                    device.DuplicateCount,
                    device.Status
                );
            }

            // ---------------------------------------------
            // Footer
            // ---------------------------------------------

            Panel footer =
                new Panel();

            footer.Dock =
                DockStyle.Bottom;

            footer.Height =
                60;

            footer.BackColor =
                Color.White;

            Button close =
                new Button();

            close.Text =
                "إغلاق";

            close.Size =
                new Size(
                    140,
                    38
                );

            close.Dock =
                DockStyle.Right;

            close.Margin =
                new Padding(10);

            close.BackColor =
                Color.FromArgb(
                    23,
                    95,
                    62
                );

            close.ForeColor =
                Color.White;

            close.FlatStyle =
                FlatStyle.Flat;

            close.FlatAppearance.BorderSize =
                0;

            close.Click +=
                (s, e) =>
                {
                    preview.Close();
                };

            footer.Controls.Add(
                close
            );

            preview.Controls.Add(
                grid
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
        // Dashboard Refresh
        // =====================================================

        private async Task RefreshDashboard()
        {
            await CheckInternetStatus();

            LoadN8nStatus();

            LoadDevicesStatus();

            LoadPendingStatus();

            LoadTodayStatistics();

            LoadTodayGrid();

            if (!syncRunning)
            {
                lblLastUpdate.Text =
                    "آخر تحديث: " +
                    DateTime.Now.ToString(
                        "yyyy-MM-dd HH:mm:ss"
                    );
            }
        }

        // =====================================================
        // Internet Status
        // =====================================================

        private async Task CheckInternetStatus()
        {
            bool internet =
                await IsInternetAvailable();

            if (internet)
            {
                lblInternetStatus.Text =
                    "متصل";

                lblInternetStatus.ForeColor =
                    Color.Green;
            }
            else
            {
                lblInternetStatus.Text =
                    "غير متصل";

                lblInternetStatus.ForeColor =
                    Color.Red;
            }
        }

        private async Task<bool>
            IsInternetAvailable()
        {
            try
            {
                using (HttpClient client =
                       new HttpClient())
                {
                    client.Timeout =
                        TimeSpan.FromSeconds(5);

                    using (
                        HttpResponseMessage response =
                        await client.GetAsync(
                            "https://www.google.com/generate_204"
                        )
                    )
                    {
                        return
                            response.IsSuccessStatusCode;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        // =====================================================
        // n8n Status
        // =====================================================

        private void LoadN8nStatus()
        {
            try
            {
                string enabled =
                    Database.GetSetting(
                        "n8n_enabled",
                        "0"
                    );

                if (enabled == "1")
                {
                    lblN8nStatus.Text =
                        "مفعلة";

                    lblN8nStatus.ForeColor =
                        Color.Green;
                }
                else
                {
                    lblN8nStatus.Text =
                        "متوقفة";

                    lblN8nStatus.ForeColor =
                        Color.Gray;
                }
            }
            catch
            {
                lblN8nStatus.Text =
                    "خطأ";

                lblN8nStatus.ForeColor =
                    Color.Red;
            }
        }

        // =====================================================
        // Devices Status
        // =====================================================

        private void LoadDevicesStatus()
        {
            try
            {
                DataTable devices =
                    Database.GetDevices();

                int total =
                    devices.Rows.Count;

                int active =
                    0;

                foreach (
                    DataRow row
                    in devices.Rows
                )
                {
                    if (
                        Convert.ToInt32(
                            row["enabled"]
                        ) == 1
                    )
                    {
                        active++;
                    }
                }

                lblDevicesStatus.Text =
                    active +
                    " / " +
                    total;

                if (total == 0)
                {
                    lblDevicesStatus.ForeColor =
                        Color.DarkOrange;
                }
                else if (active == total)
                {
                    lblDevicesStatus.ForeColor =
                        Color.Green;
                }
                else
                {
                    lblDevicesStatus.ForeColor =
                        Color.DarkOrange;
                }
            }
            catch
            {
                lblDevicesStatus.Text =
                    "خطأ";

                lblDevicesStatus.ForeColor =
                    Color.Red;
            }
        }

        // =====================================================
        // Pending
        // =====================================================

        private void LoadPendingStatus()
        {
            try
            {
                int pending =
                    Database.GetPendingQueueCount();

                lblPendingValue.Text =
                    pending.ToString();

                lblPendingValue.ForeColor =
                    pending == 0
                        ? Color.Green
                        : Color.DarkOrange;
            }
            catch
            {
                lblPendingValue.Text =
                    "خطأ";

                lblPendingValue.ForeColor =
                    Color.Red;
            }
        }

        // =====================================================
        // Today Statistics
        // =====================================================

        private void LoadTodayStatistics()
        {
            try
            {
                // ---------------------------------------------
                // إجمالي بصمات اليوم
                // ---------------------------------------------

                int punches =
                    Database.GetTodayAttendanceCount();

                lblPunchesValue.Text =
                    punches.ToString();

                // ---------------------------------------------
                // USER IDs النشطة
                // ---------------------------------------------

                int employees =
                    Database.GetTodayFingerprintCount();

                lblEmployeesValue.Text =
                    employees.ToString();

                // ---------------------------------------------
                // الأجهزة التي سجلت اليوم
                // ---------------------------------------------

                int devices =
                    Database.GetTodayDevicesCount();

                lblTodayDevicesValue.Text =
                    devices.ToString();

                // ---------------------------------------------
                // المرسل إلى n8n اليوم
                // ---------------------------------------------

                int sent =
                    Database.GetTodaySentQueueCount();

                lblSentValue.Text =
                    sent.ToString();

                // ---------------------------------------------
                // المعلق اليوم
                // ---------------------------------------------

                int pending =
                    Database.GetTodayPendingQueueCount();

                lblTodayPendingValue.Text =
                    pending.ToString();

                // ---------------------------------------------
                // آخر بصمة
                // ---------------------------------------------

                DateTime? lastPunch =
                    Database.GetTodayLastPunch();

                if (lastPunch.HasValue)
                {
                    lblLastPunchValue.Text =
                        lastPunch.Value
                        .ToString(
                            "HH:mm:ss"
                        );
                }
                else
                {
                    lblLastPunchValue.Text =
                        "--";
                }

                // ---------------------------------------------
                // Colors
                // ---------------------------------------------

                lblPunchesValue.ForeColor =
                    punches > 0
                        ? Color.FromArgb(
                            23,
                            95,
                            62
                        )
                        : Color.Gray;

                lblEmployeesValue.ForeColor =
                    employees > 0
                        ? Color.FromArgb(
                            23,
                            95,
                            62
                        )
                        : Color.Gray;

                lblTodayDevicesValue.ForeColor =
                    devices > 0
                        ? Color.Green
                        : Color.Gray;

                lblSentValue.ForeColor =
                    sent > 0
                        ? Color.Green
                        : Color.Gray;

                lblTodayPendingValue.ForeColor =
                    pending > 0
                        ? Color.DarkOrange
                        : Color.Green;

                lblLastPunchValue.ForeColor =
                    lastPunch.HasValue
                        ? Color.FromArgb(
                            23,
                            95,
                            62
                        )
                        : Color.Gray;
            }
            catch
            {
                lblPunchesValue.Text =
                    "0";

                lblEmployeesValue.Text =
                    "0";

                lblTodayDevicesValue.Text =
                    "0";

                lblSentValue.Text =
                    "0";

                lblTodayPendingValue.Text =
                    "0";

                lblLastPunchValue.Text =
                    "--";
            }
        }

        // =====================================================
        // Today Grid
        // =====================================================

        private void LoadTodayGrid()
        {
            try
            {
                dgvToday.DataSource =
                    Database
                    .GetTodayAttendanceSummary();

                dgvToday.ClearSelection();
            }
            catch
            {
                dgvToday.DataSource =
                    null;
            }
        }

        // =====================================================
        // Statistics Button
        // =====================================================

        private async void btnTodayStatistics_Click(
            object sender,
            EventArgs e)
        {
            await RefreshDashboard();
        }

        // =====================================================
        // Devices
        // =====================================================

        private async void btnDevices_Click(
            object sender,
            EventArgs e)
        {
            if (!RequireAdminPassword())
            {
                return;
            }

            using (DevicesForm form =
                   new DevicesForm())
            {
                form.ShowDialog(this);
            }

            await RefreshDashboard();
        }

        // =====================================================
        // Settings
        // =====================================================

        private async void btnSettings_Click(
            object sender,
            EventArgs e)
        {
            if (!RequireAdminPassword())
            {
                return;
            }

            using (SettingsForm form =
                   new SettingsForm())
            {
                DialogResult result =
                    form.ShowDialog(this);

                if (result == DialogResult.OK)
                {
                    InitializeAutoSyncTimer();

                    await RefreshDashboard();
                }
            }
        }

        // =====================================================
        // Retry Pending
        // =====================================================

        private async void btnRetryPending_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                btnRetryPending.Enabled =
                    false;

                btnRetryPending.Text =
                    "جاري الإرسال...";

                int pending =
                    Database.GetPendingQueueCount();

                if (pending == 0)
                {
                    MessageBox.Show(
                        "لا توجد بيانات معلقة للإرسال.",
                        "n8n",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    return;
                }

                int sent =
                    await N8nHelper.SendPendingAsync();

                await RefreshDashboard();

                MessageBox.Show(
                    "تمت محاولة إرسال البيانات المعلقة.\n\n" +
                    "تم الإرسال بنجاح: " +
                    sent +
                    "\n" +
                    "المتبقي: " +
                    Database.GetPendingQueueCount(),
                    "n8n",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "حدث خطأ أثناء إعادة الإرسال:\n\n" +
                    ex.Message,
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                btnRetryPending.Enabled =
                    true;

                btnRetryPending.Text =
                    "إعادة إرسال المعلق";
            }
        }

        // =====================================================
        // Close
        // =====================================================

        private void btnClose_Click(
            object sender,
            EventArgs e)
        {
            string runInBackground =
                Database.GetSetting(
                    "run_in_background",
                    "1"
                );

            if (runInBackground == "1")
            {
                Hide();

                ShowInTaskbar =
                    false;

                if (trayIcon != null)
                {
                    trayIcon.Visible =
                        true;

                    trayIcon.BalloonTipTitle =
                        "Attendance Collector";

                    trayIcon.BalloonTipText =
                        "البرنامج يعمل الآن في الخلفية وسيستمر السحب التلقائي.";

                    trayIcon.BalloonTipIcon =
                        ToolTipIcon.Info;

                    trayIcon.ShowBalloonTip(
                        2500
                    );
                }

                return;
            }

            DialogResult result =
                MessageBox.Show(
                    "سيتم إغلاق البرنامج بالكامل.\n\n" +
                    "سيتوقف السحب التلقائي من أجهزة البصمة حتى يتم تشغيل البرنامج مرة أخرى.\n\n" +
                    "هل تريد الخروج؟",
                    "تأكيد الخروج",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2
                );

            if (result == DialogResult.Yes)
            {
                ExitApplication();
            }
        }

        // =====================================================
        // Exit Application
        // =====================================================

        private void ExitApplication()
        {
            if (statusTimer != null)
            {
                statusTimer.Stop();
            }

            if (autoSyncTimer != null)
            {
                autoSyncTimer.Stop();
            }

            if (trayIcon != null)
            {
                trayIcon.Visible =
                    false;

                trayIcon.Dispose();

                trayIcon =
                    null;
            }

            Application.Exit();
        }

        // =====================================================
        // Attendance Logs
        // =====================================================

        private void btnAttendanceLogs_Click(
            object sender,
            EventArgs e)
        {
            using (AttendanceLogsForm form =
                   new AttendanceLogsForm())
            {
                form.ShowDialog(this);
            }
        }

        // =====================================================
        // Show Main Window
        // =====================================================

        private void ShowMainWindow()
        {
            Show();

            WindowState =
                FormWindowState.Normal;

            ShowInTaskbar =
                true;

            Activate();

            BringToFront();
        }

        // =====================================================
        // Tray Icon
        // =====================================================

        private void InitializeTrayIcon()
        {
            trayIcon =
                new NotifyIcon();

            trayIcon.Text =
                "Attendance Collector";

            trayIcon.Icon =
                this.Icon;

            trayIcon.Visible =
                true;

            ContextMenuStrip menu =
                new ContextMenuStrip();

            ToolStripMenuItem openItem =
                new ToolStripMenuItem(
                    "فتح البرنامج"
                );

            ToolStripMenuItem pullItem =
                new ToolStripMenuItem(
                    "سحب الآن"
                );

            ToolStripMenuItem exitItem =
                new ToolStripMenuItem(
                    "خروج"
                );

            openItem.Click +=
                (s, e) =>
                {
                    ShowMainWindow();
                };

            pullItem.Click +=
                async (s, e) =>
                {
                    if (!syncRunning)
                    {
                        await RunAutomaticSyncAsync();
                    }
                };

            exitItem.Click +=
                (s, e) =>
                {
                    ExitApplication();
                };

            menu.Items.Add(
                openItem
            );

            menu.Items.Add(
                pullItem
            );

            menu.Items.Add(
                new ToolStripSeparator()
            );

            menu.Items.Add(
                exitItem
            );

            trayIcon.ContextMenuStrip =
                menu;

            trayIcon.DoubleClick +=
                (s, e) =>
                {
                    ShowMainWindow();
                };
        }
    }

    // =========================================================
    // نتيجة سحب جهاز واحد
    // =========================================================

    public class DevicePullResult
    {
        public string DeviceName { get; set; }

        // الجديد
        public string DeviceCode { get; set; }

        public string ConnectionType { get; set; }

        public bool Connected { get; set; }

        public int ReadCount { get; set; }

        public int NewCount { get; set; }

        public int DuplicateCount { get; set; }

        public int ErrorCode { get; set; }

        public string Status { get; set; }

        public string Error { get; set; }
    }

    // =========================================================
    // نتيجة عملية السحب كاملة
    // =========================================================

    public class PullResult
    {
        public int TotalDevices { get; set; }

        public int ConnectedDevices { get; set; }

        public int FailedDevices { get; set; }

        public int TotalRead { get; set; }

        public int NewRecords { get; set; }

        public int DuplicateRecords { get; set; }

        public DateTime StartedAt { get; set; }

        public DateTime FinishedAt { get; set; }

        public List<DevicePullResult> Devices { get; set; }

        public PullResult()
        {
            Devices =
                new List<DevicePullResult>();
        }
    }
}