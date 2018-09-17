using System;
using learnSpanish.views;
using Xamarin.Forms;

namespace learnSpanish.factory
{
    public class PageFactory
    {
        public static ContentPage GetPage(string viewName)
        {
            ContentPage page = null;

            if (string.Equals("LoginPage", viewName, StringComparison.OrdinalIgnoreCase))
            {
                page = new LoginPage();
            }
            else if (string.Equals("MainPage", viewName, StringComparison.OrdinalIgnoreCase))
            {
                page = new MainPage();
            }

            return page;
        }
    }
}