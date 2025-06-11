using Android.Net;
using BookStoreApp.Services;
using DevExpress.Maui;
using DevExpress.Maui.Core;
using DevExpress.Maui.Mvvm;
using SkiaSharp.Views.Maui.Controls.Hosting;
using Uri = System.Uri;

namespace BookStoreApp;

public static class MauiProgram {
    public static MauiApp CreateMauiApp() {
        ThemeManager.ApplyThemeToSystemBars = true;
        var builder = MauiApp.CreateBuilder()
            .UseMauiApp<App>()
            .UseDevExpress(useLocalization: false)
            .UseDevExpressControls()
            .UseDevExpressCharts()
            .UseDevExpressTreeView()
            .UseDevExpressCollectionView()
            .UseDevExpressEditors()
            .UseDevExpressDataGrid()
            .UseDevExpressScheduler()
            .UseDevExpressGauges()
            .RegisterAppServices()
            .RegisterViewsAndViewModels()
            .UseSkiaSharp()
            .ConfigureFonts(fonts => {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("roboto-bold.ttf", "Roboto-Bold");
                fonts.AddFont("roboto-medium.ttf", "Roboto-Medium");
                fonts.AddFont("roboto-regular.ttf", "Roboto");
            });

        return builder.Build();
    }
    static MauiAppBuilder RegisterViewsAndViewModels(this MauiAppBuilder builder)
    {
        foreach (var x in ModuleInfos.All)
        {
            builder.Services
                .AddTransient(x.ViewType)
                .AddTransient(x.ViewModelType);
            Routing.RegisterRoute(x.Route, x.ViewType);
        }

        foreach (var x in ModuleInfos.Popups)
        {
            builder.Services
                .AddTransientDXPopup(x.ViewType, x.ViewModelType);
        }
        return builder;
    }
    static MauiAppBuilder RegisterAppServices(this MauiAppBuilder appBuilder)
    {
        // T?o handler b? qua l?i SSL
        var handler = new HttpClientHandler();
        handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;

        // ??ng ký HttpClient singleton v?i handler này
        appBuilder.Services.AddSingleton(sp => new HttpClient(handler)
        {
            BaseAddress = new Uri("https://10.0.2.2:7157/")
        });

        appBuilder.Services.AddSingleton<IAuthenticationService, AuthenticationService>();

        return appBuilder;
    }

}
