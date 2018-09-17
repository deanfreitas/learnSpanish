using System.Threading.Tasks;

namespace learnSpanish.modelView.services
{
    public interface INavigationService
    {
        Task Navigation(string viewName);
        Task NavigationWithoutBackButton(string viewName);
        Task NavigationWithoutNavigationBar(string viewName);
    }
}