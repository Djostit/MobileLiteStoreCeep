namespace MobileLiteStoreCeep.ViewModels;

[QueryProperty(nameof(Item), "Item")]
public partial class LibraryDetailViewModel : BaseViewModel
{
    [ObservableProperty]
    SampleItem item;
}
