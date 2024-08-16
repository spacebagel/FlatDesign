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
/// Логика взаимодействия для AddressViewPage.xaml
/// </summary>
public partial class AddressViewPage : Page
{
    public AddressViewPage()
    {
        InitializeComponent();
        dgAddress.ItemsSource = ObservableData.AddressCollection;

        var countriesWithAll = new ObservableCollection<Country>(ObservableData.CountryCollection);
        countriesWithAll.Insert(0, new Country { Name = "All", Id = 0 });
        cbCountry.ItemsSource = countriesWithAll;
        ObservableData.CountryCollection.CollectionChanged += (s, e) =>
        {
            countriesWithAll.Clear();
            countriesWithAll.Add(new Country { Name = "All", Id = 0 });
            foreach (var country in ObservableData.CountryCollection)
            {
                countriesWithAll.Add(country);
            }
        };
    }

    private void AddButtonClick(object sender, RoutedEventArgs e) => WindowLogic.OpenPopupPage(new AddressEditPage());
    private void SearchBoxTextChanged(object sender, TextChangedEventArgs e) => UpdateDGContext();
    private void FilterSelectionChanged(object sender, SelectionChangedEventArgs e) => UpdateDGContext();

    private void DeleteButtonClick(object sender, RoutedEventArgs e)
    {
        if (WindowLogic.ConfirmDeletionShowMessage())
            DataLogic<Address>.DeleteObjFromDb(sender, ObservableData.AddressCollection);
    }

    private void EditButtonClick(object sender, RoutedEventArgs e) =>
        WindowLogic.OpenPopupPage(new AddressEditPage(DataLogic<Address>.TypeFromSender(sender)));

    private void UpdateDGContext()
    {
        IEnumerable<Address> localContext = ObservableData.AddressCollection;
        if (!searchBox.Text.IsNullOrEmpty())
        {
            localContext = ObservableData.AddressCollection.Where(x => x.DisplayName.Contains(searchBox.Text, StringComparison.OrdinalIgnoreCase));
        }
        if (cbCountry.SelectedItem != null && cbCountry.SelectedIndex != 0)
        {
            localContext = localContext.Where(x => x.City != null && x.City.CountryId == Convert.ToInt32(cbCountry.SelectedValue));
        }
        dgAddress.ItemsSource = localContext;
    }
}