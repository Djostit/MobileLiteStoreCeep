namespace MobileLiteStoreCeep.Views;

public partial class SingInPage : ContentPage
{
    public SingInPage(SingInViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
