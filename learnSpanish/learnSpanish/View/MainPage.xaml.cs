using learnSpanish.ModelView;
using Xamarin.Forms;

namespace learnSpanish.View
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainView();
        }
    }
}