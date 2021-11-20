namespace YoutubeVideos.Models
{
    public class Video {
        public int Id { get; set; }
        public string Category { get; set; }
        public string ChannelName { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public DateTime AddedOn { get; set; } = DateTime.Now;
    }
}