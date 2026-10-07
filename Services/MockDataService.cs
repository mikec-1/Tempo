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
                ("Daily Mix 3", 60),
                ("Power Hour", 120),
                ("Workday Beats", 95),
                ("Sunrise Sessions", 42),
                ("Twilight Lounge", 67)
            };

            var owners = new string[] { "Tempo", "tempouser", "musicfan42" };

            for (int i = 0; i < playlists.Length; i++)
            {
                _playlists.Add(new PlaylistModel
                {
                    Title = playlists[i].Title,
                    SongCount = playlists[i].SongCount,
                    ThumbnailColor = colors[i % colors.Length],
                    Owner = owners[i % owners.Length]
                });
            }

            // Track pools by category (for deterministic generation)
            var popTracks = new (string Title, string Artist, TimeSpan Duration)[]
            {
                ("Midnight City", "M83", TimeSpan.FromSeconds(245)),
                ("Blinding Lights", "The Weeknd", TimeSpan.FromSeconds(201)),
                ("Levitating", "Dua Lipa", TimeSpan.FromSeconds(203)),
                ("Watermelon Sugar", "Harry Styles", TimeSpan.FromSeconds(174)),
                ("Bad Guy", "Billie Eilish", TimeSpan.FromSeconds(194)),
                ("Shape of You", "Ed Sheeran", TimeSpan.FromSeconds(234)),
                ("Uptown Funk", "Bruno Mars", TimeSpan.FromSeconds(269)),
                ("Shallow", "Lady Gaga", TimeSpan.FromSeconds(215)),
                ("Old Town Road", "Lil Nas X", TimeSpan.FromSeconds(157)),
                ("Circles", "Post Malone", TimeSpan.FromSeconds(215)),
                ("Someone Like You", "Adele", TimeSpan.FromSeconds(285)),
                ("Rolling in the Deep", "Adele", TimeSpan.FromSeconds(228)),
                ("Bohemian Rhapsody", "Queen", TimeSpan.FromSeconds(354)),
                ("Starboy", "The Weeknd", TimeSpan.FromSeconds(230)),
                ("Closer", "The Chainsmokers", TimeSpan.FromSeconds(244))
            };

            var electronicTracks = new (string Title, string Artist, TimeSpan Duration)[]
            {
                ("Strobe", "Deadmau5", TimeSpan.FromSeconds(632)),
                ("Windowlicker", "Aphex Twin", TimeSpan.FromSeconds(361)),
                ("Opus", "Eric Prydz", TimeSpan.FromSeconds(540)),
                ("Children", "Robert Miles", TimeSpan.FromSeconds(428)),
                ("Sandstorm", "Darude", TimeSpan.FromSeconds(224)),
                ("Levels", "Avicii", TimeSpan.FromSeconds(203)),
                ("Titanium", "David Guetta", TimeSpan.FromSeconds(245)),
                ("Feel So Close", "Calvin Harris", TimeSpan.FromSeconds(237)),
                ("Clarity", "Zedd", TimeSpan.FromSeconds(245)),
                ("Shelter", "Porter Robinson", TimeSpan.FromSeconds(228))
            };

            var rockTracks = new (string Title, string Artist, TimeSpan Duration)[]
            {
                ("Smells Like Teen Spirit", "Nirvana", TimeSpan.FromSeconds(301)),
                ("Enter Sandman", "Metallica", TimeSpan.FromSeconds(332)),
               ("Wonderwall", "Oasis", TimeSpan.FromSeconds(257)),
                ("Creep", "Radiohead", TimeSpan.FromSeconds(238)),
                ("Black Hole Sun", "Soundgarden", TimeSpan.FromSeconds(316)),
                ("Last Nite", "The Strokes", TimeSpan.FromSeconds(204)),
                ("Take Me Out", "Franz Ferdinand", TimeSpan.FromSeconds(237)),
                ("Reptilia", "The Strokes", TimeSpan.FromSeconds(219)),
                ("Mr. Brightside", "The Killers", TimeSpan.FromSeconds(225)),
                ("Somebody Told Me", "The Killers", TimeSpan.FromSeconds(193))
            };

            var chillTracks = new (string Title, string Artist, TimeSpan Duration)[]
            {
                ("Weightless", "Marconi Union", TimeSpan.FromSeconds(480)),
                ("Clair de Lune", "Debussy", TimeSpan.FromSeconds(302)),
                ("Gymnopédie No.1", "Erik Satie", TimeSpan.FromSeconds(186)),
                ("Ambient 1", "Brian Eno", TimeSpan.FromSeconds(421)),
                ("Xenogenesis", "Sasha", TimeSpan.FromSeconds(357)),
                ("Transatlanticism", "This Will Destroy You", TimeSpan.FromSeconds(540)),
                ("Holocene", "Bon Iver", TimeSpan.FromSeconds(337)),
                ("Re: Stacks", "Bon Iver", TimeSpan.FromSeconds(246)),
                ("Skinny Love", "Bon Iver", TimeSpan.FromSeconds(238)),
                ("Flume", "Bon Iver", TimeSpan.FromSeconds(183))
            };

            var jazzTracks = new (string Title, string Artist, TimeSpan Duration)[]
            {
                ("Take Five", "Dave Brubeck", TimeSpan.FromSeconds(320)),
                ("So What", "Miles Davis", TimeSpan.FromSeconds(547)),
                ("Blue in Green", "Miles Davis", TimeSpan.FromSeconds(329)),
                ("My Favorite Things", "John Coltrane", TimeSpan.FromSeconds(781)),
                ("A Love Supreme", "John Coltrane", TimeSpan.FromSeconds(446)),
                ("Birdland", "Weather Report", TimeSpan.FromSeconds(353)),
                ("Cantaloupe Island", "Herbie Hancock", TimeSpan.FromSeconds(312)),
                ("Chameleon", "Herbie Hancock", TimeSpan.FromSeconds(930)),
                ("Moanin'", "Art Blakey", TimeSpan.FromSeconds(548)),
                ("Freddie Freeloader", "Miles Davis", TimeSpan.FromSeconds(576))
            };

            var classicalTracks = new (string Title, string Artist, TimeSpan Duration)[]
            {
                ("Moonlight Sonata", "Beethoven", TimeSpan.FromSeconds(360)),
                ("Four Seasons - Spring", "Vivaldi", TimeSpan.FromSeconds(218)),
                ("Canon in D", "Pachelbel", TimeSpan.FromSeconds(297)),
                ("Nocturne Op.9 No.2", "Chopin", TimeSpan.FromSeconds(254)),
                ("Gymnopédie No.1", "Erik Satie", TimeSpan.FromSeconds(180)),
                ("Clair de Lune", "Debussy", TimeSpan.FromSeconds(305)),
                ("Rodeo - Hoedown", "Copland", TimeSpan.FromSeconds(242)),
                ("The Four Seasons - Winter", "Vivaldi", TimeSpan.FromSeconds(196)),
                ("Swan Lake - Waltz", "Tchaikovsky", TimeSpan.FromSeconds(185)),
                ("Boléro", "Ravel", TimeSpan.FromSeconds(540))
            };

            var indieTracks = new (string Title, string Artist, TimeSpan Duration)[]
            {
                ("Re: Stacks", "Bon Iver", TimeSpan.FromSeconds(240)),
                ("Holocene", "Bon Iver", TimeSpan.FromSeconds(337)),
                ("Flightless Bird", "American Football", TimeSpan.FromSeconds(251)),
                ("Take Me to the River", "Arcade Fire", TimeSpan.FromSeconds(249)),
                ("Intimidated", "Arcade Fire", TimeSpan.FromSeconds(208)),
                ("Skinny Love", "Bon Iver", TimeSpan.FromSeconds(238)),
                ("My Number", "Foals", TimeSpan.FromSeconds(257)),
                ("Myth", "SZA", TimeSpan.FromSeconds(241)),
                ("The Less I Know The Better", "Tame Impala", TimeSpan.FromSeconds(216)),
                ("Let It Happen", "Tame Impala", TimeSpan.FromSeconds(439))
            };

            var allPools = new[] { popTracks, electronicTracks, rockTracks, chillTracks, jazzTracks, classicalTracks, indieTracks };

            for (int i = 0; i < playlists.Length; i++)
            {
                var pool = allPools[i % allPools.Length];
                int seed = 0;
                foreach (char c in playlists[i].Title)
                    seed = (seed * 31 + c) & 0x7FFFFFFF;

                var tracks = new List<TrackModel>();
                for (int j = 0; j < Math.Min(playlists[i].SongCount, pool.Length); j++)
                {
                    int idx = (seed + j) % pool.Length;
                    var t = pool[idx];
                    tracks.Add(new TrackModel
                    {
                        Title = t.Title,
                        Artist = t.Artist,
                        Album = playlists[i].Title + " (Album)",
                        Duration = t.Duration
                    });
                }

                // If playlist has more songs than pool items, reuse with variations
                while (tracks.Count < playlists[i].SongCount)
                {
                    int dupIdx = tracks.Count % pool.Length;
                    var dup = pool[dupIdx];
                    tracks.Add(new TrackModel
                    {
                        Title = dup.Title + " (Remix)",
                        Artist = dup.Artist,
                        Album = playlists[i].Title + " (Album)",
                        Duration = dup.Duration
                    });
                }

                _playlists[i].Tracks = tracks;
            }

            // Quick access items for "Good evening" section
            var quickAccess = new (string Title, int ColorIndex)[]
            {
                ("Liked Songs", 0),
                ("Late Night Drive", 1),
                ("Focus Flow", 2),
                ("Chill Vibes", 3),
                ("Deep Focus", 6),
                ("Discover Weekly", 9)
            };

            foreach (var item in quickAccess)
            {
                _quickAccessItems.Add(new QuickAccessItem
                {
                    Title = item.Title,
                    ThumbnailColor = colors[item.ColorIndex % colors.Length]
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

            var jazzCards = new (string Title, string Description)[]
            {
                ("Jazz Classics", "Playlist"),
                ("Smooth Jazz", "Playlist"),
                ("Modern Jazz", "Playlist"),
                ("Late Night Jazz", "Playlist"),
                ("Jazz Fusion", "Playlist")
            };

            var jazz = new CardGroup { GroupTitle = "Jazz" };
            for (int i = 0; i < jazzCards.Length; i++)
            {
                var card = jazzCards[i];
                jazz.Cards.Add(new MusicCard
                {
                    Title = card.Title,
                    Description = card.Description,
                    ArtColor = colors[(i + 2) % colors.Length]
                });
            }
            _cardGroups.Add(jazz);

            var electronicCards = new (string Title, string Description)[]
            {
                ("Electronic Dreams", "Playlist"),
                ("Synthwave", "Playlist"),
                ("Deep House", "Playlist"),
                ("Techno Bunker", "Playlist"),
                ("Ambient Spaces", "Playlist")
            };

            var electronic = new CardGroup { GroupTitle = "Electronic" };
            for (int i = 0; i < electronicCards.Length; i++)
            {
                var card = electronicCards[i];
                electronic.Cards.Add(new MusicCard
                {
                    Title = card.Title,
                    Description = card.Description,
                    ArtColor = colors[(i + 4) % colors.Length]
                });
            }
            _cardGroups.Add(electronic);

            var rockCards = new (string Title, string Description)[]
            {
                ("Rock Anthems", "Playlist"),
                ("Indie Rock Mix", "Playlist"),
                ("Classic Rock Drive", "Playlist"),
                ("Alternative 2000s", "Playlist"),
                ("Post Punk Revival", "Playlist")
            };

            var rock = new CardGroup { GroupTitle = "Rock" };
            for (int i = 0; i < rockCards.Length; i++)
            {
                var card = rockCards[i];
                rock.Cards.Add(new MusicCard
                {
                    Title = card.Title,
                    Description = card.Description,
                    ArtColor = colors[(i + 1) % colors.Length]
                });
            }
            _cardGroups.Add(rock);

            var classicalCards = new (string Title, string Description)[]
            {
                ("Piano Focus", "Playlist"),
                ("String Quartets", "Playlist"),
                ("Orchestral Masters", "Playlist"),
                ("Modern Composers", "Playlist"),
                ("Baroque Essentials", "Playlist")
            };

            var classical = new CardGroup { GroupTitle = "Classical" };
            for (int i = 0; i < classicalCards.Length; i++)
            {
                var card = classicalCards[i];
                classical.Cards.Add(new MusicCard
                {
                    Title = card.Title,
                    Description = card.Description,
                    ArtColor = colors[(i + 8) % colors.Length]
                });
            }
            _cardGroups.Add(classical);
        }
    }
}
