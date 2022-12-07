namespace MobileLiteStoreCeep;

public partial class App : Application
{
	public App(SingInPage singInPage)
	{
		InitializeComponent();

		MainPage = new NavigationPage(singInPage);
	}
}
