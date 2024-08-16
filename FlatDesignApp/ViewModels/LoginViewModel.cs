using FlatDesignApp.Methods;
using FlatDesignApp.Windows;
using System.Windows;
using System.Windows.Input;

namespace FlatDesignApp.ViewModels;

public class LoginViewModel : ViewModelBase
{
    private string _userName;
    private string _password;
    private string _error;
    private bool _isViewVisible = true;

    public string UserName
    {
        get => _userName; set
        {
            _userName = value;
            OnPropertyChanged(nameof(UserName));
        }
    }
    public string Password
    {
        get => _password; set
        {
            _password = value;
            OnPropertyChanged(nameof(Password));
        }
    }
    public string Error
    {
        get => _error; set
        {
            _error = value;
            OnPropertyChanged(nameof(Error));
        }
    }

    public ICommand LoginCommand { get; }
    public ICommand RememberPasswordCommand { get; }
    public bool IsViewVisible
    {
        get => _isViewVisible; set
        {
            _isViewVisible = value;
            OnPropertyChanged(nameof(IsViewVisible));
        }
    }

    public LoginViewModel()
    {
        LoginCommand = new ViewModelCommand(ExecutedLoginCommand, CanExecuteLoginCommand);
    }

    private bool CanExecuteLoginCommand(object obj) => !(string.IsNullOrWhiteSpace(UserName) || UserName.Length < 3 || Password == null || Password.Length < 3);

    private async void ExecutedLoginCommand(object obj)
    {
        if (await AuthUser.CheckUser(UserName, Password))
        {
            IsViewVisible = false;
            new MainWindow().Show();
        }
        else
        {
            Error = "Incorrect data";
            MessageBox.Show(Error);
        }
    }
}
