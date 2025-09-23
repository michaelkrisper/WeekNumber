using Microsoft.Win32;
using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WeekNumber
{
    class Program : ApplicationContext
    {
        [DllImport("user32.dll")]
        private static extern bool SetProcessDpiAwarenessContext(IntPtr dpiContext);

        [STAThread]
        static void Main()
        {
            SetProcessDpiAwarenessContext(new IntPtr(-4));

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using Program context = new();
            Application.Run(context);
        }

        public Program()
        {
            var week = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            using Bitmap bitmap = new Bitmap(32, 32);
            using Graphics graphics = Graphics.FromImage(bitmap);
            using Font fontSmall = new Font("Segoe UI", 12);
            using Brush brush = new SolidBrush(Color.White);
            using Font fontBig = new Font("Segoe UI", 18);
            using StringFormat format = new StringFormat { Alignment = StringAlignment.Center };
            graphics.DrawString("KW", fontSmall, brush, 16, -6, format);
            graphics.DrawString(week.ToString().PadLeft(2, '0'), fontBig, brush, 16, fontSmall.GetHeight() - 16, format);
            using Icon icon = Icon.FromHandle(bitmap.GetHicon());
            ContextMenu context = new ContextMenu([new MenuItem("Exit", (_, __) => Application.Exit())]);
            _ = new NotifyIcon { Visible = true, ContextMenu = context, Icon = icon };

            using var registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            registryKey.SetValue(Path.GetFileNameWithoutExtension(Application.ExecutablePath), Application.ExecutablePath);
        }
    }
}