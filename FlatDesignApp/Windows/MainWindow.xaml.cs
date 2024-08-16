using FlatDesignApp.Methods;
using FlatDesignApp.Pages;
using FlatDesignApp.Pages.ViewPages;
using System.Windows;
using System.Windows.Interop;

namespace FlatDesignApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SourceInitialized += (s, e) =>
            {
                IntPtr handle = (new WindowInteropHelper(this)).Handle;
                HwndSource.FromHwnd(handle).AddHook(new HwndSourceHook(WindowLogic.WindowProc));
            };
            btnMin.Click += (s, e) => WindowState = WindowState.Minimized;
            btnMax.Click += (s, e) => WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
            btnExit.Click += (s, e) => { this.Hide(); (new LoginWindow()).Show(); };
            fPageNavigator.Navigate(new EmptyPage());
        }
        private void ProductButtonClick(object sender, RoutedEventArgs e) => fPageNavigator.Navigate(new ProductViewPage());
        private void CategoryButtonClick(object sender, RoutedEventArgs e) => fPageNavigator.Navigate(new CategoryViewPage());
        private void AddressButtonClick(object sender, RoutedEventArgs e) => fPageNavigator.Navigate(new AddressViewPage());
        private void DeliveryNoteButtonClick(object sender, RoutedEventArgs e) => fPageNavigator.Navigate(new DeliveryNoteViewPage());
        private void ClientButtonClick(object sender, RoutedEventArgs e) => fPageNavigator.Navigate(new ClientViewPage());
        private void BankDetailClick(object sender, RoutedEventArgs e) => fPageNavigator.Navigate(new BankDetailViewPage());
        private void BankClick(object sender, RoutedEventArgs e) => fPageNavigator.Navigate(new BankViewPage());
        private void GeoDataButtonClick(object sender, RoutedEventArgs e) => fPageNavigator.Navigate(new GeoDataViewPage());
    }
}