using EmailManager.ViewModels;

namespace EmailManager.Interfaces
{
    public interface IMainViewModel
    {
        RelayCommand CreateEmailCommand { get; }

        RelayCommand SearchEmailsCommand { get; }
    }
}
