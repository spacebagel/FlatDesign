using FlatDesignApp.Data;
using FlatDesignApp.Methods;
using FlatDesignApp.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace FlatDesignApp.Pages.EditPages;

/// <summary>
/// Логика взаимодействия для CityEditPage.xaml
/// </summary>
public partial class CityEditPage : Page
{
    public City? EditCity { get; set; } = null;
    public CityEditPage()
    {
        BaseConfig();
    }

    public CityEditPage(City editCity)
    {
        EditCity = editCity;
        DataContext = this;
        BaseConfig();
        cbCountry.SelectedValue = editCity.CountryId;
    }

    private void BaseConfig()
    {
        InitializeComponent();
        cbCountry.ItemsSource = ObservableData.CountryCollection;
    }

    private void SaveButtonClick(object sender, RoutedEventArgs e)
    {
        var isCityNull = EditCity == null;

        City currentCity = isCityNull ? new City { } : App.Context.Cities.First(x => x.Id == EditCity.Id);
        currentCity.Name = tbCityName.Text;
        currentCity.CountryId = Convert.ToInt32(cbCountry.SelectedValue);

        DataLogic<City>.AddObjToDb(isCityNull, App.Context.Cities, currentCity, ObservableData.CityCollection,
            isCityNull ? null : ObservableData.CityCollection.First(x => x.Id == EditCity.Id));
    }

    private void CancelButtonClick(object sender, RoutedEventArgs e) =>
        NavigationService.Navigate(EditCity == null ? new CityEditPage() : new CityEditPage(EditCity));
}