using RssModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace DataAccess
{
    public class XmlFeedReader : IFeedReader
    {
        public XmlDocument RssDoc { get; }

        public XmlFeedReader(XmlDocument rssDoc)
        {
            RssDoc = rssDoc;
        }

        public Feed ReadFeed()
        {
            var rssChannelNode = ReadRssChannelNode();

            var feed = new Feed(rssChannelNode["title"].InnerText, rssChannelNode["description"].InnerText, new Uri(rssChannelNode["link"].InnerText));

            foreach (var itemNode in ReadNamedChildNodes(rssChannelNode, "item"))
            {
                var item = new FeedItem(itemNode["title"].InnerText, itemNode["description"].InnerText, new Uri(itemNode["link"].InnerText));
                feed.AddFeedItem(item);
            }

            return feed;
        }

        private XmlNode ReadRssChannelNode()
        {
            var rssNode = ReadRssNode();
            return ReadSingleNamedChildNode(rssNode, "channel");
        }

        private XmlNode ReadRssNode()
        {
            return ReadSingleNamedChildNode(RssDoc, "rss");
        }

        private IList<XmlNode> ReadNamedChildNodes(XmlNode parentNode, string childNodeName)
        {
            var childNodes = new List<XmlNode>();

            foreach (XmlNode childNode in parentNode.ChildNodes)
            {
                if (childNode.Name == childNodeName)
                    childNodes.Add(childNode);
            }

            if (childNodes.Count == 0)
                throw new ApplicationException($"Child node <{childNodeName}> not found in parent node <{parentNode.Name}>");

            return childNodes;
        }

        private XmlNode ReadSingleNamedChildNode(XmlNode parentNode, string childNodeName)
        {
            for (int i = 0; i < parentNode.ChildNodes.Count; ++i)
            {
                if (parentNode.ChildNodes[i].Name == childNodeName)
                {
                    var rssNode = parentNode.ChildNodes[i];
                    return rssNode;
                }
            }

            throw new ApplicationException($"Child node <{childNodeName}> not found in parent node <{parentNode.Name}>");
        }
    }
}
