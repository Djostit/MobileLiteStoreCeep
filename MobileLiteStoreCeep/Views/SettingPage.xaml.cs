namespace MobileLiteStoreCeep.Views;

public partial class SettingPage : ContentPage
{
	public SettingPage(SettingViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
