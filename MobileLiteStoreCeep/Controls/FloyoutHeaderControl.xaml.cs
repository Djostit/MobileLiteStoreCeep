using System.Globalization;

namespace MobileLiteStoreCeep.Controls;

public partial class FloyoutHeaderControl : StackLayout
{
	public FloyoutHeaderControl()
	{
		InitializeComponent();

        labelUsername.Text = Global.CurrentUser.Username == null ? Global.CurrentUser.Username : new CultureInfo("ru-RU").TextInfo.ToTitleCase(Global.CurrentUser.Username);
        labelBalance.Text = Global.CurrentUser.Balance.ToString() + "₽";

    }
}