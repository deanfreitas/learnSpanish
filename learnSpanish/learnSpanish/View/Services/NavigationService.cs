using System.Threading.Tasks;
using learnSpanish.Enums.View;
using learnSpanish.Factory;
using learnSpanish.ModelView.Services;
using Xamarin.Forms;

namespace learnSpanish.View.Services
{
    public class NavigationService : INavigationService
    {
        private readonly PageFactory _pageFactory = new PageFactory();

        public async Task Navigation(ViewName viewName)
        {
            var page = _pageFactory.GetPage(viewName);
            await Application.Current.MainPage.Navigation.PushAsync(page);
        }

        public async Task NavigationWithoutBackButton(ViewName viewName, object o = null)
        {
            var page = _pageFactory.GetPage(viewName, o);
            await Application.Current.MainPage.Navigation.PushAsync(page);
            NavigationPage.SetHasBackButton(page, false);
        }

        public async Task NavigationWithoutNavigationBar(ViewName viewName)
        {
            var page = _pageFactory.GetPage(viewName);
            await Application.Current.MainPage.Navigation.PushAsync(page);
            NavigationPage.SetHasNavigationBar(page, false);
        }
    }
}