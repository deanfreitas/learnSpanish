using System;
using System.Threading.Tasks;
using System.Windows.Input;
using learnSpanish.Enums.Error;
using learnSpanish.Enums.Service;
using learnSpanish.Enums.View;
using learnSpanish.Exceptions;
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
            RegisterCommand = new Command(Register);
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
        public ICommand RegisterCommand { get; set; }

        private async void Authenticate()
        {
            var login = new Login(User, Password);
            if (!await CheckRequiredParameters(login)) return;

            try
            {
                var loginRegistered = await _sqliteService.GetObjectByUniqueValueWithChildren<Login>(l =>
                    l.UserName.ToLower().Equals(login.UserName.ToLower()) && l.Password.Equals(login.Password));
                if (loginRegistered == null)
                {
                    Logs.Logs.Error(EnumsService.GetMessageErrorUser(ErrorUser.WrongCredentials));
                    await _messageService.ShowMessageError(
                        EnumsService.GetMessageErrorUser(ErrorUser.WrongCredentials));
                }
                else
                {
                    await _navigationService.NavigationWithoutBackButton(ViewName.MainPage, loginRegistered.User);
                }
            }
            catch (SqliteServiceException e)
            {
                Logs.Logs.Error(e);
                await _messageService.ShowMessageError(EnumsService.GetMessageErrorUser(ErrorUser.WrongCredentials));
            }
            catch (Exception e)
            {
                Logs.Logs.Error(e);
                await _messageService.ShowMessageError(EnumsService.GetMessageErrorSystem(ErrorSystem.Generic));
            }
        }

        private async void Register()
        {
            await _navigationService.NavigationWithoutBackButton(ViewName.RegisterPage);
        }

        private async Task<bool> CheckRequiredParameters(Login login)
        {
            var message = UserUtils.CheckLogin(login);

            if (string.IsNullOrEmpty(message)) return true;
            await _messageService.ShowMessageError(message);
            return false;
        }
    }
}