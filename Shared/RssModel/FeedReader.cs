using System;
using System.Xml;

namespace RssModel
{
    internal static class FeedReader
    {
        internal static Feed Read(Uri source)
        {
            var rssDoc = new XmlDocument();
            using (var rssReader = new XmlTextReader(source.AbsoluteUri))
            {
                rssDoc.Load(rssReader);
            }

            XmlNode rssNode = null;
            XmlNode channelNode = null;

            for (int i = 0; i < rssDoc.ChildNodes.Count; ++i)
            {
                if (rssDoc.ChildNodes[i].Name == "rss")
                {
                    rssNode = rssDoc.ChildNodes[i];
                    break;
                }
            }

            if (rssNode == null)
            {
                return null;
            }

            for (int i = 0; i < rssNode.ChildNodes.Count; ++i)
            {
                if (rssNode.ChildNodes[i].Name == "channel")
                {
                    channelNode = rssNode.ChildNodes[i];
                    break;
                }
            }

            if (channelNode == null)
            {
                return null;
            }

            Feed feed = new Feed(channelNode["title"].InnerText, channelNode["description"].InnerText, new Uri(channelNode["link"].InnerText));

            for (int i = 0; i < channelNode.ChildNodes.Count; ++i)
            {
                XmlNode itemNode = channelNode.ChildNodes[i];
                if (itemNode.Name == "item")
                {
                    FeedItem item = new FeedItem(itemNode["title"].InnerText, itemNode["description"].InnerText, new Uri(itemNode["link"].InnerText));
                    feed.Items.Add(item);
                }
            }

            return feed;
        }
    }
}
