namespace MobileLiteStoreCeep.ViewModels;

public partial class SuccessfulPayViewModel : BaseViewModel
{
    [ObservableProperty]
    private string key = Global.Key;

    [RelayCommand]
    public async Task GoToActivate()
    {
        await Shell.Current.GoToAsync($"//{nameof(StorePage)}");
        await Shell.Current.GoToAsync(nameof(ActivationPage));
    }

    [RelayCommand]
    public async Task GetCheck()
    {
        await Shell.Current.GoToAsync($"//{nameof(StorePage)}");
    }
}
