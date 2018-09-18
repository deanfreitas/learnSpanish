using System.Threading.Tasks;
using learnSpanish.Enums.View;
using learnSpanish.Factory;
using learnSpanish.ModelView.Services;
using Xamarin.Forms;

namespace learnSpanish.View.Services
{
    public class NavigationService : INavigationService
    {
        public async Task Navigation(ViewName viewName)
        {
            ContentPage page = PageFactory.GetPage(viewName);
            await Application.Current.MainPage.Navigation.PushAsync(page);
        }
        
        public async Task NavigationWithoutBackButton(ViewName viewName)
        {
            ContentPage page = PageFactory.GetPage(viewName);

            await Application.Current.MainPage.Navigation.PushAsync(page);
            NavigationPage.SetHasBackButton(page, false);
        }
        
        public async Task NavigationWithoutNavigationBar(ViewName viewName)
        {
            ContentPage page = PageFactory.GetPage(viewName);

            await Application.Current.MainPage.Navigation.PushAsync(page);
            NavigationPage.SetHasNavigationBar(page, false);
        }
    }
}