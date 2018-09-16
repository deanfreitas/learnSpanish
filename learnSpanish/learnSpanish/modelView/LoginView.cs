using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using learnSpanish.model;
using learnSpanish.views;
using Xamarin.Forms;

namespace learnSpanish.modelView
{
    public class LoginView : ViewBase
    {
        private string user;
        private string password;
        private readonly services.IMessageService _messageService;

        public LoginView()
        {
            AuthenticateCommand = new Command(Authenticate);
            _messageService = DependencyService.Get<services.IMessageService>();
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
            if (string.IsNullOrEmpty(Login.User) || string.IsNullOrEmpty(Login.Password))
            {
                _messageService.ShowMessageError("You must enter the username and password");
            }
        }
    }
}