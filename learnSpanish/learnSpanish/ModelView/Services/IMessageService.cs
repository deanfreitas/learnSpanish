using System.Threading.Tasks;

namespace learnSpanish.ModelView.Services
{
    public interface IMessageService
    {
        Task ShowMessageError(string message);
    }
}