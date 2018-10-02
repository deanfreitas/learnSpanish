using System.Threading.Tasks;
using learnSpanish.ModelView.Services;
using Xamarin.Forms;

namespace learnSpanish.View.Services
{
    public class MessageService : IMessageService
    {
        public async Task ShowMessageError(string message)
        {
            await Application.Current.MainPage.DisplayAlert("Error", message, "Ok");
        }

        public async Task ShowMessage(string message)
        {
            await Application.Current.MainPage.DisplayAlert("Alert", message, "Ok");
        }

        public async Task<bool> ShowOnAlertYesNoClicked(string message)
        {
           return await Application.Current.MainPage.DisplayAlert("Question?", message, "Yes", "No");
        }
    }
}