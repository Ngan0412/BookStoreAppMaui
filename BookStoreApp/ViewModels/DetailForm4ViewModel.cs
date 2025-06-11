using Android.Webkit;
using BookStoreApp.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Json;
using static Java.Util.Concurrent.Flow;

namespace BookStoreApp.ViewModels;

public partial class DetailForm4ViewModel : ObservableObject, IQueryAttributable
{
    private HttpClient httpClient;


    [ObservableProperty]
    private Book bookItem = new();

    public DetailForm4ViewModel(HttpClient httpClient)
    {
        this.httpClient = httpClient;
        // Await asynchronous loading of categories, authors, and publishers
        
    }
   

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue("bookItem", out var value) && value is Book b)
        {
            BookItem = b;
        }
    }
}