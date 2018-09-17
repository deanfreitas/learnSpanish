using System.Threading.Tasks;
using learnSpanish.factory;
using learnSpanish.modelView.services;
using Xamarin.Forms;

namespace learnSpanish.views.services
{
    public class NavigationService : INavigationService
    {
        public async Task Navigation(string viewName)
        {
            ContentPage page = PageFactory.GetPage(viewName);
            await Application.Current.MainPage.Navigation.PushAsync(page);
        }
        
        public async Task NavigationWithoutBackButton(string viewName)
        {
            ContentPage page = PageFactory.GetPage(viewName);

            await Application.Current.MainPage.Navigation.PushAsync(page);
            NavigationPage.SetHasBackButton(page, false);
        }
        
        public async Task NavigationWithoutNavigationBar(string viewName)
        {
            ContentPage page = PageFactory.GetPage(viewName);

            await Application.Current.MainPage.Navigation.PushAsync(page);
            NavigationPage.SetHasNavigationBar(page, false);
        }
    }
}