using System;

namespace RssModel
{
    public class FeedItem
    {
        public string Title { get; }
        public string Description { get; }
        public Uri Link { get; }

        public FeedItem(string title, string description, Uri link)
        {
            Title = title;
            Description = description;
            Link = link;
        }
    }
}
