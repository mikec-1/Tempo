using System;

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
}
