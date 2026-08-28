using AttendanceCollector.Cls;
using System;
using System.Data;
using System.Windows.Forms;

namespace AttendanceCollector
{
    public partial class AttendanceLogsForm : Form
    {
        public AttendanceLogsForm()
        {
            InitializeComponent();
        }

        private void AttendanceLogsForm_Load(
            object sender,
            EventArgs e)
        {
            dtpFromDate.Value = DateTime.Today;
            dtpToDate.Value = DateTime.Today;

            PrepareGrid();
            LoadDevices();
            LoadLogs();
        }

        private void PrepareGrid()
        {
            dgvLogs.AutoGenerateColumns = false;

            colId.DataPropertyName =
                "id";

            colFingerprint.DataPropertyName =
                "fingerprint_id";

            colDate.DataPropertyName =
                "punch_date";

            colTime.DataPropertyName =
                "punch_time_only";

            colBranch.DataPropertyName =
                "branch";

            colDevice.DataPropertyName =
                "device_name";

            colVerifyMode.DataPropertyName =
                "verify_mode";
        }

        private void LoadDevices()
        {
            DataTable devices =
                Database.GetDevices();

            DataRow allRow =
                devices.NewRow();

            allRow["id"] = 0;
            allRow["name"] = "كل الأجهزة";

            devices.Rows.InsertAt(
                allRow,
                0
            );

            cmbDevice.DisplayMember =
                "name";

            cmbDevice.ValueMember =
                "id";

            cmbDevice.DataSource =
                devices;
        }

        private void LoadLogs()
        {
            int deviceId = 0;

            if (
                cmbDevice.SelectedValue != null &&
                cmbDevice.SelectedValue != DBNull.Value
            )
            {
                int.TryParse(
                    cmbDevice.SelectedValue.ToString(),
                    out deviceId
                );
            }

            DataTable table =
                Database.GetAttendanceLogs(
                    dtpFromDate.Value.Date,
                    dtpToDate.Value.Date,
                    txtFingerprint.Text.Trim(),
                    txtBranch.Text.Trim(),
                    deviceId
                );

            dgvLogs.DataSource =
                table;

            lblCount.Text =
                table.Rows.Count +
                " سجل";

            dgvLogs.ClearSelection();
        }

        private void btnSearch_Click(
            object sender,
            EventArgs e)
        {
            LoadLogs();
        }

        private void btnToday_Click(
            object sender,
            EventArgs e)
        {
            dtpFromDate.Value =
                DateTime.Today;

            dtpToDate.Value =
                DateTime.Today;

            LoadLogs();
        }

        private void btnClearFilters_Click(
            object sender,
            EventArgs e)
        {
            dtpFromDate.Value =
                DateTime.Today;

            dtpToDate.Value =
                DateTime.Today;

            txtFingerprint.Clear();
            txtBranch.Clear();

            if (cmbDevice.Items.Count > 0)
            {
                cmbDevice.SelectedIndex = 0;
            }

            LoadLogs();
        }

        private void btnTimeSheet_Click(
            object sender,
            EventArgs e)
        {
            string fingerprintId =
                txtFingerprint.Text.Trim();

            if (string.IsNullOrWhiteSpace(fingerprintId))
            {
                MessageBox.Show(
                    "أدخل رقم البصمة أولاً لاستخراج Time Sheet.",
                    "Time Sheet",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                txtFingerprint.Focus();
                return;
            }

            DataTable table =
                Database.GetEmployeeTimeSheet(
                    fingerprintId,
                    dtpFromDate.Value.Date,
                    dtpToDate.Value.Date
                );

            if (table.Rows.Count == 0)
            {
                MessageBox.Show(
                    "لا توجد سجلات لرقم البصمة المحدد في هذه الفترة.",
                    "Time Sheet",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                return;
            }

            TimeSheetForm form =
                new TimeSheetForm(
                    fingerprintId,
                    dtpFromDate.Value.Date,
                    dtpToDate.Value.Date,
                    table
                );

            form.ShowDialog(this);
        }

        private void btnClose_Click(
            object sender,
            EventArgs e)
        {
            this.Close();
        }
    }
}