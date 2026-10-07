using System;
using System.Windows;
using System.Windows.Media;
using Tempo.ViewModels;

namespace Tempo.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        protected override void OnStateChanged(EventArgs e)
        {
            base.OnStateChanged(e);

            if (WindowState == WindowState.Maximized)
            {
                RootGrid.Margin = new Thickness(8);
                MaximizeIcon.Data = (Geometry)FindResource("RestoreGeometry");
            }
            else
            {
                RootGrid.Margin = new Thickness(0);
                MaximizeIcon.Data = (Geometry)FindResource("MaximizeGeometry");
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
