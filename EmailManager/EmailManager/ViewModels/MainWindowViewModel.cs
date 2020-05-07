using Autofac;
using EmailManager.Integration;
using EmailManager.Interfaces;
using EmailManager.View;

namespace EmailManager.ViewModels
{
    public class MainWindowViewModel : IMainViewModel 
    {
        private RelayCommand _createEmailCommand;
        private RelayCommand _searchEmailsCommand;

        private INavigationService NavigationService { get; }

        public MainWindowViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        public RelayCommand CreateEmailCommand => _createEmailCommand ?? new RelayCommand(x => NavigationService.Navigate(new CreateEmailPage(), CompositionRoot.Container.Resolve<ICreateEmailViewModel>()));
        public RelayCommand SearchEmailsCommand => _searchEmailsCommand ?? new RelayCommand(x => NavigationService.Navigate(new SearchEmailsPage()));
    }
}
