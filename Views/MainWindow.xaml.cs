using System;
using System.Windows;
using Tempo.ViewModels;

namespace Tempo.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
            MouseLeftButtonDown += OnTitleBarMouseLeftButtonDown;
            MouseDoubleClick += OnTitleBarMouseDoubleClick;
        }

        private void OnTitleBarMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void OnTitleBarMouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
            }
            else
            {
                WindowState = WindowState.Maximized;
            }
        }

        protected override void OnStateChanged(EventArgs e)
        {
            base.OnStateChanged(e);
            
            if (WindowState == WindowState.Maximized)
            {
                Margin = new Thickness(-8, 0, -8, -8);
            }
            else
            {
                Margin = new Thickness(0);
            }
        }

        private void OnMinimizeClick(object sender, System.Windows.RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void OnMaximizeClick(object sender, System.Windows.RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
            }
            else
            {
                WindowState = WindowState.Maximized;
            }
        }

        private void OnCloseClick(object sender, System.Windows.RoutedEventArgs e)
        {
            Close();
        }
    }
}
