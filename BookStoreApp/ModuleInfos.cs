using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreApp.ViewModels;
using BookStoreApp.Views;

namespace BookStoreApp;

public static class ModuleInfos
{

    public static readonly ModuleInfo LoginPage = new ModuleInfo("Login", "LoginForm2Page", typeof(LoginForm2Page), typeof(LoginForm2ViewModel));
    public static readonly ModuleInfo ListPage = new ModuleInfo("List", "ListSimplePage", typeof(ListSimplePage), typeof(ListSimpleViewModel));
    public static readonly ModuleInfo DetailForm = new ModuleInfo("DetailForm", "DetailFormPage", typeof(DetailForm4Page), typeof(DetailForm4ViewModel));
    public static readonly ModuleInfo ItemEdit = new ModuleInfo("ItemEdit", "ItemEditPage", typeof(ItemEditing2Page), typeof(ItemEditing2ViewModel));



    public static readonly ModuleInfo[] Pages = new[] {
    LoginPage,ListPage, DetailForm,ItemEdit
    };
    public static readonly ModuleInfo[] All = Pages.ToArray();
    public static readonly PopupModuleInfo[] Popups = Array.Empty<PopupModuleInfo>();

    public static ModuleInfo GetModuleInfoByViewType(Type viewType)
    {
        return All.First(x => x.ViewType == viewType);
    }
}

public class ModuleInfo
{
    public string Title { get; }
    public string Route { get; }
    public Type ViewType { get; }
    public Type ViewModelType { get; }

    public ModuleInfo(string title, string route, Type viewType, Type viewModelType)
    {
        Title = title;
        Route = route;
        ViewType = viewType;
        ViewModelType = viewModelType;
    }
}
public class PopupModuleInfo
{
    public Type ViewType { get; }
    public Type ViewModelType { get; }

    public PopupModuleInfo(Type viewType, Type viewModelType)
    {
        ViewType = viewType;
        ViewModelType = viewModelType;
    }
}