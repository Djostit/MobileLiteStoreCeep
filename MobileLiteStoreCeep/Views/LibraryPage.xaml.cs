namespace MobileLiteStoreCeep.Views;

public partial class LibraryPage : ContentPage
{
    LibraryViewModel ViewModel;

    public LibraryPage(LibraryViewModel viewModel)
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
