using System.ComponentModel;
using System.Runtime.CompilerServices;
using EmailManager.Models;

namespace EmailManager.ViewModels
{
    public class CreateEmailViewModel : INotifyPropertyChanged
    {

        public CreateEmailViewModel()
        {
            Email = new Email();
        }
        private Email _email;

        public Email Email
        {
            get => _email;
            set
            {
                _email = value;
                //check valid
                OnPropertyChanged("Email");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
