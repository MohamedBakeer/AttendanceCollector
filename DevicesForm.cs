using AttendanceCollector.Cls;
using AttendanceCollector.Helper;
using System;
using System.Data;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AttendanceCollector
{
    public partial class DevicesForm : Form
    {
        private int selectedDeviceId = 0;

        public DevicesForm()
        {
            InitializeComponent();
        }

        // =====================================================
        // Form Load
        // =====================================================

        private void DevicesForm_Load(
            object sender,
            EventArgs e)
        {
            try
            {
                Database.Initialize();

                PrepareGrid();

                cmbConnectionType.SelectedIndex = 0;

                numPort.Value = 4370;

                numPassword.Text = "";

                chkActive.Checked = true;

                LoadDevices();

                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "حدث خطأ أثناء تحميل الأجهزة:\n\n" +
                    ex.Message,
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // =====================================================
        // Grid Setup
        // =====================================================

        private void PrepareGrid()
        {
            dgvDevices.AutoGenerateColumns = false;

            colId.DataPropertyName =
                "id";

            colDeviceName.DataPropertyName =
                "name";

            colDeviceCode.DataPropertyName =
                "device_code";

            colConnectionType.DataPropertyName =
                "connection_type";

            colIp.DataPropertyName =
                "host";

            colPort.DataPropertyName =
                "port";

            colStatus.DataPropertyName =
                "status_text";
        }

        // =====================================================
        // Load Devices
        // =====================================================

        private void LoadDevices()
        {
            DataTable table =
                Database.GetDevices();

            if (!table.Columns.Contains(
                "status_text"))
            {
                table.Columns.Add(
                    "status_text",
                    typeof(string)
                );
            }

            foreach (DataRow row in table.Rows)
            {
                bool enabled =
                    Convert.ToInt32(
                        row["enabled"]
                    ) == 1;

                row["status_text"] =
                    enabled
                        ? "مفعّل"
                        : "متوقف";
            }

            dgvDevices.DataSource =
                table;

            lblDevicesCount.Text =
                table.Rows.Count +
                " جهاز";

            dgvDevices.ClearSelection();
        }

        // =====================================================
        // Selection Changed
        // =====================================================

        private void dgvDevices_SelectionChanged(
            object sender,
            EventArgs e)
        {
            if (dgvDevices.CurrentRow == null)
            {
                return;
            }

            if (
                dgvDevices.CurrentRow
                .Cells["colId"]
                .Value == null
            )
            {
                return;
            }

            try
            {
                int deviceId =
                    Convert.ToInt32(
                        dgvDevices
                        .CurrentRow
                        .Cells["colId"]
                        .Value
                    );

                DataTable table =
                    Database.GetDeviceById(
                        deviceId
                    );

                if (table.Rows.Count == 0)
                {
                    return;
                }

                DataRow row =
                    table.Rows[0];

                selectedDeviceId =
                    Convert.ToInt32(
                        row["id"]
                    );

                txtDeviceName.Text =
                    row["name"]
                    .ToString();

                txtDeviceCode.Text =
                    row["device_code"]
                    .ToString();

                string connectionType =
                    row["connection_type"]
                    .ToString();

                if (
                    connectionType.Equals(
                        "LOCAL",
                        StringComparison.OrdinalIgnoreCase
                    )
                )
                {
                    cmbConnectionType.SelectedItem =
                        "Local";
                }
                else if (
                    connectionType.Equals(
                        "PUBLIC",
                        StringComparison.OrdinalIgnoreCase
                    )
                )
                {
                    cmbConnectionType.SelectedItem =
                        "Public";
                }
                else
                {
                    cmbConnectionType.Text =
                        connectionType;
                }

                txtIPAddress.Text =
                    row["host"]
                    .ToString();

                numPort.Value =
                    Convert.ToDecimal(
                        row["port"]
                    );

                int savedPassword =
                    Convert.ToInt32(
                        row["password"]
                    );

                numPassword.Text =
                    savedPassword == 0
                        ? ""
                        : savedPassword.ToString();

                chkActive.Checked =
                    Convert.ToInt32(
                        row["enabled"]
                    ) == 1;

                btnSave.Text =
                    "حفظ / تحديث الجهاز";
            }
            catch
            {
                // تجاهل أخطاء تغيير التحديد
            }
        }

        // =====================================================
        // Save / Update
        // =====================================================

        private void btnSave_Click(
            object sender,
            EventArgs e)
        {
            string deviceName =
                txtDeviceName.Text.Trim();

            string deviceCode =
                txtDeviceCode.Text
                .Trim()
                .ToUpper();

            string connectionType =
                cmbConnectionType.Text
                .Trim()
                .ToUpper();

            string host =
                txtIPAddress.Text.Trim();

            // =================================================
            // Device Name
            // =================================================

            if (string.IsNullOrWhiteSpace(
                deviceName))
            {
                MessageBox.Show(
                    "أدخل اسم الجهاز.",
                    "تنبيه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtDeviceName.Focus();

                return;
            }

            // =================================================
            // Device Code
            // =================================================

            if (string.IsNullOrWhiteSpace(
                deviceCode))
            {
                MessageBox.Show(
                    "أدخل رمز الجهاز.\n\n" +
                    "مثال:\n" +
                    "HO-01\n" +
                    "HO-02\n" +
                    "ZW-01",
                    "تنبيه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtDeviceCode.Focus();

                return;
            }

            // =================================================
            // Connection Type
            // =================================================

            if (string.IsNullOrWhiteSpace(
                connectionType))
            {
                MessageBox.Show(
                    "اختر طريقة الاتصال.",
                    "تنبيه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                cmbConnectionType.Focus();

                return;
            }

            // =================================================
            // Host
            // =================================================

            if (string.IsNullOrWhiteSpace(
                host))
            {
                MessageBox.Show(
                    "أدخل IP / Host الجهاز.",
                    "تنبيه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtIPAddress.Focus();

                return;
            }

            try
            {
                // =================================================
                // Password
                // =================================================

                int password = 0;

                if (!string.IsNullOrWhiteSpace(
                    numPassword.Text))
                {
                    if (!int.TryParse(
                        numPassword.Text.Trim(),
                        out password))
                    {
                        MessageBox.Show(
                            "كلمة سر الجهاز يجب أن تكون رقمًا فقط.",
                            "تنبيه",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );

                        numPassword.Focus();

                        return;
                    }
                }

                // =================================================
                // Add
                // =================================================

                if (selectedDeviceId == 0)
                {
                    Database.AddDevice(
                        deviceName,
                        deviceCode,
                        connectionType,
                        host,
                        Convert.ToInt32(
                            numPort.Value
                        ),
                        password,
                        chkActive.Checked
                    );

                    MessageBox.Show(
                        "تم حفظ الجهاز بنجاح.",
                        "تم",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }

                // =================================================
                // Update
                // =================================================

                else
                {
                    Database.UpdateDevice(
                        selectedDeviceId,
                        deviceName,
                        deviceCode,
                        connectionType,
                        host,
                        Convert.ToInt32(
                            numPort.Value
                        ),
                        password,
                        chkActive.Checked
                    );

                    MessageBox.Show(
                        "تم تحديث الجهاز بنجاح.",
                        "تم",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }

                LoadDevices();

                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "حدث خطأ أثناء حفظ الجهاز:\n\n" +
                    ex.Message,
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // =====================================================
        // Double Click = Delete
        // =====================================================

        private void dgvDevices_DoubleClick(
            object sender,
            EventArgs e)
        {
            if (dgvDevices.CurrentRow == null)
            {
                return;
            }

            try
            {
                int deviceId =
                    Convert.ToInt32(
                        dgvDevices
                        .CurrentRow
                        .Cells["colId"]
                        .Value
                    );

                string deviceName =
                    dgvDevices
                    .CurrentRow
                    .Cells["colDeviceName"]
                    .Value?
                    .ToString()
                    ?? "";

                string deviceCode =
                    dgvDevices
                    .CurrentRow
                    .Cells["colDeviceCode"]
                    .Value?
                    .ToString()
                    ?? "";

                DialogResult result =
                    MessageBox.Show(
                        "هل أنت متأكد من حذف هذا الجهاز؟\n\n" +
                        "الجهاز: " +
                        deviceName +
                        "\n" +
                        "رمز الجهاز: " +
                        deviceCode,
                        "تأكيد حذف الجهاز",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button2
                    );

                if (result != DialogResult.Yes)
                {
                    return;
                }

                Database.DeleteDevice(
                    deviceId
                );

                MessageBox.Show(
                    "تم حذف الجهاز بنجاح.",
                    "تم الحذف",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                LoadDevices();

                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "تعذر حذف الجهاز.\n\n" +
                    "إذا كان الجهاز يحتوي على سجلات حضور، " +
                    "قم بتعطيله بدل حذفه.\n\n" +
                    ex.Message,
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // =====================================================
        // Test Connection
        // =====================================================

        private async void btnTestConnection_Click(
            object sender,
            EventArgs e)
        {
            string host =
                txtIPAddress.Text.Trim();

            int port =
                Convert.ToInt32(
                    numPort.Value
                );

            int password = 0;

            if (!string.IsNullOrWhiteSpace(
                numPassword.Text))
            {
                if (!int.TryParse(
                    numPassword.Text.Trim(),
                    out password))
                {
                    MessageBox.Show(
                        "كلمة سر الاتصال يجب أن تكون رقمًا فقط.",
                        "تنبيه",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    numPassword.Focus();

                    return;
                }
            }

            if (string.IsNullOrWhiteSpace(
                host))
            {
                MessageBox.Show(
                    "أدخل IP / Host الجهاز أولاً.",
                    "تنبيه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtIPAddress.Focus();

                return;
            }

            btnTestConnection.Enabled =
                false;

            btnTestConnection.Text =
                "جاري الاختبار...";

            try
            {
                // =================================================
                // 1. TCP Test
                // =================================================

                bool tcpConnected =
                    await TestTcpConnection(
                        host,
                        port,
                        5000
                    );

                if (!tcpConnected)
                {
                    MessageBox.Show(
                        "فشل الوصول إلى الجهاز عبر الشبكة.\n\n" +
                        "TCP: فشل\n" +
                        "ZKTeco: لم يتم الاختبار\n\n" +
                        "IP / Host: " +
                        host +
                        "\n" +
                        "Port: " +
                        port,
                        "فشل الاتصال",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                // =================================================
                // 2. ZKTeco SDK Test
                // =================================================

                ZktecoHelper zk =
                    new ZktecoHelper();

                bool zkConnected =
                    zk.Connect(
                        host,
                        port,
                        password
                    );

                if (zkConnected)
                {
                    string serialNumber =
                        zk.GetSerialNumber();

                    string serialText =
                        string.IsNullOrWhiteSpace(
                            serialNumber
                        )
                            ? "غير متاح"
                            : serialNumber;

                    MessageBox.Show(
                        "تم الاتصال بالجهاز بنجاح.\n\n" +

                        "TCP: ناجح\n" +
                        "ZKTeco: ناجح\n\n" +

                        "رمز الجهاز: " +
                        (
                            string.IsNullOrWhiteSpace(
                                txtDeviceCode.Text
                            )
                                ? "غير محدد"
                                : txtDeviceCode.Text.Trim()
                        ) +
                        "\n" +

                        "IP / Host: " +
                        host +
                        "\n" +

                        "Port: " +
                        port +
                        "\n" +

                        "طريقة الاتصال: " +
                        cmbConnectionType.Text +
                        "\n\n" +

                        "Serial Number: " +
                        serialText,

                        "الاتصال ناجح",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    zk.Disconnect();
                }
                else
                {
                    MessageBox.Show(
                        "تم الوصول إلى الجهاز عبر الشبكة، " +
                        "لكن اتصال ZKTeco لم ينجح.\n\n" +

                        "TCP: ناجح\n" +
                        "ZKTeco: فشل\n\n" +

                        "IP / Host: " +
                        host +
                        "\n" +

                        "Port: " +
                        port +
                        "\n" +

                        "كلمة الاتصال: " +
                        (
                            password == 0
                                ? "بدون رمز"
                                : "يوجد رمز"
                        ) +
                        "\n" +

                        "Error Code: " +
                        zk.LastErrorCode +
                        "\n\n" +

                        "هذا يعني غالبًا أن الشبكة سليمة، " +
                        "لكن توجد مشكلة في إعدادات جهاز البصمة " +
                        "أو كلمة الاتصال أو SDK.",

                        "اتصال جزئي",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    zk.Disconnect();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "حدث خطأ أثناء اختبار الاتصال:\n\n" +
                    ex.Message,
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                btnTestConnection.Enabled =
                    true;

                btnTestConnection.Text =
                    "اختبار الاتصال";
            }
        }

        // =====================================================
        // TCP Test
        // =====================================================

        private async Task<bool> TestTcpConnection(
            string host,
            int port,
            int timeoutMilliseconds)
        {
            using (TcpClient client =
                   new TcpClient())
            {
                try
                {
                    Task connectTask =
                        client.ConnectAsync(
                            host,
                            port
                        );

                    Task timeoutTask =
                        Task.Delay(
                            timeoutMilliseconds
                        );

                    Task completedTask =
                        await Task.WhenAny(
                            connectTask,
                            timeoutTask
                        );

                    if (completedTask != connectTask)
                    {
                        return false;
                    }

                    await connectTask;

                    return client.Connected;
                }
                catch
                {
                    return false;
                }
            }
        }

        // =====================================================
        // Clear
        // =====================================================

        private void btnClear_Click(
            object sender,
            EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            selectedDeviceId = 0;

            txtDeviceName.Clear();

            txtDeviceCode.Clear();

            txtIPAddress.Clear();

            if (cmbConnectionType.Items.Count > 0)
            {
                cmbConnectionType.SelectedIndex = 0;
            }

            numPort.Value = 4370;

            numPassword.Clear();

            chkActive.Checked = true;

            btnSave.Text =
                "حفظ الجهاز";

            dgvDevices.ClearSelection();

            txtDeviceName.Focus();
        }

        // =====================================================
        // Close
        // =====================================================

        private void button_close_Click(
            object sender,
            EventArgs e)
        {
            Close();
        }
    }
}