using BB.Maui.Services;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using zz_MauiBugs.ViewModels;

namespace zz_MauiBugs
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseMauiCommunityToolkitMediaElement()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("OpenDyslexic-Regular.otf", "opendyslexic");
                });
            builder.RegisterServices();
            builder.RegisterViewsAndViewModels();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        public static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<IViewCreationService, ViewCreationService>();
            builder.Services.AddSingleton<INavService, NavService>();

            return builder;
        }

        public static MauiAppBuilder RegisterViewsAndViewModels(this MauiAppBuilder builder)
        {
            //==== Transients =====
            builder.Services.AddTransient<MainView>();
            builder.Services.AddTransient<MainViewModel>();
            builder.Services.AddTransient<Bug1View>();
            builder.Services.AddTransient<Bug1ViewModel>();
            builder.Services.AddTransient<Bug2View>();
            builder.Services.AddTransient<Bug2ViewModel>();
            builder.Services.AddTransient<Bug3View>();
            builder.Services.AddTransient<Bug3ViewModel>();
            builder.Services.AddTransient<Bug4View>();
            builder.Services.AddTransient<Bug4ViewModel>();
            builder.Services.AddTransient<Bug5View>();
            builder.Services.AddTransient<Bug5ViewModel>();
            builder.Services.AddTransient<Bug6View>();
            builder.Services.AddTransient<Bug6ViewModel>();
            builder.Services.AddTransient<Bug7View>();
            builder.Services.AddTransient<Bug7ViewModel>();
            builder.Services.AddTransient<Bug8View>();
            builder.Services.AddTransient<Bug8ViewModel>();
            builder.Services.AddTransient<Bug9View>();
            builder.Services.AddTransient<Bug9ViewModel>();
            builder.Services.AddTransient<Bug10View>();
            builder.Services.AddTransient<Bug10ViewModel>();
            builder.Services.AddTransient<Bug11View>();
            builder.Services.AddTransient<Bug11ViewModel>();
            builder.Services.AddTransient<Bug12View>();
            builder.Services.AddTransient<Bug12ViewModel>();
            builder.Services.AddTransient<Bug13View>();
            builder.Services.AddTransient<Bug13ViewModel>();
            builder.Services.AddTransient<Bug14View>();
            builder.Services.AddTransient<Bug14ViewModel>();
            builder.Services.AddTransient<Bug15View>();
            builder.Services.AddTransient<Bug15ViewModel>();
            builder.Services.AddTransient<Bug16View>();
            builder.Services.AddTransient<Bug16ViewModel>();
            builder.Services.AddTransient<Bug17View>();
            builder.Services.AddTransient<Bug17ViewModel>();

            //==== Singletons =====

            return builder;
        }
    }
}