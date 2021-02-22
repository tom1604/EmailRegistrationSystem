using System.Windows.Controls;
using EmailManager.Interfaces;

namespace EmailManager.View
{
    public partial class CreateEmailPage : Page
    {
        public CreateEmailPage(ICreateEmailViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
