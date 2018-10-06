using System.Threading.Tasks;
using learnSpanish.Enums.View;

namespace learnSpanish.ModelView.Services
{
    public interface INavigationService
    {
        Task Navigation(ViewName viewName);
        Task NavigationWithoutBackButton(ViewName viewName, object o = null);
        Task NavigationWithoutNavigationBar(ViewName viewName);
    }
}