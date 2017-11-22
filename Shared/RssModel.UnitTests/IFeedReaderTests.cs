using System;
using System.Collections.Generic;
using Xunit;

namespace RssModel.UnitTests
{
    public class IFeedReaderTests
    {
        [Fact]
        public void ReadFeed_AllDataFilledOut_ReturnsFeed()
        {
            var feedTitle = "MyFeedTitle";
            var feedDescription = "MyFeedDescription";
            var feedLinkText = "http://www.linestandard.com/MyFeedLinkText";
            var feedItemSpecs = new List<SampleFeedItemSpec>
            {
                new SampleFeedItemSpec
                {
                    FeedItemTitle = "MyFeedItemTitle0",
                    FeedItemDescription = "MyFeedItemDescription0",
                    FeedItemLinkText = "http://www.linestandard.com/MyFeedItemLinkText0"
                },
                new SampleFeedItemSpec
                {
                    FeedItemTitle = "MyFeedItemTitle1",
                    FeedItemDescription = "MyFeedItemDescription1",
                    FeedItemLinkText = "http://www.linestandard.com/MyFeedItemLinkText1"
                }
            };
            IFeedReader reader = new SampleFeedReader
            {
                FeedTitle = feedTitle,
                FeedDescription = feedDescription,
                FeedLinkText = feedLinkText,
                FeedItemSpecs = feedItemSpecs
            };

            var target = reader.ReadFeed();

            Assert.Equal(target.Title, feedTitle);
            Assert.Equal(target.Description, feedDescription);
            Assert.Equal(target.Link.AbsoluteUri, feedLinkText);
            for (int i = 0; i < target.Items.Count; i++)
            {
                Assert.Equal(target.Items[i].Title, feedItemSpecs[i].FeedItemTitle);
                Assert.Equal(target.Items[i].Description, feedItemSpecs[i].FeedItemDescription);
                Assert.Equal(target.Items[i].Link.AbsoluteUri, feedItemSpecs[i].FeedItemLinkText);
            }
        }

        private class SampleFeedReader : IFeedReader
        {
            public string FeedTitle { get; set; }
            public string FeedDescription { get; set; }
            public string FeedLinkText { get; set; }
            public IEnumerable<SampleFeedItemSpec> FeedItemSpecs { get; set; }

            public Feed ReadFeed()
            {
                var feed = new Feed(FeedTitle, FeedDescription, new Uri(FeedLinkText));

                if (FeedItemSpecs == null)
                    return feed;

                foreach (var item in FeedItemSpecs)
                    feed.AddFeedItem(new FeedItem(item.FeedItemTitle, item.FeedItemDescription, new Uri(item.FeedItemLinkText)));
                return feed;
            }
        }

        private class SampleFeedItemSpec
        {
            public string FeedItemTitle { get; set; }
            public string FeedItemDescription { get; set; }
            public string FeedItemLinkText { get; set; }
        }
    }
}
