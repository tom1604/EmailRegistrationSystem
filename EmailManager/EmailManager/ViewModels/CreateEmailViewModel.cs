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
        public ObservableCollection<Teg> Tegs { get; set; }
        public ObservableCollection<Recipient> Recipients { get; set; }

        private RelayCommand _addCommand;
        private RelayCommand _deleteCommand;

        private string _enteredTegText;
        private string _enteredRecipientEmail;
        private Email _email;

        public CreateEmailViewModel()
        {
            Email = new Email();
            Tegs = new ObservableCollection<Teg>();
            Recipients = new ObservableCollection<Recipient>();
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
                        Recipients.Add(new Recipient { Email = EnteredRecipientEmail });
                        EnteredRecipientEmail = string.Empty;
                    }
                    break;
                case nameof(Teg):
                    if (!string.IsNullOrWhiteSpace(EnteredTegText))
                    {
                        Tegs.Add(new Teg {Name = EnteredTegText});
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
                    Tegs.Remove(teg);
                    break;
                case Recipient recipient:
                    Recipients.Remove(recipient);
                    break;

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public string this[string propertyName] => GetValidationError(propertyName);

        public string Error { get; }

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
