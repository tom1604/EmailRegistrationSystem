using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using EmailManager.Models;

namespace EmailManager.ViewModels
{
    public class ListEmailsViewModel: INotifyPropertyChanged
    {
        public ObservableCollection<Email> Emails { get; set; }

        private Email selectedEmail;

        public Email SelectedEmail
        {
            get { return selectedEmail; }

            set
            {
                selectedEmail = value;
                OnPropertyChanged("SelectedEmail");
            }
        }

        public ListEmailsViewModel()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
