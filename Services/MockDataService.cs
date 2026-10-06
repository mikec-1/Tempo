using System.Collections.ObjectModel;
using Tempo.Models;

namespace Tempo.Services
{
    public class MockDataService
    {
        private readonly ObservableCollection<PlaylistModel> _playlists = new();

        public ObservableCollection<PlaylistModel> Playlists => _playlists;

        public MockDataService()
        {
            var colors = new[] { "#1ED760", "#E91E63", "#9C27B0", "#2196F3", "#FF9800",
                "#FF5722", "#795548", "#607D8B", "#00BCD4", "#3F51B5" };

            var playlists = new (string Title, int SongCount)[]
            {
                ("Liked Songs", 342),
                ("Late Night Drive", 87),
                ("Focus Flow", 124),
                ("Chill Vibes", 65),
                ("Workout Energy", 93),
                ("Weekend Reset", 48),
                ("Deep Focus", 156),
                ("Indie Mix", 72),
                ("Throwback Jams", 201),
                ("Sleepytime", 38),
                ("Morning Coffee", 55),
                ("Road Trip", 110),
                ("Study Session", 89),
                ("Gym Grind", 76),
                ("Lo-Fi Beats", 143),
                ("Discover Weekly", 30),
                ("Release Radar", 50),
                ("Daily Mix 1", 60),
                ("Daily Mix 2", 60),
                ("Daily Mix 3", 60)
            };

            for (int i = 0; i < playlists.Length; i++)
            {
                _playlists.Add(new PlaylistModel
                {
                    Title = playlists[i].Title,
                    SongCount = playlists[i].SongCount,
                    ThumbnailColor = colors[i % colors.Length]
                });
            }
        }
    }
}
