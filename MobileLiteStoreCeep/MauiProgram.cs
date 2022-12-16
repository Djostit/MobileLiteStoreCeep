namespace MobileLiteStoreCeep;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("Jost.ttf", "Jost");
            }).UseMauiCommunityToolkit()
            .ConfigureLifecycleEvents(events => 
            {
#if ANDROID
                events.AddAndroid(android => android
                .OnStop(activity => SaveUser())
                .OnPause(activity => SaveUser())
                .OnDestroy(activity => SaveUser()));
#endif
                static async Task SaveUser() => await UserService.SaveCurrentUserAsync();
            });

#region View

        builder.Services.AddSingleton<SingUpPage>();
        builder.Services.AddSingleton<SingInPage>();
        builder.Services.AddTransient<ActivationPage>();
        builder.Services.AddSingleton<ReplenishmentBalancePage>();
        builder.Services.AddSingleton<StorePage>();
        builder.Services.AddSingleton<LibraryPage>();
        builder.Services.AddSingleton<SettingPage>();
        builder.Services.AddTransient<ByuingGamePage>();
        builder.Services.AddTransient<SuccessfulPayPage>();

#endregion

#region ViewModel

        builder.Services.AddSingleton<SingUpViewModel>();
        builder.Services.AddSingleton<SingInViewModel>();
        builder.Services.AddTransient<ActivationViewModel>();
        builder.Services.AddSingleton<ReplenishmentBalanceViewModel>();
        builder.Services.AddSingleton<StoreViewModel>();
        builder.Services.AddSingleton<LibraryViewModel>();
        builder.Services.AddSingleton<SettingViewModel>();
        builder.Services.AddTransient<ByuingGameViewModel>();
        builder.Services.AddTransient<SuccessfulPayViewModel>();
        builder.Services.AddSingleton<AppShellVieModel>();

#endregion

#region Service

        builder.Services.AddTransient<UserService>();
        builder.Services.AddTransient<GameService>();
        builder.Services.AddTransient<KeyService>();
#endregion

        return builder.Build();
    }
}
