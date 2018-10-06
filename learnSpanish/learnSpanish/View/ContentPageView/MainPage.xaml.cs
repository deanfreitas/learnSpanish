using learnSpanish.Model;
using learnSpanish.ModelView;
using Xamarin.Forms;

namespace learnSpanish.View.ContentPageView
{
    public partial class MainPage : ContentPage
    {
        public MainPage(User user)
        {
            InitializeComponent();
            BindingContext = new MainView(user);
        }
    }
}