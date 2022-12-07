namespace MobileLiteStoreCeep.ViewModels;

[QueryProperty(nameof(Item), "Item")]
public partial class StoreDetailViewModel : BaseViewModel
{
    [ObservableProperty]
    SampleItem item;
}
