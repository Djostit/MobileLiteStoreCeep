namespace MobileLiteStoreCeep.Views;

public partial class SuccessfulPayPage : ContentPage
{
	public SuccessfulPayPage(SuccessfulPayViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
