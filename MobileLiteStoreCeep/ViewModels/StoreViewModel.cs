namespace MobileLiteStoreCeep.ViewModels;

public partial class StoreViewModel : BaseViewModel
{
   // readonly SampleDataService dataService;

    [ObservableProperty]
    bool isRefreshing;

    [ObservableProperty]
    ObservableCollection<SampleItem> items;

    //public StoreViewModel(SampleDataService service)
    //{
    //    dataService = service;
    //}

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
        //var items = await dataService.GetItems();

        //foreach (var item in items)
        //{
        //    Items.Add(item);
        //}
    }

    public async Task LoadDataAsync()
    {
       //Items = new ObservableCollection<SampleItem>(await dataService.GetItems());
    }

    [RelayCommand]
    private async void GoToDetails(SampleItem item)
    {
        //await Shell.Current.GoToAsync(nameof(StoreDetailPage), true, new Dictionary<string, object>
        //{
        //    { "Item", item }
        //});
    }
}
