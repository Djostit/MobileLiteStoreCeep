namespace MobileLiteStoreCeep.Views;

public partial class ByuingGamePage : ContentPage
{
    public ByuingGamePage(ByuingGameViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
