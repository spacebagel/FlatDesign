using FlatDesignApp.Data;
using FlatDesignApp.Methods;
using FlatDesignApp.Models;
using FlatDesignApp.Pages.EditPages;
using Microsoft.IdentityModel.Tokens;
using System.Windows;
using System.Windows.Controls;

namespace FlatDesignApp.Pages.ViewPages;

/// <summary>
/// Логика взаимодействия для CategoryViewPage.xaml
/// </summary>
public partial class CategoryViewPage : Page
{
    public CategoryViewPage()
    {
        InitializeComponent();
        dgCategory.ItemsSource = ObservableData.CategoryCollection;
    }
    private void AddButtonClick(object sender, RoutedEventArgs e) => WindowLogic.OpenPopupPage(new CategoryEditPage());
    private void SearchBoxTextChanged(object sender, TextChangedEventArgs e) => UpdateDGContext();
    private void DeleteButtonClick(object sender, RoutedEventArgs e)
    {
        if (WindowLogic.ConfirmDeletionShowMessage())
            DataLogic<Category>.DeleteObjFromDb(sender, ObservableData.CategoryCollection);
    }

    private void EditButtonClick(object sender, RoutedEventArgs e) =>
        WindowLogic.OpenPopupPage(new CategoryEditPage(DataLogic<Category>.TypeFromSender(sender)));

    private void UpdateDGContext()
    {
        IEnumerable<Category> localContext = ObservableData.CategoryCollection;
        if (!searchBox.Text.IsNullOrEmpty())
        {
            localContext = ObservableData.CategoryCollection.Where(x => x.Name.Contains(searchBox.Text, StringComparison.OrdinalIgnoreCase));
        }
        dgCategory.ItemsSource = localContext;
    }
}