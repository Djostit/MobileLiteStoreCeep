namespace MobileLiteStoreCeep;

public partial class App : Application
{
	public App(SingInPage page)
	{
		InitializeComponent();

        MainPage = new NavigationPage(page);
    }
}
