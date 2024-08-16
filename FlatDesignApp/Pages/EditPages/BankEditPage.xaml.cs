using FlatDesignApp.Data;
using FlatDesignApp.Methods;
using FlatDesignApp.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace FlatDesignApp.Pages.EditPages;

/// <summary>
/// Логика взаимодействия для BankEditPage.xaml
/// </summary>
public partial class BankEditPage : Page
{
    public Bank? EditBank { get; set; } = null;
    public BankEditPage()
    {
        InitializeComponent();
    }
    public BankEditPage(Bank editBank)
    {
        EditBank = editBank;
        DataContext = this;
        InitializeComponent();
    }
    private void SaveButtonClick(object sender, RoutedEventArgs e)
    {
        var isBankNull = EditBank == null;

        Bank currentBank = isBankNull ? new Bank { } : App.Context.Banks.First(x => x.Id == EditBank.Id);
        currentBank.Name = tbBankName.Text;

        DataLogic<Bank>.AddObjToDb(isBankNull, App.Context.Banks, currentBank, ObservableData.BankCollection,
            isBankNull ? null : ObservableData.BankCollection.First(x => x.Id == EditBank.Id));
    }

    private void CancelButtonClick(object sender, RoutedEventArgs e) =>
        NavigationService.Navigate(EditBank == null ? new BankEditPage() : new BankEditPage(EditBank));
}