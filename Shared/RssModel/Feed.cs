using System;
using System.Collections.Generic;

namespace RssModel
{
    public class Feed
    {
        public string Title { get; }
        public string Description { get; }
        public Uri Link { get; }

        private IList<FeedItem> Items { get; }

        public Feed(string title, string description, Uri link)
        {
            Title = title;
            Description = description;
            Link = link;
            Items = new List<FeedItem>();
        }

        public void AddFeedItem(FeedItem feedItem)
        {
            Items.Add(feedItem);
        }
    }
}
