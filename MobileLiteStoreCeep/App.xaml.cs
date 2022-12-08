﻿namespace MobileLiteStoreCeep;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        MainPage = new NavigationPage();
        MainPage.Navigation.PushAsync(new SingUpPage(new SingUpViewModel(new UserService())));
    }
}
