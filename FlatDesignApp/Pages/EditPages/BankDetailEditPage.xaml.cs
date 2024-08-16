using FlatDesignApp.Data;
using FlatDesignApp.Methods;
using FlatDesignApp.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace FlatDesignApp.Pages.EditPages;

/// <summary>
/// Логика взаимодействия для BankDetailEditPage.xaml
/// </summary>
public partial class BankDetailEditPage : Page
{
    public BankDetail? EditBankDetail { get; set; } = null;
    public BankDetailEditPage()
    {
        BaseConfig();
    }
    public BankDetailEditPage(BankDetail editBankDetail)
    {
        EditBankDetail = editBankDetail;
        DataContext = this;
        BaseConfig();
        cbBank.SelectedValue = editBankDetail.BankId;
    }

    private void BaseConfig()
    {
        InitializeComponent();
        cbBank.ItemsSource = ObservableData.BankCollection;
    }

    private void SaveButtonClick(object sender, RoutedEventArgs e)
    {
        var isBankDetailNull = EditBankDetail == null;

        BankDetail currentBankDetail = isBankDetailNull ? new BankDetail { } : App.Context.BankDetails.First(x => x.Id == EditBankDetail.Id);
        currentBankDetail.BankId = Convert.ToInt32(cbBank.SelectedValue);
        currentBankDetail.Number = tbNumber.Text;

        DataLogic<BankDetail>.AddObjToDb(isBankDetailNull, App.Context.BankDetails, currentBankDetail, ObservableData.BankDetailCollection,
            isBankDetailNull ? null : ObservableData.BankDetailCollection.First(x => x.Id == EditBankDetail.Id));
    }

    private void CancelButtonClick(object sender, RoutedEventArgs e) =>
        NavigationService.Navigate(EditBankDetail == null ? new BankDetailEditPage() : new BankDetailEditPage(EditBankDetail));
}