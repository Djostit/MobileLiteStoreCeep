namespace MobileLiteStoreCeep.Views;

public partial class StoreDetailPage : ContentPage
{
    public StoreDetailPage(StoreDetailViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
