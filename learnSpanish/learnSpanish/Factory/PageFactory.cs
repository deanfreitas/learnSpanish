using learnSpanish.Enums.View;
using Xamarin.Forms;
using LoginPage = learnSpanish.View.LoginPage;
using MainPage = learnSpanish.View.MainPage;

namespace learnSpanish.Factory
{
    public class PageFactory
    {
        public static ContentPage GetPage(ViewName viewName)
        {
            ContentPage page = null;

            if (viewName == ViewName.LoginPage)
            {
                page = new LoginPage();
            }

            else if (viewName == ViewName.MainPage)
            {
                page = new MainPage();
            }

            return page;
        }
    }
}