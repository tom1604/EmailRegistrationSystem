using System.Windows.Controls;
using EmailManager.ViewModels;

namespace EmailManager.View
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class CreateEmailPage : Page
    {
        public CreateEmailPage()
        {
            InitializeComponent();

            this.DataContext = new CreateEmailViewModel();
        }
    }
}
