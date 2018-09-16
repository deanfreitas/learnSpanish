using System.Threading.Tasks;
using Xamarin.Forms;

namespace learnSpanish.views.services
{
    public class MessageService : modelView.services.IMessageService
    {
        public async Task ShowMessageError(string message)
        {
            await Application.Current.MainPage.DisplayAlert("Error", message, "Ok");
        }
    }
}