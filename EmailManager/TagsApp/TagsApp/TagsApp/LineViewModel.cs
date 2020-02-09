using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TagsApp
{
    public class LineViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Line> Lines { get; set; } = new ObservableCollection<Line> { new Line { Title = "sdfsdf" }, new Line { Title = "sdfsdf" } };
        private RelayCommand addCommand;
        private RelayCommand deleteCommand;

        private Line enteredLine;

        public Line EnteredLine
        {
            get { return enteredLine; }
            set
            {
                enteredLine = value;
                OnPropertyChanged("EnteredLine");
            }
        }

        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ?? (deleteCommand = new RelayCommand(obj =>
                {
                    DeleteLine((Line)obj);
                }));
            }
        }

        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ?? (addCommand = new RelayCommand(obj =>
                  {
                      Lines.Insert(0, new Line { Title = (string) obj });
                }));
            }
        }

        private void DeleteLine(Line obj)
        {
            if(obj != null && Lines != null)
            {
                Lines.Remove(obj);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
