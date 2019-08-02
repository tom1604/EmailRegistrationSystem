using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
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
            Emails = new ObservableCollection<Email>
            {
                new Email
                {
                    Subtitle = "sssdfsdf",
                    EmailBody = "sfsafg",
                    SenderEmail = "sfdgsdfgs",
                    RegistrationDate = DateTime.Now,
                    Tegs = new ObservableCollection<Teg> {new Teg {Name = "asfasdf"}, new Teg {Name = "adfsgafgda"}},
                    Recipients = new ObservableCollection<Recipient>
                    {
                        new Recipient {Email = "afgadfgadf"},
                        new Recipient {Email = "dfgadfg"}
                    },
                },
                new Email
                {
                    Subtitle = "sssddfjufsdf",
                    EmailBody = "sfsrrafg",
                    SenderEmail = "sfdrrgsdfgs",
                    RegistrationDate = DateTime.Now,
                    Tegs = new ObservableCollection<Teg> {new Teg {Name = "asfarsdf"}, new Teg {Name = "adfsgafgda"}},
                    Recipients = new ObservableCollection<Recipient>
                    {
                        new Recipient {Email = "rarfgadfgadf"},
                        new Recipient {Email = "rdfgadfg"}
                    },
                },
                new Email
                {
                    Subtitle = "sssfdgdfsdf",
                    EmailBody = "sfsarfg",
                    SenderEmail = "sfdgrrsdfgs",
                    RegistrationDate = DateTime.Now,
                    Tegs = new ObservableCollection<Teg> {new Teg {Name = "arsfasdf"}, new Teg {Name = "r"}},
                    Recipients = new ObservableCollection<Recipient>
                    {
                        new Recipient {Email = "afgarrdfgadf"},
                        new Recipient {Email = "dfrgadfg"}
                    },
                },
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
