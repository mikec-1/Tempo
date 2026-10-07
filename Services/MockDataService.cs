using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Tempo.Models;
using Tempo.Services;

namespace Tempo.Services
{
    public class MockDataService
    {
        private readonly ObservableCollection<PlaylistModel> _playlists = new();
        private readonly List<QuickAccessItem> _quickAccessItems = new();
        private readonly List<CardGroup> _cardGroups = new();

        public ObservableCollection<PlaylistModel> Playlists => _playlists;
        public List<QuickAccessItem> QuickAccessItems => _quickAccessItems;
        public List<CardGroup> CardGroups => _cardGroups;

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

            // Quick access items for "Good evening" section
            var quickAccess = new (string Title, int ColorIndex)[]
            {
                ("Liked Songs", 0),
                ("Late Night Drive", 1),
                ("Focus Flow", 2),
                ("Chill Vibes", 3),
                ("Deep Focus", 6),
                ("Discover Weekly", 15)
            };

            foreach (var item in quickAccess)
            {
                _quickAccessItems.Add(new QuickAccessItem
                {
                    Title = item.Title,
                    ThumbnailColor = colors[item.ColorIndex]
                });
            }

            // Card groups for home page
            var madeForYouCards = new (string Title, string Description)[]
            {
                ("Daily Mix 1", "The Midnight, Timeless, Paddedwall"),
                ("Daily Mix 2", "Bon Iver, Radiohead, Max Richter"),
                ("Daily Mix 3", "Tycho, Emancipator, Bonobo"),
                ("Discover Weekly", "Your weekly mixtape of fresh music"),
                ("Release Radar", "New releases tailored for you")
            };

            var madeForYou = new CardGroup { GroupTitle = "Made for you" };
            foreach (var card in madeForYouCards)
            {
                int idx = Array.IndexOf(madeForYouCards, card);
                madeForYou.Cards.Add(new MusicCard
                {
                    Title = card.Title,
                    Description = card.Description,
                    ArtColor = colors[idx % colors.Length]
                });
            }
            _cardGroups.Add(madeForYou);

            var recentlyPlayedCards = new (string Title, string Description)[]
            {
                ("Chill Vibes", "Playlist"),
                ("Late Night Drive", "Playlist"),
                ("Indie Mix", "Playlist"),
                ("Throwback Jams", "Playlist"),
                ("Workout Energy", "Playlist")
            };

            var recentlyPlayed = new CardGroup { GroupTitle = "Recently played" };
            for (int i = 0; i < recentlyPlayedCards.Length; i++)
            {
                var card = recentlyPlayedCards[i];
                recentlyPlayed.Cards.Add(new MusicCard
                {
                    Title = card.Title,
                    Description = card.Description,
                    ArtColor = colors[(i + 3) % colors.Length]
                });
            }
            _cardGroups.Add(recentlyPlayed);

            var popularCards = new (string Title, string Description)[]
            {
                ("Lo-Fi Beats", "Playlist"),
                ("Morning Coffee", "Playlist"),
                ("Road Trip", "Playlist"),
                ("Study Session", "Playlist"),
                ("Gym Grind", "Playlist")
            };

            var popular = new CardGroup { GroupTitle = "Popular playlists" };
            for (int i = 0; i < popularCards.Length; i++)
            {
                var card = popularCards[i];
                popular.Cards.Add(new MusicCard
                {
                    Title = card.Title,
                    Description = card.Description,
                    ArtColor = colors[(i + 5) % colors.Length]
                });
            }
            _cardGroups.Add(popular);

            var sleepCards = new (string Title, string Description)[]
            {
                ("Sleepytime", "Playlist"),
                ("Deep Focus", "Playlist"),
                ("Ambient Calm", "Playlist"),
                ("Rain Sounds", "Playlist"),
                ("Night Drive", "Playlist")
            };

            var sleep = new CardGroup { GroupTitle = "Sleep" };
            for (int i = 0; i < sleepCards.Length; i++)
            {
                var card = sleepCards[i];
                sleep.Cards.Add(new MusicCard
                {
                    Title = card.Title,
                    Description = card.Description,
                    ArtColor = colors[(i + 7) % colors.Length]
                });
            }
            _cardGroups.Add(sleep);
        }
    }
}
