using FlatDesignApp.Data;
using FlatDesignApp.Methods;
using FlatDesignApp.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace FlatDesignApp.Pages.EditPages;

/// <summary>
/// Логика взаимодействия для ClientEditPage.xaml
/// </summary>
public partial class ClientEditPage : Page
{
    public Client? EditClient { get; set; } = null;
    public ClientEditPage()
    {
        BaseConfig();
    }
    public ClientEditPage(Client editClient)
    {
        EditClient = editClient;
        DataContext = this;
        BaseConfig();
        cbAddress.SelectedValue = editClient.AddressId;
        cbBankDetails.SelectedValue = editClient.BankDetailId;
        cbClientType.SelectedValue = editClient.TypeId;
    }

    private void BaseConfig()
    {
        InitializeComponent();
        cbAddress.ItemsSource = ObservableData.AddressCollection;
        cbBankDetails.ItemsSource = ObservableData.BankDetailCollection;
        cbClientType.ItemsSource = ObservableData.ClientTypeCollection;
    }

    private void SaveButtonClick(object sender, RoutedEventArgs e)
    {
        var isClientNull = EditClient == null;

        Client currentClient = isClientNull ? new Client { } : App.Context.Clients.First(x => x.Id == EditClient.Id);
        currentClient.AddressId = Convert.ToInt32(cbAddress.SelectedValue);
        currentClient.BankDetailId = Convert.ToInt32(cbBankDetails.SelectedValue);
        currentClient.Name = tbName.Text;
        currentClient.IdentityDocument = tbDocument.Text;
        currentClient.TypeId = Convert.ToInt32(cbClientType.SelectedValue);


        DataLogic<Client>.AddObjToDb(isClientNull, App.Context.Clients, currentClient, ObservableData.ClientCollection,
            isClientNull ? null : ObservableData.ClientCollection.First(x => x.Id == EditClient.Id));
    }

    private void CancelButtonClick(object sender, RoutedEventArgs e) =>
        NavigationService.Navigate(EditClient == null ? new ClientEditPage() : new ClientEditPage(EditClient));
}