using System;
using System.Collections.ObjectModel;

namespace Tempo.Services
{
    public class MockDataService
    {
        private readonly ObservableCollection<Models.PlaylistModel> _playlists = new();
        private readonly Random _random = new();

        public ObservableCollection<Models.PlaylistModel> Playlists => _playlists;

        public MockDataService()
        {
            var colors = new[] { "#1ED760", "#E91E63", "#9C27B0", "#2196F3", "#FF9800", "#FF5722",
                "#795548", "#607D8B", "#00BCD4", "#3F51B5" };

            for (int i = 0; i < 20; i++)
            {
                _playlists.Add(new Models.PlaylistModel
                {
                    Title = $"Playlist #{i + 1}",
                    SongCount = _random.Next(10, 100),
                    ThumbnailColor = colors[i % colors.Length]
                });
            }
        }
    }
}
