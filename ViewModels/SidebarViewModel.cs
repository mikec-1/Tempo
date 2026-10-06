using System.Collections.ObjectModel;
using Tempo.Models;
using Tempo.Services;
using Tempo.ViewModels;

namespace Tempo.ViewModels
{
    public class SidebarViewModel : ViewModelBase
    {
        public ObservableCollection<PlaylistModel> Playlists { get; }

        public string SearchText { get; set; } = "";

        public SidebarViewModel(MockDataService mockData)
        {
            Playlists = new ObservableCollection<PlaylistModel>(mockData.Playlists);
        }
    }
}
