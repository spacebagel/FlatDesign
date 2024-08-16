using FlatDesignApp.Windows;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;

namespace FlatDesignApp.Methods;
public class WindowLogic
{
    public static IntPtr WindowProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
    {
        if (msg == 0x0024)
        {
            WmGetMinMaxInfo(hwnd, lParam);
            handled = true;
        }
        return IntPtr.Zero;
    }

    public static IntPtr PopupWindowProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
    {
        if (msg == 0x0024)
        {
            WmGetMinMaxInfo(hwnd, lParam, 450, 450);
            handled = true;
        }
        return IntPtr.Zero;
    }

    private static void WmGetMinMaxInfo(IntPtr hwnd, IntPtr lParam, int minXSize = 800, int minYSize = 500)
    {
        MINMAXINFO mmi = Marshal.PtrToStructure<MINMAXINFO>(lParam);
        int MONITOR_DEFAULTTONEAREST = 0x00000002;
        IntPtr monitor = MonitorFromWindow(hwnd, MONITOR_DEFAULTTONEAREST);
        if (monitor != IntPtr.Zero)
        {
            MONITORINFO monitorInfo = new MONITORINFO();
            GetMonitorInfo(monitor, monitorInfo);
            RECT rcWorkArea = monitorInfo.rcWork;
            RECT rcMonitorArea = monitorInfo.rcMonitor;
            mmi.ptMaxPosition.x = Math.Abs(rcWorkArea.left - rcMonitorArea.left);
            mmi.ptMaxPosition.y = Math.Abs(rcWorkArea.top - rcMonitorArea.top);
            mmi.ptMaxSize.x = Math.Abs(rcWorkArea.right - rcWorkArea.left);
            mmi.ptMaxSize.y = Math.Abs(rcWorkArea.bottom - rcWorkArea.top);
            mmi.ptMinTrackSize.x = minXSize;
            mmi.ptMinTrackSize.y = minYSize;
        }
        Marshal.StructureToPtr(mmi, lParam, true);
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public int x;
        public int y;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MINMAXINFO
    {
        public POINT ptReserved;
        public POINT ptMaxSize;
        public POINT ptMaxPosition;
        public POINT ptMinTrackSize;
        public POINT ptMaxTrackSize;
    };

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public class MONITORINFO
    {
        public int cbSize = Marshal.SizeOf(typeof(MONITORINFO));
        public RECT rcMonitor = new RECT();
        public RECT rcWork = new RECT();
        public int dwFlags = 0;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 0)]
    public struct RECT
    {
        public int left;
        public int top;
        public int right;
        public int bottom;
        public static readonly RECT Empty = new RECT();
        public int Width { get { return Math.Abs(right - left); } }
        public int Height { get { return bottom - top; } }
        public RECT(int left, int top, int right, int bottom)
        {
            this.left = left;
            this.top = top;
            this.right = right;
            this.bottom = bottom;
        }
        public RECT(RECT rcSrc)
        {
            left = rcSrc.left;
            top = rcSrc.top;
            right = rcSrc.right;
            bottom = rcSrc.bottom;
        }
        public bool IsEmpty { get { return left >= right || top >= bottom; } }
        public override string ToString()
        {
            if (this == Empty) { return "RECT {Empty}"; }
            return "RECT { left : " + left + " / top : " + top + " / right : " + right + " / bottom : " + bottom + " }";
        }
        public override bool Equals(object obj)
        {
            if (!(obj is Rect)) { return false; }
            return (this == (RECT)obj);
        }
        /// <summary>Return the HashCode for this struct (not garanteed to be unique)</summary>
        public override int GetHashCode() => left.GetHashCode() + top.GetHashCode() + right.GetHashCode() + bottom.GetHashCode();
        /// <summary> Determine if 2 RECT are equal (deep compare)</summary>
        public static bool operator ==(RECT rect1, RECT rect2) { return (rect1.left == rect2.left && rect1.top == rect2.top && rect1.right == rect2.right && rect1.bottom == rect2.bottom); }
        /// <summary> Determine if 2 RECT are different(deep compare)</summary>
        public static bool operator !=(RECT rect1, RECT rect2) { return !(rect1 == rect2); }
    }

    [DllImport("user32")]
    internal static extern bool GetMonitorInfo(IntPtr hMonitor, MONITORINFO lpmi);

    [DllImport("User32")]
    internal static extern IntPtr MonitorFromWindow(IntPtr handle, int flags);

    public static void OpenPopupPage(Page page) => new PopupWindow(page).ShowDialog();

    public static bool ConfirmDeletionShowMessage() => MessageBox.Show("Are you sure want to delete the selected item?", "Warning!", MessageBoxButton.YesNo) == MessageBoxResult.Yes;
}