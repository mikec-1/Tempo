using System;
using System.Collections.Generic;
using System.Linq;
using Tempo.Models;
using Tempo.Services;
using Tempo.Utils;
using System.Windows.Input;

namespace Tempo.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public List<QuickAccessItem> QuickAccessItems { get; }
        public List<CardGroup> CardGroups { get; }
        public ICommand OpenPlaylistCommand { get; }
        private readonly MockDataService _mockData;

        public HomeViewModel(MockDataService mockData, Action<PlaylistModel> onOpen)
        {
            _mockData = mockData;
            QuickAccessItems = mockData.QuickAccessItems;
            CardGroups = mockData.CardGroups;
            OpenPlaylistCommand = new RelayCommand(p =>
            {
                var title = p as string;
                if (title != null)
                {
                    var playlist = _mockData.Playlists.FirstOrDefault(pl => pl.Title == title);
                    if (playlist != null)
                        onOpen(playlist);
                }
            });
        }
    }
}
