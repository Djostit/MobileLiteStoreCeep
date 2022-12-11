﻿using CommunityToolkit.Maui;

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
            }).UseMauiCommunityToolkit();

        #region View

        builder.Services.AddSingleton<SingUpPage>();
        builder.Services.AddSingleton<SingInPage>();
        builder.Services.AddSingleton<ActivationPage>();
        builder.Services.AddSingleton<ReplenishmentBalancePage>();
        builder.Services.AddSingleton<StorePage>();
        builder.Services.AddSingleton<LibraryPage>();
        builder.Services.AddSingleton<SettingPage>();
        builder.Services.AddSingleton<ByuingGamePage>();
        builder.Services.AddSingleton<SuccessfulPayPage>();

        #endregion

        #region ViewModel

        builder.Services.AddSingleton<SingUpViewModel>();
        builder.Services.AddSingleton<SingInViewModel>();
        builder.Services.AddSingleton<ActivationViewModel>();
        builder.Services.AddSingleton<ReplenishmentBalanceViewModel>();
        builder.Services.AddSingleton<StoreViewModel>();
        builder.Services.AddSingleton<LibraryViewModel>();
        builder.Services.AddSingleton<SettingViewModel>();
        builder.Services.AddSingleton<ByuingGameViewModel>();
        builder.Services.AddSingleton<SuccessfulPayViewModel>();

        #endregion

        #region Service

        builder.Services.AddTransient<UserService>();

        #endregion

        return builder.Build();
    }
}
