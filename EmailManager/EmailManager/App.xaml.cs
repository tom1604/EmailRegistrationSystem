using System.Windows;
using EmailManager.Integration;

namespace EmailManager
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var viewModel = CompositionRoot.MainViewModel;
            var view = new MainWindow (viewModel); 
            view.Show();
        }
    }
}
