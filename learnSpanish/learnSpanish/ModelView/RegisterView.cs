using System;
using System.Threading.Tasks;
using System.Windows.Input;
using learnSpanish.Enums.Error;
using learnSpanish.Enums.Service;
using learnSpanish.Enums.Success;
using learnSpanish.Enums.View;
using learnSpanish.Model;
using learnSpanish.ModelView.Services;
using learnSpanish.Sqlite;
using learnSpanish.utils;
using SQLite;
using Xamarin.Forms;

namespace learnSpanish.ModelView
{
    public class RegisterView : ViewBase
    {
        private string _name;
        private string _email;
        private bool _isValidEmail;
        private string _userName;
        private string _password;
        private string _confirmPassword;
        private bool _isValidConfirmedPassword;

        private readonly IMessageService _messageService;
        private readonly INavigationService _navigationService;
        private readonly SqliteService _sqliteService;

        public RegisterView()
        {
            CreateCommand = new Command(Create);
            CancelCommand = new Command(Cancel);
            _sqliteService = new SqliteService();
            _messageService = DependencyService.Get<IMessageService>();
            _navigationService = DependencyService.Get<INavigationService>();
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                NotifyPropertyChanged();
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                NotifyPropertyChanged();
            }
        }

        public bool IsValidEmail
        {
            get => _isValidEmail;
            set
            {
                _isValidEmail = value;
                NotifyPropertyChanged();
            }
        }

        public string UserName
        {
            get => _userName;
            set
            {
                _userName = value;
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

        public string ConfirmPassword
        {
            get => _confirmPassword;
            set
            {
                _confirmPassword = value;
                NotifyPropertyChanged();
            }
        }

        public bool IsValidConfirmedPassword
        {
            get => _isValidConfirmedPassword;
            set
            {
                _isValidConfirmedPassword = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand CreateCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        private async void Create()
        {
            var user = new User(Name, Email, new Login(UserName, Password));
            if (!await CheckRequiredParameters(user)) return;
            if (await CheckIsExistEmail(user.Email)) return;
            if (await CheckIsExistUserName(user.Login.UserName)) return;

            try
            {
                await _sqliteService.InsertWithChildren(user);
                await _messageService.ShowMessage(
                    EnumsService.GetMessageSuccessUser(SuccessUser.UserRegistered, user.Name));
            }
            catch (Exception e)
            {
                Logs.Logs.Error(e);
                await _messageService.ShowMessageError(EnumsService.GetMessageErrorSystem(ErrorSystem.Generic));
            }
        }

        private async void Cancel()
        {
            await _navigationService.NavigationWithoutBackButton(ViewName.LoginPage);
        }

        private async Task<bool> CheckRequiredParameters(User user)
        {
            var message = UserUtils.CheckUser(user);

            if (!IsValidEmail)
            {
                await _messageService.ShowMessageError(EnumsService.GetMessageErrorUser(ErrorUser.WrongEmail));
            }
            else if (!IsValidConfirmedPassword)
            {
                await _messageService.ShowMessageError(EnumsService.GetMessageErrorUser(ErrorUser.UnconfirmedPassword));
            }
            else if (!string.IsNullOrEmpty(message))
            {
                await _messageService.ShowMessageError(message);
            }
            else
            {
                return true;
            }

            return false;
        }

        private async Task<bool> CheckIsExistEmail(string email)
        {
            try
            {
                var emailRegistered =
                    await _sqliteService.GetObjectByUniqueValue<User>(u => u.Email.ToLower().Equals(email.ToLower()));
                if (emailRegistered == null) return false;

                await _messageService.ShowMessageError(EnumsService.GetMessageErrorUser(ErrorUser.ExistEmail));
                return true;
            }
            catch (Exception e)
            {
                Logs.Logs.Error(e);
                return false;
            }
        }

        private async Task<bool> CheckIsExistUserName(string userName)
        {
            try
            {
                var userNameRegistered = await _sqliteService.GetObjectByUniqueValue<Login>(l =>
                    l.UserName.ToLower().Equals(userName.ToLower()));
                if (userNameRegistered == null) return false;

                await _messageService.ShowMessageError(EnumsService.GetMessageErrorUser(ErrorUser.ExistUserName));
                return true;
            }
            catch (Exception e)
            {
                Logs.Logs.Error(e);
                return false;
            }
        }
    }
}