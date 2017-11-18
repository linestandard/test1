using System;
using System.Collections.Generic;

namespace RssModel
{
    public class Feed
    {
        public string Title { get; }
        public string Description { get; }
        public Uri Link { get; }
        public IList<FeedItem> Items { get; }

        internal Feed(string title, string description, Uri link)
        {
            Title = title;
            Description = description;
            Link = link;
            Items = new List<FeedItem>();
        }

        public static Feed Read(Uri source)
        {
            return FeedReader.Read(source);
        }
    }
}
