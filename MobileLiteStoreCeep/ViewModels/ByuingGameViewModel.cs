namespace MobileLiteStoreCeep.ViewModels;

public partial class ByuingGameViewModel : BaseViewModel
{
    [ObservableProperty]
    private string username = Global.CurrentUser.Username;

    [ObservableProperty]
    private string title = Global.CurrentGame.Title;

    [ObservableProperty]
    private string image = Global.CurrentGame.Image;

    [ObservableProperty]
    private string description = Global.CurrentGame.Description;

    [ObservableProperty]
    private string price = Global.CurrentGame.Price;

    private readonly KeyService _keyService;
    public ByuingGameViewModel(KeyService keyService)
    {
        _keyService = keyService;
    }

    [RelayCommand]
    public async Task BuyGame()
    {
        Global.CurrentUser.Balance -= int.Parse(Price.Split(' ')[0]);
        Global.Key = await _keyService.CreateKey(Global.CurrentGame.Id);
        Shell.Current.FlyoutHeader = new FloyoutHeaderControl();

        await Shell.Current.GoToAsync(nameof(SuccessfulPayPage));
    }
}
