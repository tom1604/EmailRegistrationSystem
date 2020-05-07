using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
using EmailManager.Interfaces;

namespace EmailManager
{
    public partial class MainWindow : Window
    {
        private static bool IsOpenedMenu { get; set; }

        public MainWindow(IMainViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        private void BtnOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            BtnOpenMenu.Visibility = Visibility.Collapsed;
            BtnCloseMenu.Visibility = Visibility.Visible;
            IsOpenedMenu = true;
        }

        private void BtnCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            BtnOpenMenu.Visibility = Visibility.Visible;
            BtnCloseMenu.Visibility = Visibility.Collapsed;
            IsOpenedMenu = false;
        }

        private void BtnCloseWindow_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void GridTopPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        private void BtnMinimizeWindow_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void GridFrame_OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (IsOpenedMenu)
            {
                BtnOpenMenu.Visibility = Visibility.Visible;
                BtnCloseMenu.Visibility = Visibility.Collapsed;
                var storyboard = (Storyboard) FindResource("MenuClose");
                Storyboard.SetTarget(storyboard, GridMenu);
                storyboard.Begin();
                IsOpenedMenu = false;
            }
        }
    }
}
