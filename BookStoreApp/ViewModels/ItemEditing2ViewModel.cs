using Android.Webkit;
using System.Net.Http.Json;
using BookStoreApp.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using static Java.Util.Concurrent.Flow;
using System.Collections.ObjectModel;

namespace BookStoreApp.ViewModels;

public partial class ItemEditing2ViewModel : ObservableObject, IQueryAttributable
{
    private HttpClient httpClient;
    string urlGrid = "api/book";
    string urlCategory = "api/category";
    string urlAuthor = "api/author";
    string urlPublisher = "api/publisher";
    [ObservableProperty]
    private Book bookItem;
    private ObservableCollection<Category> categories;
    public ObservableCollection<Category> Categories
    {
        get => categories;
        set => SetProperty(ref categories, value); 
    }
    private ObservableCollection<Publisher> publishers;
    public ObservableCollection<Publisher> Publishers
    {
        get => publishers;
        set => SetProperty(ref publishers, value); 
    }
    private ObservableCollection<Author> authors;
    public ObservableCollection<Author> Authors
    {
        get => authors;
        set => SetProperty(ref authors, value); 
    }

    public ItemEditing2ViewModel(HttpClient httpClient)
    {
        this.httpClient = httpClient;

    }
    public async Task OnAppearing()
    {
        await loadCategory();
        await loadAuthor();
        await loadPublisher();
    }
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue("bookItem", out var value) && value is Book b)
        {
            BookItem = b;
        }
    }
    async Task loadCategory()
    {
        Categories = new ObservableCollection<Category>( await httpClient.GetFromJsonAsync<List<Category>>(urlCategory));
    }
    async Task loadAuthor()
    {
        Authors = new ObservableCollection<Author>(await httpClient.GetFromJsonAsync<List<Author>>(urlAuthor));
    }
    async Task loadPublisher()
    {
        Publishers = new ObservableCollection<Publisher>(await httpClient.GetFromJsonAsync<List<Publisher>>(urlPublisher));
    }
    [RelayCommand]
    private async Task SaveItemClickAsync()
    {
        HttpResponseMessage response;
        if(BookItem.id == Guid.Empty)
            response = await httpClient.PostAsJsonAsync(urlGrid, BookItem);
        else
           response = await httpClient.PutAsJsonAsync($"{urlGrid}/{BookItem.id}", BookItem);
        var result = await response.Content.ReadFromJsonAsync<ApiMessageResponse>();
        await Shell.Current.DisplayAlert("Notifcation",result.Message, "OK");
    }
}
