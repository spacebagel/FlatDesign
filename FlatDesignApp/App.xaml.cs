using FlatDesignApp.Data;
using System.Windows;

namespace FlatDesignApp;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public static ProductDeliveryContext Context = new ProductDeliveryContext();
}