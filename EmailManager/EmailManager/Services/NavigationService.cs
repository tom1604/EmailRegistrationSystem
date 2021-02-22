using System.Windows;
using System.Windows.Controls;
using EmailManager.Interfaces;

namespace EmailManager.Services
{
    public class NavigationService : INavigationService
    {
        public void Navigate(Page sourcePage)
        {
            if ((Application.Current.MainWindow as MainWindow)?.FramePage is Frame navigationFrame)
            {
                navigationFrame.Navigate(sourcePage);
            }
        }
    }
}
