using System;
using System.Collections.Generic;

namespace RssModel
{
    public class Feed
    {
        private readonly string title;
        private readonly string description;
        private readonly Uri link;
        private readonly IList<FeedItem> items;

        public string Title => title;
        public string Description => description;
        public Uri Link => link;
        public IList<FeedItem> Items => items;

        internal Feed(string title, string description, Uri link)
        {
            this.title = title;
            this.description = description;
            this.link = link;
            items = new List<FeedItem>();
        }

        public static Feed Read(Uri source)
        {
            return FeedReader.Read(source);
        }
    }
}
