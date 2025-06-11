using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BookStoreApp.ViewModels;

public partial class SettingsForm1ViewModel : ObservableObject {

    [ObservableProperty]
    private bool darkMode = Application.Current?.RequestedTheme == AppTheme.Dark;

    [ObservableProperty]
    private string language = "English";

    [ObservableProperty]
    private IEnumerable<string> languages = new List<string> { 
        "English", "German", "French", "Spanish", "Italian" 
    };


    [RelayCommand]
    async Task HandleActionAsync() {
        await Shell.Current.DisplayAlert("Action", "Action executed", "OK");
    }
    partial void OnDarkModeChanged(bool value) {
        if (Application.Current == null)
            return;

        Application.Current.UserAppTheme = value ? AppTheme.Dark : AppTheme.Light;
    }
}