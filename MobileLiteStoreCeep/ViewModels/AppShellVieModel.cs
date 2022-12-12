using System.Globalization;

namespace MobileLiteStoreCeep.ViewModels
{
    public partial class AppShellVieModel : BaseViewModel
    {
        [RelayCommand]
        async Task SignOut()
        {
            await UserService.SaveCurrentUserAsync();
            Global.CurrentUser = null;

            await Shell.Current.GoToAsync($"//{nameof(SingInPage)}");
        }
    }
}
