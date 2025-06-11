using BookStoreApp.ViewModels;

namespace BookStoreApp.Views;

public partial class ListSimplePage : ContentPage
{
    public ListSimplePage()
    {
        InitializeComponent();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is ListSimpleViewModel vm)
        {
            await vm.OnAppearing();
        }
    }
}