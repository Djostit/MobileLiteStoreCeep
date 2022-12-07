namespace MobileLiteStoreCeep;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(LibraryDetailPage), typeof(LibraryDetailPage));
        Routing.RegisterRoute(nameof(StoreDetailPage), typeof(StoreDetailPage));
	}
}
