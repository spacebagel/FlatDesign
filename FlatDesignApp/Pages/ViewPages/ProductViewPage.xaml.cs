using FlatDesignApp.Data;
using FlatDesignApp.Methods;
using FlatDesignApp.Models;
using FlatDesignApp.Pages.EditPages;
using Microsoft.IdentityModel.Tokens;
using System.Windows;
using System.Windows.Controls;

namespace FlatDesignApp.Pages.ViewPages;

/// <summary>
/// Логика взаимодействия для ProductViewPage.xaml
/// </summary>
public partial class ProductViewPage : Page
{
    public ProductViewPage()
    {
        InitializeComponent();
        dgProduct.ItemsSource = ObservableData.ProductCollection;
    }
    private void AddButtonClick(object sender, RoutedEventArgs e) => WindowLogic.OpenPopupPage(new ProductEditPage());
    private void SearchBoxTextChanged(object sender, TextChangedEventArgs e) => UpdateDGContext();
    private void DeleteButtonClick(object sender, RoutedEventArgs e)
    {
        if (WindowLogic.ConfirmDeletionShowMessage())
            DataLogic<Product>.DeleteObjFromDb(sender, ObservableData.ProductCollection);
    }

    private void EditButtonClick(object sender, RoutedEventArgs e) =>
        WindowLogic.OpenPopupPage(new ProductEditPage(DataLogic<Product>.TypeFromSender(sender)));

    private void UpdateDGContext()
    {
        IEnumerable<Product> localContext = ObservableData.ProductCollection;
        if (!searchBox.Text.IsNullOrEmpty())
        {
            localContext = ObservableData.ProductCollection.Where(x => x.Name.Contains(searchBox.Text, StringComparison.OrdinalIgnoreCase)
            || (x.Category != null && x.Category.Name.Contains(searchBox.Text, StringComparison.OrdinalIgnoreCase)));
        }
        dgProduct.ItemsSource = localContext;
    }
}