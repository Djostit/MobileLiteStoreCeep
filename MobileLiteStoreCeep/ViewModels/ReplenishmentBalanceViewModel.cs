namespace MobileLiteStoreCeep.ViewModels;

public partial class ReplenishmentBalanceViewModel : BaseViewModel
{
    [ObservableProperty]
    private List<Payment> payments;

    [ObservableProperty]
    private List<string> arrayAmmount = new (){ "50 ₽", "100 ₽", "150 ₽", "200 ₽", "500 ₽", "750 ₽", "1000 ₽", "5000 ₽" };

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(AddMoneyCommand))]
    private bool isSelected;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(AddMoneyCommand))]
    private string selectedAmmount;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(AddMoneyCommand))]
    private Payment selectedItem;

    [ObservableProperty]
    private string errorMessage;

    public ReplenishmentBalanceViewModel() => LoadPayments();

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
        if (string.IsNullOrEmpty(SelectedAmmount))
            ErrorMessage = "Не выбрана сумма пополенения";
        else if (string.IsNullOrEmpty(SelectedItem.Name))
            ErrorMessage = "Не выбран способ пополнения";
        else if (!IsSelected)
            ErrorMessage = "Не принято условие использования";
        else
            ErrorMessage = string.Empty;
        if (ErrorMessage.Equals(string.Empty))
            return true; return false;
    }
}
