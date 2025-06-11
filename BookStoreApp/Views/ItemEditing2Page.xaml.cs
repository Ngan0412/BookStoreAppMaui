using BookStoreApp.ViewModels;

namespace BookStoreApp.Views;

public partial class ItemEditing2Page : ContentPage
{
    public ItemEditing2Page()
    {
        InitializeComponent();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is ItemEditing2ViewModel vm)
        {
            await vm.OnAppearing();
        }
    }
}