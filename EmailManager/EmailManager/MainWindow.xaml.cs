using System.Windows;
using EmailManager.ViewModels;

namespace EmailManager
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new ListEmailsViewModel();
        }
    }
}
