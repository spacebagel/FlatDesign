using FlatDesignApp.Data;
using FlatDesignApp.Methods;
using FlatDesignApp.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace FlatDesignApp.Pages.EditPages;

/// <summary>
/// Логика взаимодействия для CountryEditPage.xaml
/// </summary>
public partial class CountryEditPage : Page
{
    public Country? EditCountry { get; set; } = null;
    public CountryEditPage()
    {
        InitializeComponent();
    }

    public CountryEditPage(Country editCountry)
    {
        EditCountry = editCountry;
        DataContext = this;
        InitializeComponent();
    }
    private void SaveButtonClick(object sender, RoutedEventArgs e)
    {
        var isCountryNull = EditCountry == null;

        Country currentCountry = isCountryNull ? new Country { } : App.Context.Countries.First(x => x.Id == EditCountry.Id);
        currentCountry.Name = tbCountryName.Text;

        DataLogic<Country>.AddObjToDb(isCountryNull, App.Context.Countries, currentCountry, ObservableData.CountryCollection,
            isCountryNull ? null : ObservableData.CountryCollection.First(x => x.Id == EditCountry.Id));

        Window.GetWindow(this)?.Hide();
    }

    private void CancelButtonClick(object sender, RoutedEventArgs e) =>
        NavigationService.Navigate(EditCountry == null ? new CountryEditPage() : new CountryEditPage(EditCountry));
}