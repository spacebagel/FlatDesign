using FlatDesignApp.Data;
using FlatDesignApp.Methods;
using FlatDesignApp.Models;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace FlatDesignApp.Pages.EditPages;

/// <summary>
/// Логика взаимодействия для DeliveryNoteEditPage.xaml
/// </summary>
public partial class DeliveryNoteEditPage : Page
{
    public DeliveryNote? EditDeliveryNote { get; set; } = null;
    public DeliveryNoteEditPage()
    {
        BaseConfig();
    }
    public DeliveryNoteEditPage(DeliveryNote editDeliveryNote)
    {
        EditDeliveryNote = editDeliveryNote;
        DataContext = this;
        BaseConfig();
        cbAddress.SelectedValue = EditDeliveryNote.AddressId;
        cbClient.SelectedValue = EditDeliveryNote.ClientId;
        cbProduct.SelectedValue = EditDeliveryNote.ProductId;
    }

    private void BaseConfig()
    {
        InitializeComponent();
        cbAddress.ItemsSource = ObservableData.AddressCollection;
        cbClient.ItemsSource = ObservableData.ClientCollection;
        cbProduct.ItemsSource = ObservableData.ProductCollection;
    }

    private void SaveButtonClick(object sender, RoutedEventArgs e)
    {
        var isDeliveryNoteNull = EditDeliveryNote == null;

        DeliveryNote currentDeliveryNote = isDeliveryNoteNull ? new DeliveryNote { } : App.Context.DeliveryNotes.First(x => x.Id == EditDeliveryNote.Id);
        currentDeliveryNote.Price = Convert.ToDouble(tbPrice.Text, CultureInfo.InvariantCulture);
        currentDeliveryNote.ProductId = Convert.ToInt32(cbProduct.SelectedValue);
        currentDeliveryNote.AddressId = Convert.ToInt32(cbAddress.SelectedValue);
        currentDeliveryNote.ClientId = Convert.ToInt32(cbClient.SelectedValue);
        currentDeliveryNote.PhoneNumber = tbPhoneNumber.Text;

        DataLogic<DeliveryNote>.AddObjToDb(isDeliveryNoteNull, App.Context.DeliveryNotes, currentDeliveryNote, ObservableData.DeliveryNoteCollection,
            isDeliveryNoteNull ? null : ObservableData.DeliveryNoteCollection.First(x => x.Id == EditDeliveryNote.Id));
    }

    private void CancelButtonClick(object sender, RoutedEventArgs e) =>
        NavigationService.Navigate(EditDeliveryNote == null ? new DeliveryNoteEditPage() : new DeliveryNoteEditPage(EditDeliveryNote));
}