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
    public class RegisterView : ViewBase
    {
        private string _name;
        private string _email;
        private bool _isValidEmail;
        private string _user;
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
            if (!IsValidEmail)
            {
                await _messageService.ShowMessageError(EnumsService.GetMessageErrorUser(ErrorUser.WrongEmail));
            }

            if (!IsValidConfirmedPassword)
            {
                await _messageService.ShowMessageError(EnumsService.GetMessageErrorUser(ErrorUser.UnconfirmedPassword));
            }

            var user = new User(Name, Email, new Login(User, Password));

            var message = UserUtils.CheckUser(user);

            if (!string.IsNullOrEmpty(message))
            {
                await _messageService.ShowMessageError(message);
                return;
            }

            try
            {
                await _sqliteService.InsertWithChildren(user);
            }
            catch (Exception e)
            {
                Logs.Logs.Error(e.Message);
                await _messageService.ShowMessageError(EnumsService.GetMessageErrorSystem(ErrorSystem.Generic));
            }
        }

        private async void Cancel()
        {
            await _navigationService.NavigationWithoutBackButton(ViewName.LoginPage);
        }
    }
}