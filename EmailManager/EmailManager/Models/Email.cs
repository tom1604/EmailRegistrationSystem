using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EmailManager.Models
{
    public class Email : INotifyPropertyChanged
    {
        private string _subtitle;
        private string _emailbody;
        private string _senderemail;
        private DateTime _registrationdate;
        private ObservableCollection<Teg> _tegs;
        private ObservableCollection<Recipient> _recipients;

        public string Subtitle
        {
            get
            {
                return _subtitle;
            }

            set
            {
                _subtitle = value;
                OnPropertyChanged("Subtitle");
            }
        }

        public string EmailBody
        {
            get { return _emailbody; }

            set
            {
                _emailbody = value;
                OnPropertyChanged("EmailBody");
            }
        }

        public string SenderEmail
        {
            get { return _senderemail; }

            set
            {
                _senderemail = value;
                OnPropertyChanged("SenderEmail");
            }
        }

        public DateTime RegistrationDate
        {
            get { return _registrationdate; }

            set
            {
                _registrationdate = value;
                OnPropertyChanged("RegistrationDate");
            }
        }

        public ObservableCollection<Teg> Tegs
        {
            get { return new ObservableCollection<Teg>(_tegs); }

            set
            {
                _tegs = new ObservableCollection<Teg>(value);
                OnPropertyChanged("Tegs");
            }
        }

        public ObservableCollection<Recipient> Recipients
        {
            get { return new ObservableCollection<Recipient>(_recipients); }

            set
            {
                _recipients = new ObservableCollection<Recipient>(value);
                OnPropertyChanged("Recipients");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
