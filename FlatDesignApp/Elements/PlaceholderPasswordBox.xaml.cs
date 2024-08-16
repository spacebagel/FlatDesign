using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FlatDesignApp.Elements;
/// <summary>
/// Логика взаимодействия для PlaceholderPasswordBox.xaml
/// </summary>
public partial class PlaceholderPasswordBox : UserControl
{
    public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(nameof(Title),
        typeof(string), typeof(PlaceholderPasswordBox), new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty PasswordTextProperty = DependencyProperty.Register(nameof(PasswordText),
        typeof(string), typeof(PlaceholderPasswordBox), new PropertyMetadata(string.Empty));

    public string? Title
    {
        get => (string?)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public string? PasswordText
    {
        get => (string?)GetValue(PasswordTextProperty);
        set => SetValue(PasswordTextProperty, value);
    }
    public PlaceholderPasswordBox()
    {
        InitializeComponent();
        pBox.PasswordChanged += PasswordBoxPasswordChanged;
    }
    private void LostElementFocus(object sender, KeyboardFocusChangedEventArgs e)
    {
        if (string.IsNullOrEmpty(pBox.Password))
        {
            textBoxPlaceholder.VerticalAlignment = VerticalAlignment.Center;
            textBoxPlaceholder.FontSize = 13;
        }
    }

    private void GotElementFocus(object sender, KeyboardFocusChangedEventArgs e) => SmallTopText();

    private void BorderLoaded(object sender, RoutedEventArgs e)
    {
        if (!string.IsNullOrEmpty(pBox.Password)) SmallTopText();
    }

    private void SmallTopText()
    {
        textBoxPlaceholder.VerticalAlignment = VerticalAlignment.Top;
        textBoxPlaceholder.FontSize = 11;
    }

    private void PasswordBoxPasswordChanged(object sender, RoutedEventArgs e)
    {
        PasswordText = pBox.Password;
    }
}