using System;
using System.Collections.ObjectModel;
using Tempo.Models;
using Tempo.Services;
using Tempo.Utils;
using System.Windows.Input;

namespace Tempo.ViewModels
{
    public class SidebarViewModel : ViewModelBase
    {
        public ObservableCollection<PlaylistModel> Playlists { get; }
        public string SearchText { get; set; } = "";
        public ICommand OpenPlaylistCommand { get; }

        public SidebarViewModel(MockDataService mockData, Action<PlaylistModel> onOpen)
        {
            Playlists = new ObservableCollection<PlaylistModel>(mockData.Playlists);
            OpenPlaylistCommand = new RelayCommand(p => onOpen((PlaylistModel)p!));
        }
    }
}
