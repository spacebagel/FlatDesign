using FlatDesignApp.Methods;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;

namespace FlatDesignApp.Windows;

/// <summary>
/// Логика взаимодействия для PopupWindow.xaml
/// </summary>
public partial class PopupWindow : Window
{
    public PopupWindow(Page showPage)
    {
        InitializeComponent();
        SourceInitialized += (s, e) =>
        {
            IntPtr handle = (new WindowInteropHelper(this)).Handle;
            HwndSource.FromHwnd(handle).AddHook(new HwndSourceHook(WindowLogic.PopupWindowProc));
        };
        btnMin.Click += (s, e) => WindowState = WindowState.Minimized;
        btnMax.Click += (s, e) => WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
        btnExit.Click += (s, e) => Close();
        PopupPagesNavigation.Navigate(showPage);
    }
    private void Grid_MouseDown(object sender, MouseButtonEventArgs e) => Keyboard.ClearFocus();

}