using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace AttendanceCollector
{
    public partial class WelcomeForm : Form
    {
        public WelcomeForm()
        {
            InitializeComponent();
        }

        private void btnStart_Click(
            object sender,
            EventArgs e)
        {
            DialogResult =
                DialogResult.OK;

            Close();
        }

        private void lblPoweredBy_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                Process.Start(
                    new ProcessStartInfo
                    {
                        FileName =
                            "https://me.itxvx.ly",

                        UseShellExecute =
                            true
                    }
                );
            }
            catch
            {
            }
        }
    }
}