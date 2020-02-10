using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TagsApp
{
    public class LineViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Line> Lines { get; set; }
        private RelayCommand _addCommand;
        private RelayCommand _deleteCommand;
        private string _enteredTagText;

        public LineViewModel()
        {
            Lines = new ObservableCollection<Line>();
        }

        public string EnteredTagText
        {
            get => _enteredTagText;
            set
            {
                _enteredTagText = value;
                OnPropertyChanged(nameof(EnteredTagText));
            }
        }

        public RelayCommand DeleteCommand
        {
            get
            {
                return _deleteCommand ?? (_deleteCommand = new RelayCommand(obj =>
                {
                    DeleteLine((Line)obj);
                }));
            }
        }

        public RelayCommand AddCommand
        {
            get
            {
                return _addCommand ?? (_addCommand = new RelayCommand(obj =>
                {
                    var line = obj as string;
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        return;
                    }

                    Lines.Insert(0, new Line { Title = line });
                    EnteredTagText = string.Empty;
                }));
            }
        }

        private void DeleteLine(Line line)
        {
            if(line != null)
            {
                Lines.Remove(line);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
