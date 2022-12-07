using System.Diagnostics;

namespace MobileLiteStoreCeep.ViewModels;

public partial class SingInViewModel : BaseViewModel
{
    [ObservableProperty]
    private string username;

    [ObservableProperty]
    private string password;

    [RelayCommand]
    public void SendMessage()
    {
        Debug.WriteLine($"Your username: {Username}\nYour password: {Password}");
    }
}
