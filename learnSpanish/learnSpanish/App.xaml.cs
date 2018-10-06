using System;
using learnSpanish.Model;
using learnSpanish.ModelView.Services;
using learnSpanish.Sqlite;
using learnSpanish.View;
using learnSpanish.View.ContentPageView;
using learnSpanish.View.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace learnSpanish
{
    public partial class App : Application
    {
        public App()
        {
            DependencyService.Register<IMessageService, MessageService>();
            DependencyService.Register<INavigationService, NavigationService>();

            InitializeComponent();
            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
            try
            {
                var sqliteTable = new SqliteTable();
                sqliteTable.CreateTable<Login>();
                sqliteTable.CreateTable<User>();
            }
            catch (Exception e)
            {
                Logs.Logs.Error($"Error init application: {e.Message}");
            }
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}