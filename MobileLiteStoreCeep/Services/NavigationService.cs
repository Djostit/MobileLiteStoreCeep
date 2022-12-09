namespace MobileLiteStoreCeep.Services
{
    public class NavigationService
    {
        readonly IServiceProvider _provider;
        protected INavigation Navigation
        {
            get
            {
                INavigation navigation = Application.Current?.MainPage?.Navigation;
                if (navigation is not null)
                    return navigation;
                else
                {
                    if(Debugger.IsAttached)
                        Debugger.Break();
                    throw new Exception();
                }
            }
        }
        public NavigationService(IServiceProvider provider) => _provider = provider;
        public Task ChangePage(Page page) => Navigation.PushAsync(page, true);

    }
}
