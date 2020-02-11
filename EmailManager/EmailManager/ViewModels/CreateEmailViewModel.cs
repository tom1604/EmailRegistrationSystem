using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using EmailManager.Models;

namespace EmailManager.ViewModels
{
    public class CreateEmailViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Teg> Tegs { get; set; }

        private RelayCommand _addCommand;
        private RelayCommand _deleteCommand;

        private string _enteredTegText;
        private Email _email;

        public CreateEmailViewModel()
        {
            Email = new Email();
            Tegs = new ObservableCollection<Teg>();
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
                    DeleteLine((Teg)obj);
                }));
            }
        }

        public RelayCommand AddCommand
        {
            get
            {
                return _addCommand ?? (_addCommand = new RelayCommand(obj =>
                {
                    var teg = obj as string;
                    if (string.IsNullOrWhiteSpace(teg))
                    {
                        return;
                    }

                    CreateTeg(teg);
                    EnteredTegText = string.Empty;
                }));
            }
        }

        private void CreateTeg(string value)
        {
            Tegs.Add(new Teg{Name = value});
        }

        private void DeleteLine(Teg teg)
        {
            if (teg != null)
            {
                Tegs.Remove(teg);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
