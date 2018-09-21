using System;
using learnSpanish.Enums.View;
using Xamarin.Forms;
using LoginPage = learnSpanish.View.LoginPage;
using MainPage = learnSpanish.View.MainPage;

namespace learnSpanish.Factory
{
    public class PageFactory
    {
        public ContentPage GetPage(ViewName viewName)
        {
            ContentPage page;

            switch (viewName)
            {
                case ViewName.LoginPage:
                    page = new LoginPage();
                    break;
                case ViewName.MainPage:
                    page = new MainPage();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(viewName), viewName, null);
            }

            return page;
        }
    }
}