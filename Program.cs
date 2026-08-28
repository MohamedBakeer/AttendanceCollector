using AttendanceCollector.Cls;
using System;
using System.Windows.Forms;

namespace AttendanceCollector
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();

            Application.SetCompatibleTextRenderingDefault(
                false
            );

            Database.Initialize();

            string startMinimized =
                Database.GetSetting(
                    "start_minimized",
                    "0"
                );

            // إذا سيعمل مصغرًا مع Windows
            // لا نعرض شاشة البداية
            if (startMinimized == "1")
            {
                Application.Run(
                    new MainForm()
                );

                return;
            }

            using (WelcomeForm welcome =
                   new WelcomeForm())
            {
                DialogResult result =
                    welcome.ShowDialog();

                if (result != DialogResult.OK)
                {
                    return;
                }
            }

            Application.Run(
                new MainForm()
            );
        }
    }
}