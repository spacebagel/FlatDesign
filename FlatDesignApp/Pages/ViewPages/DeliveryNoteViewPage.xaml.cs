using FlatDesignApp.Data;
using FlatDesignApp.Methods;
using FlatDesignApp.Models;
using FlatDesignApp.Pages.EditPages;
using Microsoft.IdentityModel.Tokens;
using System.Windows;
using System.Windows.Controls;

namespace FlatDesignApp.Pages.ViewPages;

/// <summary>
/// Логика взаимодействия для DeliveryNoteViewPage.xaml
/// </summary>
public partial class DeliveryNoteViewPage : Page
{
    public DeliveryNoteViewPage()
    {
        InitializeComponent();
        dgDeliveryNote.ItemsSource = ObservableData.DeliveryNoteCollection;
    }
    private void AddButtonClick(object sender, RoutedEventArgs e) => WindowLogic.OpenPopupPage(new DeliveryNoteEditPage());
    private void SearchBoxTextChanged(object sender, TextChangedEventArgs e) => UpdateDGContext();
    private void FilterSelectionChanged(object sender, SelectionChangedEventArgs e) => UpdateDGContext();
    private void DeleteButtonClick(object sender, RoutedEventArgs e)
    {
        if (WindowLogic.ConfirmDeletionShowMessage())
            DataLogic<DeliveryNote>.DeleteObjFromDb(sender, ObservableData.DeliveryNoteCollection);
    }

    private void EditButtonClick(object sender, RoutedEventArgs e) =>
        WindowLogic.OpenPopupPage(new DeliveryNoteEditPage(DataLogic<DeliveryNote>.TypeFromSender(sender)));

    private void UpdateDGContext()
    {
        IEnumerable<DeliveryNote> localContext = ObservableData.DeliveryNoteCollection;
        if (!searchBox.Text.IsNullOrEmpty())
        {
            localContext = ObservableData.DeliveryNoteCollection.Where(x => (x.Product != null && x.Product.Name.Contains(searchBox.Text, StringComparison.OrdinalIgnoreCase))
            || (x.Address != null && x.Address.DisplayName.Contains(searchBox.Text, StringComparison.OrdinalIgnoreCase))
            || (x.Client != null && x.Client.Name.Contains(searchBox.Text, StringComparison.OrdinalIgnoreCase))
            || (x.PhoneNumber != null && x.PhoneNumber.Contains(searchBox.Text, StringComparison.OrdinalIgnoreCase)));
        }
        dgDeliveryNote.ItemsSource = localContext;
    }
}