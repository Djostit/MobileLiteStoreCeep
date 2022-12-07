namespace MobileLiteStoreCeep.Views;

public partial class LibraryDetailPage : ContentPage
{
    public LibraryDetailPage(LibraryDetailViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
