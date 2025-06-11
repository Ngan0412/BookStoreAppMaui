using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BookStoreApp.Services;

public interface IAuthenticationService
{
    Task<bool> Login(string username, string password);
    //Task<bool> Register(Staff staffModel);
    Task Logout();
}

public class AuthenticationService : IAuthenticationService
{

    private HttpClient _httpClient;
   
    public AuthenticationService(
        HttpClient httpClient
  
    )
    {
        _httpClient = httpClient;
    }

    public async Task<bool> Login(string username, string password)
    {
        try
        {
            LoginModel login = new();
            {
                login.Email = username;
                login.Password = password;
            }
        ;
            var response = await _httpClient.PostAsJsonAsync("api/auth/login", login);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var json = await response.Content.ReadAsStringAsync();
                var doc = JsonDocument.Parse(json);
                var token = doc.RootElement.GetProperty("token").GetString();
                _httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                // Handle successbook
                return true;
            }
            return false;
        }
        catch (Exception e)
        {
            return false;
        }

    }

    public async Task Logout()
    {
        //User = null;
        //_httpClient.DefaultRequestHeaders.Authorization = null;
        //_navigationManager.NavigateTo("");
    }

    //public async Task<bool> Register(Staff staffModel)
    //{
    //    try
    //    {
    //        if (staffModel != null)
    //        {
    //            var response = await _httpClient.PostAsJsonAsync("api/auth/register", staffModel);
    //            var errorContent = await response.Content.ReadAsStringAsync();
    //            Console.WriteLine($"Login failed. Status: {response.StatusCode}, Details: {errorContent}");
    //            if (response.StatusCode == HttpStatusCode.OK)
    //            {
    //                return true;
    //            }
    //            return false;
    //        }

    //        return false;
    //    }
    //    catch (Exception e)
    //    {
    //        return false;
    //    }
    //}
}
public class LoginModel
{
    public string Email { get; set; }
    public string Password { get; set; }
}