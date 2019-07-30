using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmailManager.Models;

namespace EmailManager.ViewModels
{
    public class ListEmailsViewModel
    {
        public ObservableCollection<Email> Emails { get; set; }

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
    }
}
