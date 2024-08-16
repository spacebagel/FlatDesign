using FlatDesignApp.Methods;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;

namespace FlatDesignApp.Windows;

/// <summary>
/// Логика взаимодействия для LoginWindow.xaml
/// </summary>
public partial class LoginWindow : Window
{
    public LoginWindow()
    {
        InitializeComponent();
        SourceInitialized += (s, e) =>
        {
            IntPtr handle = (new WindowInteropHelper(this)).Handle;
            HwndSource.FromHwnd(handle).AddHook(new HwndSourceHook(WindowLogic.WindowProc));
        };
        btnMin.Click += (s, e) => WindowState = WindowState.Minimized;
        btnMax.Click += (s, e) => WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
        btnExit.Click += (s, e) => Application.Current.Shutdown();
    }

    private void CancelButtonClick(object sender, RoutedEventArgs e) => Application.Current.Shutdown();

    private void lblForgotMouseDown(object sender, MouseButtonEventArgs e)
    {
        string to = "email@email.com";
        string subject = "Help to remember the password";
        string body = "I didn't write down or remember the password. I admit my guilt. Please help me :(";

        string mailto = $"mailto:{to}?subject={Uri.EscapeDataString(subject)}&body={Uri.EscapeDataString(body)}";

        try
        {
            Process.Start(new ProcessStartInfo(mailto) { UseShellExecute = true });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex}");
        }
    }
}