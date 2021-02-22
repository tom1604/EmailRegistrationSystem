using Autofac;
using EmailManager.Integration;
using EmailManager.Interfaces;
using EmailManager.View;

namespace EmailManager.ViewModels
{
    public class MainWindowViewModel : IMainViewModel 
    {
        private INavigationService NavigationService { get; }

        public MainWindowViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        public RelayCommand CreateEmailCommand => new RelayCommand(x => NavigationService.Navigate(CompositionRoot.Container.Resolve<CreateEmailPage>()));
        public RelayCommand SearchEmailsCommand => new RelayCommand(x => NavigationService.Navigate(new SearchEmailsPage()));
    }
}
