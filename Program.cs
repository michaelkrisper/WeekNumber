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
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool SetProcessDpiAwarenessContext(IntPtr dpiContext);
        private const string RegistryKeyPath = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";

        [STAThread]
        private static void Main()
        {
            SetProcessDpiAwarenessContext(new IntPtr(-4));

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Program context = new();
            Application.Run(context);
            context.Dispose();
        }

        public Program()
        {
            var week = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday).ToString(CultureInfo.InvariantCulture).PadLeft(2, '0');
            using Bitmap bitmap = new Bitmap(32, 32);
            using Graphics graphics = Graphics.FromImage(bitmap);
            using Font font = new Font("Segoe UI", 18);
            using Brush brush = new SolidBrush(Color.White);
            graphics.DrawString(week, font, brush, 0, 0);
            using Icon icon = Icon.FromHandle(bitmap.GetHicon());
            ContextMenu context = new ContextMenu([new MenuItem("Exit", (_, __) => Application.Exit())]);
            _ = new NotifyIcon { Visible = true, ContextMenu = context, Icon = icon };

            using var registryKey = Registry.CurrentUser.OpenSubKey(RegistryKeyPath, true);
            registryKey?.SetValue(Path.GetFileNameWithoutExtension(Application.ExecutablePath), Application.ExecutablePath);

        }
    }
}