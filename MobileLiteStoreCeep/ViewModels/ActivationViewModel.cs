namespace MobileLiteStoreCeep.ViewModels;

public partial class ActivationViewModel : BaseViewModel
{
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(ActivateCommand))]
    private string key;

    [ObservableProperty]
    private string errorMessage;

    private readonly KeyService _keyService;
    public ActivationViewModel(KeyService keyService)
    {
        _keyService = keyService;
        if (Global.Key is not null)
        {
            Key = Global.Key;
            Global.Key = null;
        }
    }

    [RelayCommand(CanExecute = nameof(CanActivate))]
    public async Task Activate()
    {
        if (await _keyService.ActivateKey(Key))
        {
            Global.CurrentUser.Games.Add(new UserGames
            {
                Id = await _keyService.FindIdGame(Key)
            });
            ErrorMessage = string.Empty;
            await Task.Delay(1500);
        }
        else
            ErrorMessage = "Неверный ключ или игра уже активирована";
    }
    private bool CanActivate() => Key is not null && !Key.Contains(" ") && Key.Length == 29;
}
