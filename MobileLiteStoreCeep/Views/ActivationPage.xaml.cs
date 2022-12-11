namespace MobileLiteStoreCeep.Views;

public partial class ActivationPage : ContentPage
{
    public ActivationPage(ActivationViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
