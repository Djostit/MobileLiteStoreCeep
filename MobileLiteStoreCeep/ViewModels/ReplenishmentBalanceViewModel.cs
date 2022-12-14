using MobileLiteStoreCeep.Controls;

namespace MobileLiteStoreCeep.ViewModels;

public partial class ReplenishmentBalanceViewModel : BaseViewModel
{
    //private string currentBalance { get; set; } = Global.CurrentUser.Balance.ToString() + "₽";
    //public string SelectedItem { get; set; }
    //public bool isSelected { get; set; }
    //public List<string> ArrayAmmount { get; set; } = new List<string>() { "50 ₽", "100 ₽", "150 ₽", "200 ₽", "500 ₽", "750 ₽", "1000 ₽", "5000 ₽" };
    //public string SelectedAmmount { get; set; }
    private string errorMessage { get; set; }
    [RelayCommand]
    public async Task AddMoney()
    {
        Global.CurrentUser.Balance += 100; /* int.Parse(SelectedAmmount.Split(' ')[0].ToString()) */
        Shell.Current.FlyoutHeader = new FloyoutHeaderControl();
        await Task.Delay(1500);
    }
    //bool () =>
    //{
    //    if (!isSelected)
    //    {
    //        ErrorMessage = "Не принято условие использования";
    //    }
    //    else if (string.IsNullOrWhiteSpace(SelectedItem))
    //    {
    //        ErrorMessage = "Не выбран способ пополнения";
    //    }
    //    else if (string.IsNullOrWhiteSpace(SelectedAmmount))
    //    {
    //        ErrorMessage = "Не выбрана сумма пополнения";
    //    }
    //    else
    //    {
    //        ErrorMessage = string.Empty;
    //    }

    //    if (ErrorMessage.Equals(string.Empty))
    //        return true; return false;

    //});
}
