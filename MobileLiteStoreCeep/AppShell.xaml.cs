namespace MobileLiteStoreCeep;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        BindingContext = new AppShellVieModel();

        Routing.RegisterRoute(nameof(StorePage), typeof(StorePage));
        Routing.RegisterRoute(nameof(SingUpPage), typeof(SingUpPage));
        Routing.RegisterRoute(nameof(ByuingGamePage), typeof(ByuingGamePage));
    }
}
