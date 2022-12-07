namespace MobileLiteStoreCeep.Views;

public partial class StorePage : ContentPage
{
    StoreViewModel ViewModel;

    public StorePage(StoreViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = ViewModel = viewModel;
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        await ViewModel.LoadDataAsync();
    }
}
