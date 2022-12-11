using CommunityToolkit.Maui;

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

        builder.Services.AddSingleton<MainViewModel>();

        builder.Services.AddSingleton<MainPage>();

        builder.Services.AddSingleton<SingUpViewModel>();

        builder.Services.AddSingleton<SingUpPage>();

        builder.Services.AddSingleton<SingInViewModel>();

        builder.Services.AddTransient<UserService>();

        builder.Services.AddSingleton<SingInPage>();

        builder.Services.AddSingleton<ActivationViewModel>();

        builder.Services.AddSingleton<ActivationPage>();

        builder.Services.AddSingleton<ReplenishmentBalanceViewModel>();

        builder.Services.AddSingleton<ReplenishmentBalancePage>();

		builder.Services.AddTransient<SampleDataService>();
		builder.Services.AddTransient<StoreDetailViewModel>();
		builder.Services.AddTransient<StoreDetailPage>();

        builder.Services.AddSingleton<StoreViewModel>();

        builder.Services.AddSingleton<StorePage>();

		builder.Services.AddTransient<SampleDataService>();
		builder.Services.AddTransient<LibraryDetailViewModel>();
		builder.Services.AddTransient<LibraryDetailPage>();

        builder.Services.AddSingleton<LibraryViewModel>();

        builder.Services.AddSingleton<LibraryPage>();

        builder.Services.AddSingleton<SettingViewModel>();

        builder.Services.AddSingleton<SettingPage>();

        builder.Services.AddSingleton<ByuingGameViewModel>();

        builder.Services.AddSingleton<ByuingGamePage>();

        builder.Services.AddSingleton<SuccessfulPayViewModel>();

        builder.Services.AddSingleton<SuccessfulPayPage>();

        builder.Services.AddTransient<NavigationService>();

        return builder.Build();
	}
}
