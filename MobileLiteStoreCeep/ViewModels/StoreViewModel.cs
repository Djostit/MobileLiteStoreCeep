namespace MobileLiteStoreCeep.ViewModels;

public partial class StoreViewModel : BaseViewModel
{
    private readonly GameService _gameService;

    [ObservableProperty]
    private bool isRefreshing;

    [ObservableProperty]
    private List<Game> games;

    [ObservableProperty]
    private Game selectedGame;

    async partial void OnSelectedGameChanged(Game value)
    {
        if (Global.CurrentUser.Balance > int.Parse(value.Price.Split(" ")[0]))
        {
            await Shell.Current.GoToAsync($"//{nameof(ByuingGamePage)}");
        }
    }

    public StoreViewModel(GameService gameService)
    {
        _gameService = gameService;
        LoadGame();
    }

    [RelayCommand]
    public async Task LoadGame()
    {
        try
        {
            Games = await _gameService.GetListGame();
        }
        finally
        {
            IsRefreshing = false;
        }
    }

}
