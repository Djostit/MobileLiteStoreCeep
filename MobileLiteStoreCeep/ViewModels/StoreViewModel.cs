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

    partial void OnSelectedGameChanged(Game value)
    {
        //if (Global.CurrentUser.Balance < int.Parse(value.Price.Split(" ")[0]))
        //{
        //    Debug.WriteLine("пошел нахуй");
        //}
        Debug.WriteLine(Global.CurrentUser.Balance + " " + int.Parse(value.Price.Split(" ")[0]));
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
            await Task.Delay(2000);
            Games = await _gameService.GetListGame();
        }
        finally
        {
            IsRefreshing = false;
        }
    }

}
