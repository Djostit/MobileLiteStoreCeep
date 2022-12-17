using MobileLiteStoreCeep.Models;
using Newtonsoft.Json;
using System.Globalization;

namespace MobileLiteStoreCeep.ViewModels;

public partial class SingUpViewModel : BaseViewModel
{
    private static List<string> Counrtyy { get; set; } = new();

    [ObservableProperty]
    private List<string> listCountry;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SingUpCommand))]
    private DateTime dateStart = DateTime.Now.AddYears(-100);

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SingUpCommand))]
    private DateTime dateEnd = DateTime.Now.AddYears(-7);

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SingUpCommand))]
    private string selectedCounrty;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SingUpCommand))]
    private string name;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SingUpCommand))]
    private string lastName;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SingUpCommand))]
    private string birthday;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SingUpCommand))]
    private string username;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SingUpCommand))]
    private string password;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SingUpCommand))]
    private string repeatPassword;

    [ObservableProperty]
    private string errorMessageCounrty;

    [ObservableProperty]
    private string errorMessageName;

    [ObservableProperty]
    private string errorMessageLastName;

    [ObservableProperty]
    private string errorMessageBirthday;

    [ObservableProperty]
    private string errorMessageUsername;

    [ObservableProperty]
    private string errorMessagePassword;

    [ObservableProperty]
    private string errorMessageRepeatPassword;

    public static List<User> allUsernames { get; set; } = new();

    private readonly UserService _userService;
    public SingUpViewModel(UserService userService)
    {
        _userService = userService;
        Load();
    }

    public async Task Load()
    {
        allUsernames = await _userService.GetUsernames();
        ListCountry = await _userService.GetCountries();
    }

    [RelayCommand(CanExecute = nameof(CanSingUp))]
    public async Task SingUp()
    {
        await _userService.AddUserAsync(Name, LastName, Birthday, SelectedCounrty, Username, Password);
        await Shell.Current.GoToAsync($"//{nameof(SingInPage)}");
    }
    private bool CanSingUp()
    {
        if (string.IsNullOrEmpty(SelectedCounrty))
            ErrorMessageCounrty = "Обязательно";
        else
            ErrorMessageCounrty = string.Empty;

        if (string.IsNullOrWhiteSpace(Name))
            ErrorMessageName = "Обязательно";
        else if (Name.Contains(' ')
                 || !Name.Any(char.IsLetter)
                 || Name.Any(char.IsDigit)
                 || Name.Any(char.IsSymbol)
                 || Name.Any(char.IsPunctuation))
            ErrorMessageName = "Неверный формат";
        else
            ErrorMessageName = string.Empty;

        if (string.IsNullOrWhiteSpace(LastName))
            ErrorMessageLastName = "Обязательно";
        else if (LastName.Contains(' ')
                 || !LastName.Any(char.IsLetter)
                 || LastName.Any(char.IsDigit)
                 || LastName.Any(char.IsSymbol)
                 || LastName.Any(char.IsPunctuation))
            ErrorMessageLastName = "Неверный формат";
        else
            ErrorMessageLastName = string.Empty;

        if (string.IsNullOrWhiteSpace(Username))
            ErrorMessageUsername = "Обязательно";
        else if (Username.Length < 3)
            ErrorMessageUsername = "Слишком короткий";
        else if (Username.Contains(' ')
                 || Username.Any(char.IsSymbol)
                 || Username.Any(char.IsPunctuation))
            ErrorMessageUsername = "Неверный формат";
        else if (allUsernames.SingleOrDefault(u => u.Username.ToLower().Equals(Username.ToLower())) != null)
            ErrorMessageUsername = "Уже существует";
        else
            ErrorMessageUsername = string.Empty;

        if (string.IsNullOrWhiteSpace(Password))
            ErrorMessagePassword = "Обязательно";
        else if (Password.Length < 7)
            ErrorMessagePassword = "Слишком короткий";
        else if (Password.Contains(' ')
                || !Password.Any(char.IsDigit)
                || !Password.Any(char.IsLetter))
            ErrorMessagePassword = "Неверный формат";
        else
            ErrorMessagePassword = string.Empty;

        if (string.IsNullOrWhiteSpace(RepeatPassword)
            || !string.IsNullOrWhiteSpace(RepeatPassword)
            && !RepeatPassword.Equals(Password))
            ErrorMessageRepeatPassword = "Пароли не совпадают";
        else
            ErrorMessageRepeatPassword = string.Empty;

        if (ErrorMessageName.Equals(string.Empty)
            && ErrorMessageLastName.Equals(string.Empty)
            && ErrorMessageUsername.Equals(string.Empty)
            && ErrorMessagePassword.Equals(string.Empty)
            && ErrorMessageRepeatPassword.Equals(string.Empty)
            && ErrorMessageCounrty.Equals(string.Empty))
            return true;
        else
            return false;
    }

    [RelayCommand]
    public async Task SingIn()
    {
        await Shell.Current.GoToAsync($"//{nameof(SingInPage)}");
    }

}
