using RssModel;
using System;
using System.Xml;

namespace DataAccess
{
    public class UriFeedReader : IFeedReader
    {
        public Uri SourceUri { get; set; }

        public UriFeedReader(Uri sourceUri)
        {
            SourceUri = sourceUri;
        }

        public Feed ReadFeed()
        {
            var rssDoc = new XmlDocument();
            using (var rssReader = new XmlTextReader(SourceUri.AbsoluteUri))
            {
                rssDoc.Load(rssReader);
                var xmlFeedReader = new XmlFeedReader(rssDoc);
                return xmlFeedReader.ReadFeed();
            }
        }
    }
}
