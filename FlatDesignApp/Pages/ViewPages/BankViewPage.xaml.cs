using FlatDesignApp.Data;
using FlatDesignApp.Methods;
using FlatDesignApp.Models;
using FlatDesignApp.Pages.EditPages;
using Microsoft.IdentityModel.Tokens;
using System.Windows;
using System.Windows.Controls;

namespace FlatDesignApp.Pages.ViewPages;
/// <summary>
/// Логика взаимодействия для BankViewPage.xaml
/// </summary>
public partial class BankViewPage : Page
{
    public BankViewPage()
    {
        InitializeComponent();
        dgBank.ItemsSource = ObservableData.BankCollection;
    }
    private void AddButtonClick(object sender, RoutedEventArgs e) => WindowLogic.OpenPopupPage(new BankEditPage());
    private void SearchBoxTextChanged(object sender, TextChangedEventArgs e) => UpdateDGContext();
    private void DeleteButtonClick(object sender, RoutedEventArgs e)
    {
        if (WindowLogic.ConfirmDeletionShowMessage())
            DataLogic<Bank>.DeleteObjFromDb(sender, ObservableData.BankCollection);
    }

    private void EditButtonClick(object sender, RoutedEventArgs e) =>
        WindowLogic.OpenPopupPage(new BankEditPage(DataLogic<Bank>.TypeFromSender(sender)));

    private void UpdateDGContext()
    {
        IEnumerable<Bank> localContext = ObservableData.BankCollection;
        if (!searchBox.Text.IsNullOrEmpty())
        {
            localContext = ObservableData.BankCollection.Where(x => x.Name.Contains(searchBox.Text, StringComparison.OrdinalIgnoreCase));
        }
        dgBank.ItemsSource = localContext;
    }
}