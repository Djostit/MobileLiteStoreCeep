namespace MobileLiteStoreCeep.ViewModels
{
    public partial class AppShellVieModel : BaseViewModel
    {
        [RelayCommand]
        async Task SignOut()
        {
            await Shell.Current.GoToAsync($"//{nameof(SingInPage)}");
        }
    }
}
