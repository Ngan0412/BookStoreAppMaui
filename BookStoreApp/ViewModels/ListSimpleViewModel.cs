using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http.Json;
using Android.Webkit;
using BookStoreApp.Model;
using BookStoreApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using static Java.Util.Concurrent.Flow;

namespace BookStoreApp.ViewModels;

public partial class ListSimpleViewModel : ObservableObject {
    private HttpClient httpClient;
    string urlGrid = "api/book";

    [ObservableProperty]
    private IEnumerable<Book> items;


    public ListSimpleViewModel( HttpClient httpClient)
    {
        this.httpClient = httpClient;

    }
    public async Task OnAppearing()
    {
        await LoadData();
    }
    async Task LoadData()
    {
        var books = await httpClient.GetFromJsonAsync<List<Book>>(urlGrid);
        Items = books.Where(dt => dt.isDeleted == false).ToList();
    }
    
    [RelayCommand]
    private async Task HandleActionAsync(Book item) {
       
        await Shell.Current.GoToAsync($"{ModuleInfos.DetailForm.Route}", new Dictionary<string, object>
        {
            { "bookItem", item }
        });
    }
    [RelayCommand]
    private async Task EditAsync(Book item) {
        await Shell.Current.GoToAsync($"{ModuleInfos.ItemEdit.Route}", new Dictionary<string, object>
        {
            { "bookItem", item }
        });
    }
    [RelayCommand]
    private async Task DeleteAsync(Book item) {
        var response = await httpClient.DeleteAsync($"{urlGrid}/{item.id}");
        var result = await response.Content.ReadFromJsonAsync<ApiMessageResponse>();
        await Shell.Current.DisplayAlert("Notifcation", result.Message, "OK");
        await LoadData();
    }
    [RelayCommand]
    private async Task AddItemClickAsync() {

        await Shell.Current.GoToAsync($"{ModuleInfos.ItemEdit.Route}", new Dictionary<string, object>
        {
            { "bookItem", new Book() }
        });
    }
}
