using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using learnSpanish.Enums.View;
using learnSpanish.ModelView.Services;
using learnSpanish.Sqlite;
using Xamarin.Forms;

namespace learnSpanish.ModelView
{
    public class RegisterView : ViewBase
    {
        private string _name;
        private string _email;
        private string _user;
        private string _password;
        private string _confirmPassword;

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

        public ICommand CreateCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        private async void Create()
        {
        }

        private async void Cancel()
        {
            await _navigationService.NavigationWithoutBackButton(ViewName.LoginPage);
        }
    }
}