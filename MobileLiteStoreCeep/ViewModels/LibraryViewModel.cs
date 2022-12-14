namespace MobileLiteStoreCeep.ViewModels;

public partial class LibraryViewModel : BaseViewModel
{
    private readonly GameService _gameService;

    [ObservableProperty]
    private bool isRefreshing;

    [ObservableProperty]
    private List<Game> games;

    public LibraryViewModel(GameService gameService)
    {
        _gameService = gameService;
        LoadGame();
    }

    [RelayCommand]
    public async Task LoadGame()
    {
        try
        {
            Games = _gameService.GetLibrary(Global.CurrentUser.Games);
        }
        finally
        {
            IsRefreshing = false;
        }
    }
}
