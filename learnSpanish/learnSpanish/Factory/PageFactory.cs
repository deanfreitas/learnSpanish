using System;
using learnSpanish.Enums.View;
using learnSpanish.Model;
using learnSpanish.View;
using Xamarin.Forms;

namespace learnSpanish.Factory
{
    public class PageFactory
    {
        public ContentPage GetPage(ViewName viewName, object o =  null)
        {
            ContentPage page;

            switch (viewName)
            {
                case ViewName.LoginPage:
                    page = new LoginPage();
                    break;
                case ViewName.MainPage:
                    if (o == null) throw new ArgumentNullException(nameof(o), "User parameter is null");
                    page = new MainPage((User) o);
                    break;
                case ViewName.RegisterPage:
                    page = new RegisterPage();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(viewName), viewName, null);
            }

            return page;
        }
    }
}