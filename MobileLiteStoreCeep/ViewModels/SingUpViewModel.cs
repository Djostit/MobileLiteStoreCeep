using Newtonsoft.Json;

namespace MobileLiteStoreCeep.ViewModels;

public partial class SingUpViewModel : BaseViewModel
{
    public static List<Country> Countrys { get; set; } = new List<Country>();
    //[ObservableProperty]
    //private static ObservableCollection<Country> countries = new ObservableCollection<Country>(JsonConvert.DeserializeObject<List<Country>>(GetCountries().Result));

    //public ObservableCollection<Country> Country { get; set; }
    //    = new ObservableCollection<Country>(JsonConvert.DeserializeObject<List<Country>>(File
    //        .ReadAllText(Path.GetFullPath(@"Jsons\countries.json")
    //        .Replace(@"\bin\Debug\net7.0-windows\", @"\"))));
    [ObservableProperty]
    private List<Country> array = Countrys;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SingUpCommand))]
    private DateTime dateStart = DateTime.Now.AddYears(-100);

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SingUpCommand))]
    private DateTime dateEnd = DateTime.Now.AddYears(-12);

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SingUpCommand))]
    private Country selectedCounrty;

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

    public List<User> allUsernames { get; set; } = new();

    private readonly UserService _userService;
    public SingUpViewModel(UserService userService)
    {
        _userService = userService;

        GetCountries();

        //Task<string> post = postPostAsync("Url", data).Result.Content.ReadAsStringAsync();
        //post.Result.ToString();
    }
    private static async Task GetCountries()
    {
        using var stream = await FileSystem.OpenAppPackageFileAsync("countries.json");
        using var reader = new StreamReader(stream);

        var contents = await reader.ReadToEndAsync();

        Countrys = JsonConvert.DeserializeObject<List<Country>>(contents);

    }

    [RelayCommand(CanExecute = nameof(CanSingUp))]
    public async Task SingUp()
    {
        //if (await _userService.AuthorizeUserAsync(Username, Password) is true)
        //{
        //    ErrorMessageButton = string.Empty;
        //}
        //else
        //    ErrorMessageButton = "Неверное имя пользователя или пароль";
        Debug.WriteLine(Countrys.Count);
    }
    private bool CanSingUp()
    {
        return true;
        //if (string.IsNullOrWhiteSpace(Name))
        //    ErrorMessageName = "Обязательно";
        //else if (Name.Contains(' '))
        //    ErrorMessageName = "Неверный формат";
        //else
        //    ErrorMessageName = string.Empty;

        //if (string.IsNullOrWhiteSpace(LastName))
        //    ErrorMessageLastName = "Обязательно";
        //else if (LastName.Contains(' '))
        //    ErrorMessageLastName = "Неверный формат";
        //else
        //    ErrorMessageLastName = string.Empty;

        //if (string.IsNullOrWhiteSpace(Username))
        //    ErrorMessageUsername = "Обязательно";
        //else if (Username.Length < 3)
        //    ErrorMessageUsername = "Слишком короткий";
        //else if (Username.Contains(' '))
        //    ErrorMessageUsername = "Неверный формат";
        //else if (allUsernames.SingleOrDefault(u => u.Username.ToLower().Equals(Username.ToLower())) != null)
        //    ErrorMessageUsername = "Уже существует";
        //else
        //    ErrorMessageUsername = string.Empty;

        //if (string.IsNullOrWhiteSpace(Password))
        //    ErrorMessagePassword = "Обязательно";
        //else if (Password.Length < 7)
        //    ErrorMessagePassword = "Слишком короткий";
        //else if (Password.Contains(' ')
        //        || !Password.Any(char.IsDigit)
        //        || !Password.Any(char.IsLetter))
        //    ErrorMessagePassword = "Неверный формат";
        //else
        //    ErrorMessagePassword = string.Empty;

        //if (string.IsNullOrWhiteSpace(RepeatPassword)
        //    || !string.IsNullOrWhiteSpace(RepeatPassword)
        //    && !RepeatPassword.Equals(Password))
        //    ErrorMessageRepeatPassword = "Пароли не совпадают";
        //else
        //    ErrorMessageRepeatPassword = string.Empty;

        //if (ErrorMessageName.Equals(string.Empty)
        //    && ErrorMessageLastName.Equals(string.Empty)
        //    && ErrorMessageBirthday.Equals(string.Empty)
        //    && ErrorMessageUsername.Equals(string.Empty)
        //    && ErrorMessagePassword.Equals(string.Empty)
        //    && ErrorMessageRepeatPassword.Equals(string.Empty))
        //    return true;
        //else
        //    return false;
    }

    [RelayCommand]
    public async Task SingIn()
    {
        await Shell.Current.GoToAsync($"//{nameof(SingInPage)}");
    }

}
