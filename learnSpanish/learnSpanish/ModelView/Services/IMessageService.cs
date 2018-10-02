using System.Threading.Tasks;

namespace learnSpanish.ModelView.Services
{
    public interface IMessageService
    {
        Task ShowMessageError(string message);
        Task ShowMessage(string message);
        Task<bool> ShowOnAlertYesNoClicked(string message);
    }
}