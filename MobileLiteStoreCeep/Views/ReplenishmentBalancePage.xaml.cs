namespace MobileLiteStoreCeep.Views;

public partial class ReplenishmentBalancePage : ContentPage
{
	public ReplenishmentBalancePage(ReplenishmentBalanceViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
