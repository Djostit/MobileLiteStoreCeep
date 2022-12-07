﻿using System.Diagnostics;

namespace MobileLiteStoreCeep.ViewModels;

public partial class SingInViewModel : BaseViewModel
{
    [ObservableProperty]
    private string username;

    [ObservableProperty]
    private string password;

    [ObservableProperty]
    //[NotifyCanExecuteChangedFor(nameof(SendMessageCommand))]
    private string errorMessageUsername;

    [ObservableProperty]
    private string errorMessagePassword;

    [ObservableProperty]
    private string errorMessageButton;

    private readonly UserService _userService;
    public SingInViewModel(UserService userService)
    {
        _userService = userService;
    }

    [RelayCommand(CanExecute = nameof(CanSignIn))]
    public async Task SendMessage()
    {
        if (await _userService.AuthorizeUserAsync(Username, Password) is true)
        {
            Debug.WriteLine("Успешно!");
        }
        else
        {
            Debug.WriteLine("Неверное имя пользователя или пароль");
        }
        //await _userService.CheckAllUsers();
    }
    private bool CanSignIn()
    {
        //if (string.IsNullOrWhiteSpace(Username))
        //    ErrorMessageUsername = "Обязательно";
        //else if (Username.Length < 3)
        //    ErrorMessageUsername = "Слишком короткий";
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

        //if (ErrorMessageUsername.Equals(string.Empty)
        //        && ErrorMessagePassword.Equals(string.Empty))
        //    return true;
        //else
        //    return false;
        return Username is not null;
    }
}