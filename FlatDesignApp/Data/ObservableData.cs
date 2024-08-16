using FlatDesignApp.Models;
using System.Collections.ObjectModel;

namespace FlatDesignApp.Data;

public class ObservableData
{
    public static ObservableCollection<Address> AddressCollection = new(App.Context.Addresses);
    public static ObservableCollection<BankDetail> BankDetailCollection = new(App.Context.BankDetails);
    public static ObservableCollection<Bank> BankCollection = new(App.Context.Banks);
    public static ObservableCollection<Category> CategoryCollection = new(App.Context.Categories);
    public static ObservableCollection<City> CityCollection = new(App.Context.Cities);
    public static ObservableCollection<Client> ClientCollection = new(App.Context.Clients);
    public static ObservableCollection<ClientType> ClientTypeCollection = new(App.Context.ClientTypes);
    public static ObservableCollection<Country> CountryCollection = new(App.Context.Countries);
    public static ObservableCollection<DeliveryNote> DeliveryNoteCollection = new(App.Context.DeliveryNotes);
    public static ObservableCollection<Product> ProductCollection = new(App.Context.Products);
    public static ObservableCollection<User> UserCollection = new(App.Context.Users);
}