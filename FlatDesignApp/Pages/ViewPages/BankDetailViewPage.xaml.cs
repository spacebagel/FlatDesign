using FlatDesignApp.Data;
using FlatDesignApp.Methods;
using FlatDesignApp.Models;
using FlatDesignApp.Pages.EditPages;
using Microsoft.IdentityModel.Tokens;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace FlatDesignApp.Pages.ViewPages;

/// <summary>
/// Логика взаимодействия для BankDetailViewPage.xaml
/// </summary>
public partial class BankDetailViewPage : Page
{
    public BankDetailViewPage()
    {
        InitializeComponent();
        dgBankDetail.ItemsSource = ObservableData.BankDetailCollection;

        var bankWithAll = new ObservableCollection<Bank>(ObservableData.BankCollection);
        bankWithAll.Insert(0, new Bank { Name = "All", Id = 0 });
        cbBankName.ItemsSource = bankWithAll;
        ObservableData.BankDetailCollection.CollectionChanged += (s, e) =>
        {
            bankWithAll.Clear();
            bankWithAll.Add(new Bank { Name = "All", Id = 0 });
            foreach (var bank in ObservableData.BankCollection)
            {
                bankWithAll.Add(bank);
            }
        };
    }
    private void AddButtonClick(object sender, RoutedEventArgs e) => WindowLogic.OpenPopupPage(new BankDetailEditPage());
    private void SearchBoxTextChanged(object sender, TextChangedEventArgs e) => UpdateDGContext();
    private void FilterSelectionChanged(object sender, SelectionChangedEventArgs e) => UpdateDGContext();
    private void DeleteButtonClick(object sender, RoutedEventArgs e)
    {
        if (WindowLogic.ConfirmDeletionShowMessage())
            DataLogic<BankDetail>.DeleteObjFromDb(sender, ObservableData.BankDetailCollection);
    }
    private void EditButtonClick(object sender, RoutedEventArgs e) =>
        WindowLogic.OpenPopupPage(new BankDetailEditPage(DataLogic<BankDetail>.TypeFromSender(sender)));

    private void UpdateDGContext()
    {
        IEnumerable<BankDetail> localContext = ObservableData.BankDetailCollection;
        if (!searchBox.Text.IsNullOrEmpty())
        {
            localContext = ObservableData.BankDetailCollection.Where(x => x.DisplayName.Contains(searchBox.Text, StringComparison.OrdinalIgnoreCase));
        }
        if (cbBankName.SelectedItem != null && cbBankName.SelectedIndex != 0)
        {
            localContext = localContext.Where(x => x.BankId == Convert.ToInt32(cbBankName.SelectedValue));
        }
        dgBankDetail.ItemsSource = localContext;
    }
}