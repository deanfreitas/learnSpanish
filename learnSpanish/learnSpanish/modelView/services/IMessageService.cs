using System.Threading.Tasks;

namespace learnSpanish.modelView.services
{
    public interface IMessageService
    {
        Task ShowMessageError(string message);
    }
}