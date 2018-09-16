using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using learnSpanish.model;
using learnSpanish.modelView;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace learnSpanish.views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginView();
        }
    }
}