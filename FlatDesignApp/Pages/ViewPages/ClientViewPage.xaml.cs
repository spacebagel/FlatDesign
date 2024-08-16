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
/// Логика взаимодействия для ClientViewPage.xaml
/// </summary>
public partial class ClientViewPage : Page
{
    public ClientViewPage()
    {
        InitializeComponent();
        dgClient.ItemsSource = ObservableData.ClientCollection;

        var countryWithAll = new ObservableCollection<ClientType>(ObservableData.ClientTypeCollection);
        countryWithAll.Insert(0, new ClientType { Name = "All", Id = 0 });
        cbCountry.ItemsSource = countryWithAll;
        ObservableData.BankDetailCollection.CollectionChanged += (s, e) =>
        {
            countryWithAll.Clear();
            countryWithAll.Add(new ClientType { Name = "All", Id = 0 });
            foreach (var type in ObservableData.ClientTypeCollection)
            {
                countryWithAll.Add(type);
            }
        };
    }
    private void AddButtonClick(object sender, RoutedEventArgs e) => WindowLogic.OpenPopupPage(new ClientEditPage());
    private void SearchBoxTextChanged(object sender, TextChangedEventArgs e) => UpdateDGContext();
    private void FilterSelectionChanged(object sender, SelectionChangedEventArgs e) => UpdateDGContext();
    private void DeleteButtonClick(object sender, RoutedEventArgs e)
    {
        if (WindowLogic.ConfirmDeletionShowMessage())
            DataLogic<Client>.DeleteObjFromDb(sender, ObservableData.ClientCollection);
    }

    private void EditButtonClick(object sender, RoutedEventArgs e) =>
        WindowLogic.OpenPopupPage(new ClientEditPage(DataLogic<Client>.TypeFromSender(sender)));

    private void UpdateDGContext()
    {
        IEnumerable<Client> localContext = ObservableData.ClientCollection;
        if (!searchBox.Text.IsNullOrEmpty())
        {
            localContext = ObservableData.ClientCollection.Where(x => x.Name.Contains(searchBox.Text, StringComparison.OrdinalIgnoreCase)
            || (x.BankDetail != null && x.BankDetail.DisplayName.Contains(searchBox.Text, StringComparison.OrdinalIgnoreCase))
            || (x.Type != null && x.Type.Name.Contains(searchBox.Text, StringComparison.OrdinalIgnoreCase))
            || (x.IdentityDocument != null && x.IdentityDocument.Contains(searchBox.Text, StringComparison.OrdinalIgnoreCase))
            || (x.Address != null && x.Address.DisplayName.Contains(searchBox.Text, StringComparison.OrdinalIgnoreCase)));
        }
        if (cbCountry.SelectedItem != null && cbCountry.SelectedIndex != 0)
        {
            localContext = localContext.Where(x => x.TypeId == Convert.ToInt32(cbCountry.SelectedValue));
        }
        dgClient.ItemsSource = localContext;
    }
}