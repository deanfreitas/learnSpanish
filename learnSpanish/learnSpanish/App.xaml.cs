using System;
using learnSpanish.views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace learnSpanish
{
    public partial class App : Application
    {
        public App()
        {
            DependencyService.Register<modelView.services.IMessageService, views.services.MessageService>();
            DependencyService.Register<modelView.services.INavigationService, views.services.NavigationService>();

            InitializeComponent();
            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}