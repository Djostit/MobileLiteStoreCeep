namespace MobileLiteStoreCeep.Views;

public partial class SingUpPage : ContentPage
{
	public SingUpPage(SingUpViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
