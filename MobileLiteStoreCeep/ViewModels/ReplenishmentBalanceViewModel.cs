using MobileLiteStoreCeep.Controls;

namespace MobileLiteStoreCeep.ViewModels;

public partial class ReplenishmentBalanceViewModel : BaseViewModel
{
    //private string currentBalance { get; set; } = Global.CurrentUser.Balance.ToString() + "₽";
    //public string SelectedItem { get; set; }
    //public bool isSelected { get; set; }
    [ObservableProperty]
    private List<Payment> payments;

    [ObservableProperty]
    private List<string> arrayAmmount = new (){ "50 ₽", "100 ₽", "150 ₽", "200 ₽", "500 ₽", "750 ₽", "1000 ₽", "5000 ₽" };

    [ObservableProperty]
    private string selectedAmmount;

    [ObservableProperty]
    private bool isSelected;

    [ObservableProperty]
    private Payment selectedItem;

    [ObservableProperty]
    private string errorMessage;

    public ReplenishmentBalanceViewModel()
    {
        LoadPayments();
    }
    #region LoadItems
    private void LoadPayments()
    {
        Payments = new()
        {
            new Payment
            {
                Image = "visamastercard.png",
                Name = "VISA/Mastercard"
            },
            new Payment
            {
                Image = "qiwi.png",
                Name = "QIWI"
            },
            new Payment
            {
                Image = "webmoney.png",
                Name = "Webmoney (WMR)"
            },
            new Payment
            {
                Image = "webmoney.png",
                Name = "Webmoney (WMP)"
            },
            new Payment
            {
                Image = "bitcoin.png",
                Name = "Bitcoin"
            },
            new Payment
            {
                Image = "robokassa.png",
                Name = "Robokassa"
            }
        };
    }
    #endregion

    [RelayCommand(CanExecute = nameof(CanAddMoney))]
    public async Task AddMoney()
    {
        Global.CurrentUser.Balance += int.Parse(SelectedAmmount.Split(' ')[0].ToString());
        Shell.Current.FlyoutHeader = new FloyoutHeaderControl();
        await Task.Delay(1500);
    }
    private bool CanAddMoney()
    {
        if (!IsSelected)
        {
            ErrorMessage = "Не принято условие использования";
        }
        else if (string.IsNullOrWhiteSpace(SelectedItem.Name))
        {
            ErrorMessage = "Не выбран способ пополнения";
        }
        else if (string.IsNullOrWhiteSpace(SelectedAmmount))
        {
            ErrorMessage = "Не выбрана сумма пополнения";
        }
        else
        {
            ErrorMessage = string.Empty;
        }

        if (ErrorMessage.Equals(string.Empty))
            return true; return false;
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
