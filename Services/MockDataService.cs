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
                ("Midnight City", "M83", TimeSpan.FromMinutes(4)),
                ("Blinding Lights", "The Weeknd", TimeSpan.FromMinutes(3)),
                ("Levitating", "Dua Lipa", TimeSpan.FromMinutes(3)),
                ("Watermelon Sugar", "Harry Styles", TimeSpan.FromMinutes(3)),
                ("Bad Guy", "Billie Eilish", TimeSpan.FromMinutes(3)),
                ("Shape of You", "Ed Sheeran", TimeSpan.FromMinutes(4)),
                ("Uptown Funk", "Bruno Mars", TimeSpan.FromMinutes(4)),
                ("Shallow", "Lady Gaga", TimeSpan.FromMinutes(3)),
                ("Old Town Road", "Lil Nas X", TimeSpan.FromMinutes(2)),
                ("Circles", "Post Malone", TimeSpan.FromMinutes(3)),
                ("Someone Like You", "Adele", TimeSpan.FromMinutes(4)),
                ("Rolling in the Deep", "Adele", TimeSpan.FromMinutes(3)),
                ("Bohemian Rhapsody", "Queen", TimeSpan.FromMinutes(6)),
                ("Starboy", "The Weeknd", TimeSpan.FromMinutes(3)),
                ("Closer", "The Chainsmokers", TimeSpan.FromMinutes(4))
            };

            var electronicTracks = new (string Title, string Artist, TimeSpan Duration)[]
            {
                ("Strobe", "Deadmau5", TimeSpan.FromMinutes(10)),
                ("Windowlicker", "Aphex Twin", TimeSpan.FromMinutes(6)),
                ("Opus", "Eric Prydz", TimeSpan.FromMinutes(9)),
                ("Children", "Robert Miles", TimeSpan.FromMinutes(7)),
                ("Sandstorm", "Darude", TimeSpan.FromMinutes(4)),
                ("Levels", "Avicii", TimeSpan.FromMinutes(3)),
                ("Titanium", "David Guetta", TimeSpan.FromMinutes(4)),
                ("Feel So Close", "Calvin Harris", TimeSpan.FromMinutes(4)),
                ("Clarity", "Zedd", TimeSpan.FromMinutes(4)),
                ("Shelter", "Porter Robinson", TimeSpan.FromMinutes(3))
            };

            var rockTracks = new (string Title, string Artist, TimeSpan Duration)[]
            {
                ("Smells Like Teen Spirit", "Nirvana", TimeSpan.FromMinutes(5)),
                ("Enter Sandman", "Metallica", TimeSpan.FromMinutes(5)),
               ("Wonderwall", "Oasis", TimeSpan.FromMinutes(4)),
                ("Creep", "Radiohead", TimeSpan.FromMinutes(3)),
                ("Black Hole Sun", "Soundgarden", TimeSpan.FromMinutes(5)),
                ("Last Nite", "The Strokes", TimeSpan.FromMinutes(3)),
                ("Take Me Out", "Franz Ferdinand", TimeSpan.FromMinutes(4)),
                ("Reptilia", "The Strokes", TimeSpan.FromMinutes(3)),
                ("Mr. Brightside", "The Killers", TimeSpan.FromMinutes(3)),
                ("Somebody Told Me", "The Killers", TimeSpan.FromMinutes(3))
            };

            var chillTracks = new (string Title, string Artist, TimeSpan Duration)[]
            {
                ("Weightless", "Marconi Union", TimeSpan.FromMinutes(8)),
                ("Clair de Lune", "Debussy", TimeSpan.FromMinutes(5)),
                ("Gymnopédie No.1", "Erik Satie", TimeSpan.FromMinutes(3)),
                ("Ambient 1", "Brian Eno", TimeSpan.FromMinutes(7)),
                ("Xenogenesis", "Sasha", TimeSpan.FromMinutes(6)),
                ("Transatlanticism", "This Will Destroy You", TimeSpan.FromMinutes(9)),
                ("Holocene", "Bon Iver", TimeSpan.FromMinutes(5)),
                ("Re: Stacks", "Bon Iver", TimeSpan.FromMinutes(4)),
                ("Skinny Love", "Bon Iver", TimeSpan.FromMinutes(3)),
                ("Flume", "Bon Iver", TimeSpan.FromMinutes(3))
            };

            var jazzTracks = new (string Title, string Artist, TimeSpan Duration)[]
            {
                ("Take Five", "Dave Brubeck", TimeSpan.FromMinutes(5)),
                ("So What", "Miles Davis", TimeSpan.FromMinutes(9)),
                ("Blue in Green", "Miles Davis", TimeSpan.FromMinutes(5)),
                ("My Favorite Things", "John Coltrane", TimeSpan.FromMinutes(13)),
                ("A Love Supreme", "John Coltrane", TimeSpan.FromMinutes(7)),
                ("Birdland", "Weather Report", TimeSpan.FromMinutes(6)),
                ("Cantaloupe Island", "Herbie Hancock", TimeSpan.FromMinutes(5)),
                ("Chameleon", "Herbie Hancock", TimeSpan.FromMinutes(15)),
                ("Moanin'", "Art Blakey", TimeSpan.FromMinutes(9)),
                ("Freddie Freeloader", "Miles Davis", TimeSpan.FromMinutes(9))
            };

            var classicalTracks = new (string Title, string Artist, TimeSpan Duration)[]
            {
                ("Moonlight Sonata", "Beethoven", TimeSpan.FromMinutes(6)),
                ("Four Seasons - Spring", "Vivaldi", TimeSpan.FromMinutes(3)),
                ("Canon in D", "Pachelbel", TimeSpan.FromMinutes(5)),
                ("Nocturne Op.9 No.2", "Chopin", TimeSpan.FromMinutes(4)),
                ("Gymnopédie No.1", "Erik Satie", TimeSpan.FromMinutes(3)),
                ("Clair de Lune", "Debussy", TimeSpan.FromMinutes(5)),
                ("Rodeo - Hoedown", "Copland", TimeSpan.FromMinutes(4)),
                ("The Four Seasons - Winter", "Vivaldi", TimeSpan.FromMinutes(3)),
                ("Swan Lake - Waltz", "Tchaikovsky", TimeSpan.FromMinutes(3)),
                ("Boléro", "Ravel", TimeSpan.FromMinutes(9))
            };

            var indieTracks = new (string Title, string Artist, TimeSpan Duration)[]
            {
                ("Re: Stacks", "Bon Iver", TimeSpan.FromMinutes(4)),
                ("Holocene", "Bon Iver", TimeSpan.FromMinutes(5)),
                ("Flightless Bird", "American Football", TimeSpan.FromMinutes(4)),
                ("Take Me to the River", "Arcade Fire", TimeSpan.FromMinutes(4)),
                ("Intimidated", "Arcade Fire", TimeSpan.FromMinutes(3)),
                ("Skinny Love", "Bon Iver", TimeSpan.FromMinutes(3)),
                ("My Number", "Foals", TimeSpan.FromMinutes(4)),
                ("Myth", "SZA", TimeSpan.FromMinutes(4)),
                ("The Less I Know The Better", "Tame Impala", TimeSpan.FromMinutes(3)),
                ("Let It Happen", "Tame Impala", TimeSpan.FromMinutes(7))
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
                    int idx = ((seed * (j + 1)) % pool.Length);
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
