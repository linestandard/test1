using AppKit;
using Foundation;
using System;

namespace RssFeedReader.Mac
{
    [Register("AppDelegate")]
    public class AppDelegate : NSApplicationDelegate
    {
        public AppDelegate()
        {
        }

        public override void DidFinishLaunching(NSNotification notification)
        {
            // Insert code here to initialize your application

            // TODO: temporary start
            var source = new Uri("http://feeds.feedburner.com/EtsBreakingNews");
            var feed = RssModel.Feed.Read(source);
            var x = feed.Items.Count;
            // TODO: temporary end
        }

        public override void WillTerminate(NSNotification notification)
        {
            // Insert code here to tear down your application
        }
    }
}
