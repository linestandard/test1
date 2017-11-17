using System;

namespace RssModel
{
    public class FeedItem
    {
        private readonly string title;
        private readonly string description;
        private readonly Uri link;

        public string Title => title;
        public string Description => description;
        public Uri Link => link;

        public FeedItem(string title, string description, Uri link)
        {
            this.title = title;
            this.description = description;
            this.link = link;
        }
    }
}
