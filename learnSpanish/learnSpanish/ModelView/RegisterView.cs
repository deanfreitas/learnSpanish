using System;
using System.Collections.Generic;
using System.Text;

namespace learnSpanish.ModelView
{
    class RegisterView : ViewBase
    {
        private string _name;
        private string _user;
        private string _email;
        private string _password;
        private string _confirmPassword;


        public string Name
        {
            get => _name;
            set
            {
                _name = value;
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

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
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
    }
}
