using System.Windows.Input;
using learnSpanish.Enums.Error;
using learnSpanish.Enums.Service;
using learnSpanish.Enums.View;
using learnSpanish.Model;
using learnSpanish.ModelView.Services;
using learnSpanish.utils;
using Xamarin.Forms;

namespace learnSpanish.ModelView
{
    public class LoginView : ViewBase
    {
        private string user;
        private string password;
        private readonly IMessageService _messageService;
        private readonly INavigationService _navigationService;

        public LoginView()
        {
            AuthenticateCommand = new Command(Authenticate);
            _messageService = DependencyService.Get<IMessageService>();
            _navigationService = DependencyService.Get<INavigationService>();
        }

        public string User
        {
            get => user;
            set
            {
                user = value;
                NotifyPropertyChanged();
            }
        }

        public string Password
        {
            get => password;
            set
            {
                password = value;
                NotifyPropertyChanged();
            }
        }

        private Login Login { get; set; }
        public ICommand AuthenticateCommand { get; set; }

        private void Authenticate()
        {
            Login = new Login(user, password);
            string message = LoginUtils.CheckLogin(Login);
            
            if (!string.IsNullOrEmpty(message))
            {
                _messageService.ShowMessageError(message);
                return;
            }

            if (!Login.Password.Equals("12345"))
            {
                _messageService.ShowMessageError(EnumsService.GetMessageErrorUser(ErrorUser.WrongCredentials));
                return;
            }

            _navigationService.NavigationWithoutBackButton(ViewName.MainPage);
        }
    }
}