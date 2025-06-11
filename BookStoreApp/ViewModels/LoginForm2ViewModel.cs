using Microsoft.Maui.Controls;
using BookStoreApp.Services;
using BookStoreApp.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DevExpress.Maui.Mvvm;

namespace BookStoreApp.ViewModels;

public partial class LoginForm2ViewModel : DXObservableObject
{

    private IAuthenticationService authenticationService;
    [ObservableProperty, NotifyCanExecuteChangedFor(nameof(LoginCommand))]
    string userName = string.Empty;

    [ObservableProperty, NotifyCanExecuteChangedFor(nameof(LoginCommand))]
    string password = string.Empty;

    [ObservableProperty, NotifyCanExecuteChangedFor(nameof(LoginCommand))]
    bool isBusy;

    [ObservableProperty]
    bool hasError;

    bool CanLogin => !IsBusy && !string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password);
    public LoginForm2ViewModel(IAuthenticationService authentication)
    {
        authenticationService = authentication;
    }

    [RelayCommand(CanExecute = nameof(CanLogin))]
    async Task Login() {
        IsBusy = true;
        HasError = false;
        IsBusy = false;
        if (await authenticationService.Login(userName, password))
        {
            await Shell.Current.GoToAsync($"{ModuleInfos.ListPage.Route}");
        }

    }
}