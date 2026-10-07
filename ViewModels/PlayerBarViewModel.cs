using System.Windows.Input;
using Tempo.Utils;

namespace Tempo.ViewModels
{
    public class PlayerBarViewModel : ViewModelBase
    {
        private bool _isPlaying = true;
        private double _progress = 35;
        private double _volume = 70;

        public string TrackTitle { get; } = "Late Night Drive";
        public string Artist { get; } = "The Midnight";

        public bool IsPlaying
        {
            get => _isPlaying;
            set => SetProperty(ref _isPlaying, value);
        }

        public double Progress
        {
            get => _progress;
            set => SetProperty(ref _progress, value);
        }

        public double Volume
        {
            get => _volume;
            set => SetProperty(ref _volume, value);
        }

        public ICommand PlayPauseCommand { get; }

        public PlayerBarViewModel()
        {
            PlayPauseCommand = new RelayCommand(ExecutePlayPause);
        }

        private void ExecutePlayPause(object? parameter)
        {
            IsPlaying = !IsPlaying;
        }
    }
}
