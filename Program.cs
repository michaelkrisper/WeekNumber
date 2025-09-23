using Microsoft.Win32;
using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WeekNumber;
internal class Program : ApplicationContext
{
    [DllImport("user32.dll")]
    private static extern bool SetProcessDpiAwarenessContext(IntPtr dpiContext);

    [DllImport("user32.dll")]
    private static extern uint GetDpiForWindow(IntPtr hwnd);

    [DllImport("user32.dll")]
    private static extern IntPtr GetDesktopWindow();

    [STAThread]
    private static void Main()
    {
        _ = SetProcessDpiAwarenessContext(new IntPtr(-4));

        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        using Program context = new();
        Application.Run(context);
    }

    public Program()
    {
        var week = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday).ToString().PadLeft(2, '0');

        var dpi = GetDpiForWindow(GetDesktopWindow());
        var scaleFactor = dpi / 96.0f;

        var iconSize = Math.Max(16, Math.Min(32, (int)(20 * scaleFactor)));
        var smallFontSize = Math.Max(4, iconSize * 0.5f);
        var bigFontSize = Math.Max(6, iconSize * 0.7f);

        using var fontSmall = new Font("Segoe UI", smallFontSize, FontStyle.Regular, GraphicsUnit.Pixel);
        using Brush brush = new SolidBrush(Color.White);
        using var fontBig = new Font("Segoe UI", bigFontSize, FontStyle.Bold, GraphicsUnit.Pixel);
        using var format = new StringFormat { Alignment = StringAlignment.Center };
        using var bitmap = new Bitmap(iconSize, iconSize);
        using var graphics = Graphics.FromImage(bitmap);
        graphics.DrawString("KW", fontSmall, brush, iconSize / 2f, -smallFontSize / 2f, format);
        graphics.DrawString(week, fontBig, brush, iconSize / 2f, fontSmall.Height - smallFontSize, format);
        using var icon = Icon.FromHandle(bitmap.GetHicon());
        
        var context = new ContextMenu([new MenuItem("Exit", (_, __) => Application.Exit())]);
        _ = new NotifyIcon { Visible = true, ContextMenu = context, Icon = icon, Text = "KW " + week };

        using var registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        registryKey.SetValue(Path.GetFileNameWithoutExtension(Application.ExecutablePath), Application.ExecutablePath);
    }
}