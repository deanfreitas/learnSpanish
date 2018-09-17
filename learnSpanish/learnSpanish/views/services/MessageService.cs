using System;
using System.Threading.Tasks;
using learnSpanish.modelView.services;
using Xamarin.Forms;

namespace learnSpanish.views.services
{
    public class MessageService : IMessageService
    {
        public async Task ShowMessageError(string message)
        {
            Console.WriteLine(message);
            await Application.Current.MainPage.DisplayAlert("Error", message, "Ok");
        }
    }
}