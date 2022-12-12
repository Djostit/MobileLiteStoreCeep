namespace MobileLiteStoreCeep.ViewModels;

public partial class LibraryViewModel : BaseViewModel
{
    [ObservableProperty]
    bool isRefreshing;

    [ObservableProperty]
    ObservableCollection<SampleItem> items;

    public LibraryViewModel()
    {

    }

    [RelayCommand]
    private async void OnRefreshing()
    {
        IsRefreshing = true;

        try
        {
            await LoadDataAsync();
        }
        finally
        {
            IsRefreshing = false;
        }
    }

    [RelayCommand]
    public async Task LoadMore()
    {
    }

    public async Task LoadDataAsync()
    {
    }

    [RelayCommand]
    private async void GoToDetails(SampleItem item)
    {
    }
}
