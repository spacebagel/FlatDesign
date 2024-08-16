using FlatDesignApp.Data;
using FlatDesignApp.Methods;
using FlatDesignApp.Models;
using System.Windows;
using System.Windows.Controls;

namespace FlatDesignApp.Pages.EditPages;

/// <summary>
/// Логика взаимодействия для ProductEditPage.xaml
/// </summary>
public partial class ProductEditPage : Page
{
    public Product? EditProduct { get; set; } = null;
    public ProductEditPage()
    {
        BaseConfig();
    }

    public ProductEditPage(Product editProduct)
    {
        EditProduct = editProduct;
        DataContext = this;
        BaseConfig();
        cbCategory.SelectedValue = editProduct.CategoryId;
    }

    private void BaseConfig()
    {
        InitializeComponent();
        cbCategory.ItemsSource = ObservableData.CategoryCollection;
    }

    private void SaveButtonClick(object sender, RoutedEventArgs e)
    {
        var isProductNull = EditProduct == null;

        Product currentProduct = isProductNull ? new Product { } : App.Context.Products.First(x => x.Id == EditProduct.Id);
        currentProduct.Name = tbName.Text;
        currentProduct.CategoryId = Convert.ToInt32(cbCategory.SelectedValue);

        DataLogic<Product>.AddObjToDb(isProductNull, App.Context.Products, currentProduct, ObservableData.ProductCollection,
            isProductNull ? null : ObservableData.ProductCollection.First(x => x.Id == EditProduct.Id));
    }

    private void CancelButtonClick(object sender, RoutedEventArgs e) =>
        NavigationService.Navigate(EditProduct == null ? new ProductEditPage() : new ProductEditPage(EditProduct));
}