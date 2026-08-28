using AttendanceCollector.Cls;
using AttendanceCollector.Helper;
using System;
using System.Windows.Forms;

namespace AttendanceCollector
{
    public partial class AdminPasswordForm : Form
    {
        public bool Authenticated
        {
            get;
            private set;
        }

        public AdminPasswordForm()
        {
            InitializeComponent();

            Authenticated = false;
        }

        private void AdminPasswordForm_Load(
            object sender,
            EventArgs e)
        {
            txtPassword.Clear();

            lblStatus.Text = "";

            txtPassword.Focus();
        }

        private void btnLogin_Click(
            object sender,
            EventArgs e)
        {
            CheckPassword();
        }

        private void txtPassword_KeyDown(
            object sender,
            KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                CheckPassword();
            }
        }

        private void CheckPassword()
        {
            string password =
                txtPassword.Text;

            if (string.IsNullOrWhiteSpace(password))
            {
                lblStatus.Text =
                    "أدخل كلمة المرور.";

                txtPassword.Focus();

                return;
            }

            string storedHash =
                Database.GetSetting(
                    "admin_password_hash",
                    ""
                );

            if (string.IsNullOrWhiteSpace(storedHash))
            {
                lblStatus.Text =
                    "لم يتم إعداد كلمة مرور الإدارة.";

                return;
            }

            bool valid =
                SecurityHelper.VerifyPassword(
                    password,
                    storedHash
                );

            if (!valid)
            {
                lblStatus.Text =
                    "كلمة المرور غير صحيحة.";

                txtPassword.SelectAll();

                txtPassword.Focus();

                return;
            }

            Authenticated =
                true;

            DialogResult =
                DialogResult.OK;

            Close();
        }

        private void btnCancel_Click(
            object sender,
            EventArgs e)
        {
            Authenticated =
                false;

            DialogResult =
                DialogResult.Cancel;

            Close();
        }
    }
}