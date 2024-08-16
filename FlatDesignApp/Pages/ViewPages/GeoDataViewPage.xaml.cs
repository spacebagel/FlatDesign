using FlatDesignApp.Data;
using FlatDesignApp.Methods;
using FlatDesignApp.Models;
using FlatDesignApp.Pages.EditPages;
using Microsoft.IdentityModel.Tokens;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace FlatDesignApp.Pages.ViewPages;
/// <summary>
/// Логика взаимодействия для GeoDataViewPage.xaml
/// </summary>
public partial class GeoDataViewPage : Page
{
    public GeoDataViewPage()
    {
        InitializeComponent();
        dgCity.ItemsSource = ObservableData.CityCollection;
        dgCountry.ItemsSource = ObservableData.CountryCollection;
    }
    private void AddCityButtonClick(object sender, RoutedEventArgs e) => WindowLogic.OpenPopupPage(new CityEditPage());
    private void SearchCityBoxTextChanged(object sender, TextChangedEventArgs e) => UpdateCityDGContext();
    private void DeleteCityButtonClick(object sender, RoutedEventArgs e)
    {
        if (WindowLogic.ConfirmDeletionShowMessage())
            DataLogic<City>.DeleteObjFromDb(sender, ObservableData.CityCollection);
    }

    private void AddCountryButtonClick(object sender, RoutedEventArgs e) => WindowLogic.OpenPopupPage(new CountryEditPage());
    private void SearchCountryBoxTextChanged(object sender, TextChangedEventArgs e) => UpdateCountryDGContext();
    private void DeleteCountryButtonClick(object sender, RoutedEventArgs e)
    {
        if (WindowLogic.ConfirmDeletionShowMessage())
        {
            DataLogic<Country>.DeleteObjFromDb(sender, ObservableData.CountryCollection);
            NavigationService.Navigate(new GeoDataViewPage());
        }
    }

    private void EditCityButtonClick(object sender, RoutedEventArgs e) =>
        WindowLogic.OpenPopupPage(new CityEditPage(DataLogic<City>.TypeFromSender(sender)));

    private void EditCountryButtonClick(object sender, RoutedEventArgs e)
    {
        WindowLogic.OpenPopupPage(new CountryEditPage(DataLogic<Country>.TypeFromSender(sender)));
        NavigationService.Navigate(new GeoDataViewPage());
    }

    private void UpdateCityDGContext()
    {
        IEnumerable<City> localContext = ObservableData.CityCollection;
        if (!searchBoxCity.Text.IsNullOrEmpty())
        {
            localContext = ObservableData.CityCollection.Where(x => x.Name.Contains(searchBoxCity.Text, StringComparison.OrdinalIgnoreCase) || (x.Country != null && x.Country.Name.Contains(searchBoxCity.Text, StringComparison.OrdinalIgnoreCase)));
        }
        dgCity.ItemsSource = localContext;
    }

    private void UpdateCountryDGContext()
    {
        IEnumerable<Country> localContext = ObservableData.CountryCollection;
        if (!searchBoxCountry.Text.IsNullOrEmpty())
        {
            localContext = ObservableData.CountryCollection.Where(x => x.Name.Contains(searchBoxCountry.Text, StringComparison.OrdinalIgnoreCase));
        }
        dgCountry.ItemsSource = localContext;
    }
}