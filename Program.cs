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

        [DllImport("user32.dll")]
        private static extern uint GetDpiForWindow(IntPtr hwnd);

        [DllImport("user32.dll")]
        private static extern IntPtr GetDesktopWindow();

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
            
            // Get DPI scaling factor
            uint dpi = GetDpiForWindow(GetDesktopWindow());
            float scaleFactor = dpi / 96.0f; // 96 DPI is the standard baseline
            
            // Use a reasonable icon size - system tray icons are typically 16x16 to 32x32
            // Scale moderately to avoid issues with different tray icon sizes
            int iconSize = Math.Max(16, Math.Min(32, (int)(20 * scaleFactor)));
            
            // Scale font sizes appropriately for the icon size
            float smallFontSize = Math.Max(4, iconSize * 0.3f); // About 30% of icon size
            float bigFontSize = Math.Max(6, iconSize * 0.45f);  // About 45% of icon size
            
            using Bitmap bitmap = new Bitmap(iconSize, iconSize);
            using Graphics graphics = Graphics.FromImage(bitmap);
            
            // Set high quality rendering
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            
            // Fill with black background for better contrast
            graphics.Clear(Color.Black);
            
            using Font fontSmall = new Font("Segoe UI", smallFontSize, FontStyle.Regular, GraphicsUnit.Pixel);
            using Brush brush = new SolidBrush(Color.White);
            using Font fontBig = new Font("Segoe UI", bigFontSize, FontStyle.Bold, GraphicsUnit.Pixel);
            using StringFormat format = new StringFormat { 
                Alignment = StringAlignment.Center, 
                LineAlignment = StringAlignment.Center 
            };
            
            // Calculate positions relative to icon size
            float centerX = iconSize / 2.0f;
            float topTextY = iconSize * 0.28f;  // Position "KW" at 28% from top
            float bottomTextY = iconSize * 0.72f; // Position week number at 72% from top
            
            graphics.DrawString("KW", fontSmall, brush, centerX, topTextY, format);
            graphics.DrawString(week.ToString().PadLeft(2, '0'), fontBig, brush, centerX, bottomTextY, format);
            
            using Icon icon = Icon.FromHandle(bitmap.GetHicon());
            ContextMenu context = new ContextMenu([new MenuItem("Exit", (_, __) => Application.Exit())]);
            _ = new NotifyIcon { Visible = true, ContextMenu = context, Icon = icon };

            using var registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            registryKey.SetValue(Path.GetFileNameWithoutExtension(Application.ExecutablePath), Application.ExecutablePath);
        }
    }
}