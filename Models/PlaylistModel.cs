using System;
using System.Collections.Generic;

namespace Tempo.Models
{
    public class PlaylistModel
    {
        public string Title { get; set; } = "";
        public int SongCount { get; set; }
        public string ThumbnailColor { get; set; } = "";
    }

    public class TrackModel
    {
        public string Title { get; set; } = "";
        public string Artist { get; set; } = "";
        public string Album { get; set; } = "";
        public TimeSpan Duration { get; set; }
    }

    public class QuickAccessItem
    {
        public string Title { get; set; } = "";
        public string ThumbnailColor { get; set; } = "";
    }

    public class MusicCard
    {
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public string ArtColor { get; set; } = "";
    }

    public class CardGroup
    {
        public string GroupTitle { get; set; } = "";
        public List<MusicCard> Cards { get; } = new();
    }
}
