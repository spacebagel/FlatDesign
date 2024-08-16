using FlatDesignApp.Data;
using FlatDesignApp.Methods;
using FlatDesignApp.Models;
using System.Windows;
using System.Windows.Controls;

namespace FlatDesignApp.Pages.EditPages;

/// <summary>
/// Логика взаимодействия для AddressEditPage.xaml
/// </summary>
public partial class AddressEditPage : Page
{
    public Address? EditAddress { get; set; } = null;
    public AddressEditPage()
    {
        BaseConfig();
    }

    public AddressEditPage(Address editAddress)
    {
        EditAddress = editAddress;
        DataContext = this;
        BaseConfig();
        cbCity.SelectedValue = editAddress.CityId;
    }

    private void BaseConfig()
    {
        InitializeComponent();
        cbCity.ItemsSource = ObservableData.CityCollection;
    }
    private void SaveButtonClick(object sender, RoutedEventArgs e)
    {
        var isAddressNull = EditAddress == null;

        Address currentAddress = isAddressNull ? new Address { } : App.Context.Addresses.First(x => x.Id == EditAddress.Id);
        currentAddress.StreetName = tbStreet.Text;
        currentAddress.BuildingNumber = tbBuildingNumber.Text;
        currentAddress.CityId = Convert.ToInt32(cbCity.SelectedValue);

        DataLogic<Address>.AddObjToDb(isAddressNull, App.Context.Addresses, currentAddress, ObservableData.AddressCollection,
            isAddressNull ? null : ObservableData.AddressCollection.First(x => x.Id == EditAddress.Id));
    }

    private void CancelButtonClick(object sender, RoutedEventArgs e) =>
        NavigationService.Navigate(EditAddress == null ? new AddressEditPage() : new AddressEditPage(EditAddress));
}