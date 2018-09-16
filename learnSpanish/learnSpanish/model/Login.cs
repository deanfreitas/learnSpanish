using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace learnSpanish.model
{
    public class Login : INotifyPropertyChanged
    {
        private int id;
        private string user;
        private string password;
        
        public event PropertyChangedEventHandler PropertyChanged;

        public Login()
        {
        }

        public Login(string user, string password)
        {
            this.user = user;
            this.password = password;
        }

        public Login(int id, string user, string password)
        {
            this.id = id;
            this.user = user;
            this.password = password;
        }

        public int Id
        {
            get => id;
            set
            {
                id = value;
                NotifyPropertyChanged();
            }
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

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "name")
        {
            if (propertyName != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}