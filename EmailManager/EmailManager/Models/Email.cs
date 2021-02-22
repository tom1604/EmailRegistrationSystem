using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using EmailManager.Helpers;

namespace EmailManager.Models
{
    public class Email : INotifyPropertyChanged, IDataErrorInfo
    {
        private string _subtitle;
        private string _emailbody;
        private string _senderemail;
        private DateTime _registrationdate;
        private ObservableCollection<Teg> _tegs;
        private ObservableCollection<Recipient> _recipients;

        public string Subtitle
        {
            get => _subtitle;

            set
            {
                _subtitle = value;
                OnPropertyChanged(nameof(Subtitle));
            }
        }

        public string EmailBody
        {
            get => _emailbody;

            set
            {
                _emailbody = value;
                OnPropertyChanged(nameof(EmailBody));
            }
        }

        public string SenderEmail
        {
            get => _senderemail;

            set
            {
                _senderemail = value;
                OnPropertyChanged(nameof(SenderEmail));
            }
        }

        public DateTime RegistrationDate
        {
            get => _registrationdate;

            set
            {
                _registrationdate = value;
                OnPropertyChanged(nameof(RegistrationDate));
            }
        }

        public ObservableCollection<Teg> Tegs
        {
            get => _tegs;

            set
            {
                _tegs = new ObservableCollection<Teg>(value);
                OnPropertyChanged(nameof(Tegs));
            }
        }

        public ObservableCollection<Recipient> Recipients
        {
            get => _recipients;

            set
            {
                _recipients = new ObservableCollection<Recipient>(value);
                OnPropertyChanged(nameof(Recipients));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public string this[string propertyName] => GetValidationError(propertyName);

        public string Error => null;

        private static readonly string[] ValidatedProperties =
        {
            nameof(SenderEmail),
            nameof(Recipients)
        };

        public bool IsValid
        {
            get
            {
                return ValidatedProperties.All(property => GetValidationError(property) == null);
            }
        }

        private string GetValidationError(string propertyName)
        {
            switch (propertyName)
            {
                case "SenderEmail":
                    return ValidateSenderEmail();
                case "Recipients":
                    return ValidateRecipients();
                default:
                    return string.Empty;
            }
        }

        private string ValidateRecipients()
        {
            return Recipients == null ? "At least one Recipient should be added" : string.Empty;
        }

        private string ValidateSenderEmail()
        {
            return !string.IsNullOrEmpty(SenderEmail)
                ? !SenderEmail.IsValidEmail()
                    ?
                    "Incorrect email address"
                    : string.Empty
                : "The field Sender should not be empty";
        }
    }
}
