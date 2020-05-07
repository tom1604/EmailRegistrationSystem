using System.Windows.Controls;

namespace EmailManager.Interfaces
{
    public interface INavigationService
    {
        void Navigate(Page sourcePage, object dataContext);

        void Navigate(Page sourcePage);
    }
}
