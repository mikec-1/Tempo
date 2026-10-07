using Tempo.Services;
using Tempo.ViewModels;
using Tempo.Models;
using System.Windows.Input;
using Tempo.Utils;

namespace Tempo.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MockDataService MockData { get; }
        public SidebarViewModel Sidebar { get; }
        public PlayerBarViewModel PlayerBar { get; }
        public HomeViewModel HomeContent { get; }

        private PlaylistModel? _currentPlaylist;
        public PlaylistModel? CurrentPlaylist
        {
            get => _currentPlaylist;
            set => SetProperty(ref _currentPlaylist, value);
        }

        public ICommand GoBackCommand { get; }

        public MainViewModel()
        {
            MockData = new MockDataService();
            Sidebar = new SidebarViewModel(MockData, OpenPlaylist);
            PlayerBar = new PlayerBarViewModel();
            HomeContent = new HomeViewModel(MockData, OpenPlaylist);
            GoBackCommand = new RelayCommand(_ => GoBack(), _ => CurrentPlaylist != null);
        }

        private void OpenPlaylist(PlaylistModel playlist)
        {
            CurrentPlaylist = playlist;
        }

        private void GoBack()
        {
            CurrentPlaylist = null;
        }
    }
}
