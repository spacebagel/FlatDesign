using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FlatDesignApp.Elements;

/// <summary>
/// Логика взаимодействия для PlaceholderTextBox.xaml
/// </summary>
public partial class PlaceholderTextBox : UserControl
{
    public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title",
        typeof(string), typeof(PlaceholderTextBox), new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text",
        typeof(string), typeof(PlaceholderTextBox), new PropertyMetadata(string.Empty));

    public string? Title
    {
        get => (string?)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public string? Text
    {
        get => (string?)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public PlaceholderTextBox()
    {
        InitializeComponent();
        TxtBox.TextChanged += TextBoxTextChanged;
    }

    private void LostElementFocus(object sender, KeyboardFocusChangedEventArgs e)
    {
        if (string.IsNullOrEmpty(TxtBox.Text))
        {
            textBoxPlaceholder.VerticalAlignment = VerticalAlignment.Center;
            textBoxPlaceholder.FontSize = 13;
        }
    }

    private void GotElementFocus(object sender, KeyboardFocusChangedEventArgs e) => SmallTopText();

    private void BorderLoaded(object sender, RoutedEventArgs e)
    {
        if (!string.IsNullOrEmpty(TxtBox.Text)) SmallTopText();
    }

    private void SmallTopText()
    {
        textBoxPlaceholder.VerticalAlignment = VerticalAlignment.Top;
        textBoxPlaceholder.FontSize = 11;
    }

    private void TextBoxTextChanged(object sender, TextChangedEventArgs e)
    {
        Text = TxtBox.Text;
    }
}