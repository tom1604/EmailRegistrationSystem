using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using EmailManager.Helpers;
using EmailManager.Models;
using Xceed.Wpf.Toolkit;

namespace EmailManager.ViewModels
{
    public class CreateEmailViewModel : INotifyPropertyChanged, IDataErrorInfo 
    {
        private RelayCommand _addCommand;
        private RelayCommand _deleteCommand;
        private RelayCommand _submitCommand;

        private string _enteredTegText;
        private string _enteredRecipientEmail;
        private Email _email;

        public CreateEmailViewModel()
        {
            Email = new Email();
        }

        public string EnteredTegText
        {
            get => _enteredTegText;
            set
            {
                _enteredTegText = value;
                OnPropertyChanged(nameof(EnteredTegText));
            }
        }

        public string EnteredRecipientEmail
        {
            get => _enteredRecipientEmail;
            set
            {
                _enteredRecipientEmail = value;
                OnPropertyChanged(nameof(EnteredRecipientEmail));
            }
        }

        public Email Email
        {
            get => _email;
            set
            {
                _email = value;
                //check valid
                OnPropertyChanged(nameof(Email));
            }
        }

        public RelayCommand DeleteCommand
        {
            get
            {
                return _deleteCommand ?? (_deleteCommand = new RelayCommand(obj =>
                {
                    if (obj != null)
                    {
                        Delete(obj);
                    }
                }));
            }
        }

        public RelayCommand AddCommand
        {
            get
            {
                return _addCommand ?? (_addCommand = new RelayCommand(obj =>
                {
                    if (obj != null)
                    {
                        AddObject(obj);
                    }
                }));
            }
        }

        public RelayCommand SubmitCommand
        {
            get
            {
                return _submitCommand ?? (_submitCommand = new RelayCommand(obj => {
                               if (obj != null)
                               {
                                   AddEmail(obj);
                               }
                           }
                       ));
            }
        }

        private void AddObject(object obj)
        {
            if (!(obj is WatermarkTextBox textBox))
            {
                return;
            }

            switch (textBox.Name)
            {
                case nameof(Recipient):
                    if (!string.IsNullOrWhiteSpace(EnteredRecipientEmail) && IsValidProperty("EnteredRecipientEmail"))
                    {
                        if (Email.Recipients == null)
                        {
                            Email.Recipients = new ObservableCollection<Recipient>();
                        }
                        Email.Recipients.Add(new Recipient(EnteredRecipientEmail));
                        EnteredRecipientEmail = string.Empty;
                    }
                    break;
                case nameof(Teg):
                    if (!string.IsNullOrWhiteSpace(EnteredTegText))
                    {
                        if (Email.Tegs == null)
                        {
                            Email.Tegs = new ObservableCollection<Teg>();
                        }

                        Email.Tegs.Add(new Teg(EnteredTegText));
                        EnteredTegText = string.Empty;
                    }
                    break;
            }
        }

        private void Delete(object obj)
        {
            switch(obj)
            {
                case Teg teg:
                    Email.Tegs?.Remove(teg);
                    break;
                case Recipient recipient:
                    Email.Recipients?.Remove(recipient);
                    break;

            }
        }

        private void AddEmail(object obj)
        {
            if (obj is Email email)
            {
                ////save email
                Email = new Email();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public string this[string propertyName] => GetValidationError(propertyName);

        public string Error => null;

        private bool IsValidProperty(string propertyName)
        {
            return string.IsNullOrEmpty(GetValidationError(propertyName));
        }

        private string GetValidationError(string propertyName)
        {
            switch (propertyName)
            {
                case "EnteredRecipientEmail":
                    return string.IsNullOrEmpty(EnteredRecipientEmail) ? string.Empty :
                        !EnteredRecipientEmail.IsValidEmail() 
                            ? "Incorrect email address" 
                            : string.Empty;
                default:
                    return string.Empty;
            }
        }
    }
}
