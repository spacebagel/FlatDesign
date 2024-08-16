using FlatDesignApp.Data;
using FlatDesignApp.Methods;
using FlatDesignApp.Models;
using System.Windows;
using System.Windows.Controls;

namespace FlatDesignApp.Pages.EditPages;

/// <summary>
/// Логика взаимодействия для CategoryEditPage.xaml
/// </summary>
public partial class CategoryEditPage : Page
{
    public Category? EditCategory { get; set; } = null;
    public CategoryEditPage()
    {
        InitializeComponent();

    }
    public CategoryEditPage(Category editCategory)
    {
        EditCategory = editCategory;
        DataContext = this;
        InitializeComponent();
    }

    private void SaveButtonClick(object sender, RoutedEventArgs e)
    {
        var isCategoryNull = EditCategory == null;

        Category currentCategory = isCategoryNull ? new Category { } : App.Context.Categories.First(x => x.Id == EditCategory.Id);
        currentCategory.Name = tbCategoryName.Text;

        DataLogic<Category>.AddObjToDb(isCategoryNull, App.Context.Categories, currentCategory, ObservableData.CategoryCollection,
            isCategoryNull ? null : ObservableData.CategoryCollection.First(x => x.Id == EditCategory.Id));
    }

    private void CancelButtonClick(object sender, RoutedEventArgs e) =>
        NavigationService.Navigate(EditCategory == null ? new CategoryEditPage() : new CategoryEditPage(EditCategory));
}