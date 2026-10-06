using System.Collections.ObjectModel;
using System.Windows;
using Tempo.Models;
using Tempo.Services;
using Tempo.ViewModels;

namespace Tempo.ViewModels
{
    public class SidebarViewModel : ViewModelBase
    {
        private readonly MockDataService _mockData;

        public ObservableCollection<PlaylistModel> Playlists { get; }

        public string SearchText { get; set; } = "";

        public SidebarViewModel(MockDataService mockData)
        {
            _mockData = mockData;
            Playlists = new ObservableCollection<PlaylistModel>(_mockData.Playlists);
        }
    }
}
