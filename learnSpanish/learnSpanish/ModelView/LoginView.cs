using System;
using System.Windows.Input;
using learnSpanish.Enums.Error;
using learnSpanish.Enums.Service;
using learnSpanish.Enums.View;
using learnSpanish.Model;
using learnSpanish.ModelView.Services;
using learnSpanish.Sqlite;
using learnSpanish.utils;
using Xamarin.Forms;

namespace learnSpanish.ModelView
{
    public class LoginView : ViewBase
    {
        private string _user;
        private string _password;
        private readonly IMessageService _messageService;
        private readonly INavigationService _navigationService;
        private readonly SqliteService _sqliteService;

        public LoginView()
        {
            AuthenticateCommand = new Command(Authenticate);
            _sqliteService = new SqliteService();
            _messageService = DependencyService.Get<IMessageService>();
            _navigationService = DependencyService.Get<INavigationService>();
        }

        public string User
        {
            get => _user;
            set
            {
                _user = value;
                NotifyPropertyChanged();
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand AuthenticateCommand { get; set; }

        private void Authenticate()
        {
            var login = new Login(_user, _password);
            var message = LoginUtils.CheckLogin(login);
            
            if (!string.IsNullOrEmpty(message))
            {
                _messageService.ShowMessageError(message);
                return;
            }

            var loginRegistered = _sqliteService.GetObjectByUniqueName<Login>(login.User);

            try
            {
                if (!loginRegistered.Password.Equals(login.Password))
                {
                    _messageService.ShowMessageError(EnumsService.GetMessageErrorUser(ErrorUser.WrongCredentials));
                    return;
                }

                _navigationService.NavigationWithoutBackButton(ViewName.MainPage);
            } catch (Exception e)
            {
                Logs.Logs.Error($"Error in authenticate user ==> {e.Message}");
                _messageService.ShowMessageError(EnumsService.GetMessageErrorSystem(ErrorSystem.Generic));
            }
        }
    }
}