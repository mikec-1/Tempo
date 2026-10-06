using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Tempo.Views
{
    public partial class PlayerBar : UserControl
    {
        private bool _isPlaying = true;

        public PlayerBar()
        {
            InitializeComponent();
        }

        private void ProgressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Progress bar is visual only - no audio logic needed yet
        }
    }
}
