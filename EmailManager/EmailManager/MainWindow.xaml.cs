﻿using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
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

            DataContext = new MainWindowViewModel();
        }

        private void BtnOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            BtnOpenMenu.Visibility = Visibility.Collapsed;
            BtnCloseMenu.Visibility = Visibility.Visible;
            ((MainWindowViewModel) DataContext).IsOpened = true;

            
        }

        private void BtnCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            BtnOpenMenu.Visibility = Visibility.Visible;
            BtnCloseMenu.Visibility = Visibility.Collapsed;
            ((MainWindowViewModel) DataContext).IsOpened = false;
        }

        private void BtnCloseWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void GridTopPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void BtnMinimizeWindow_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void CreateItem_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            FramePage.NavigationService.Navigate(new Uri("View/CreateEmailPage.xaml", UriKind.Relative));
        }

        private void ControlItem_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            FramePage.NavigationService.Navigate(new Uri("Controls/SuccessControl.xaml", UriKind.Relative));
        }

        private void SearchItem_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            FramePage.NavigationService.Navigate(new Uri("View/SearchEmailsPage.xaml", UriKind.Relative));
        }

        private void GridFrame_OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            BtnOpenMenu.Visibility = Visibility.Visible;
            BtnCloseMenu.Visibility = Visibility.Collapsed;
            if (((MainWindowViewModel) DataContext).IsOpened)
            {
                Storyboard storyboard = (Storyboard) FindResource("MenuClose");
                Storyboard.SetTarget(storyboard, GridMenu);
                storyboard.Begin();
                ((MainWindowViewModel) DataContext).IsOpened = false;
            }
        }
    }
}
