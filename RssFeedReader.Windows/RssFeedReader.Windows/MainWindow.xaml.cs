using RssModel;
using System;
using System.Windows;


namespace RssFeedReader.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // TODO: temporary start
            var source = new Uri("http://feeds.feedburner.com/EtsBreakingNews");
            var feed = Feed.Read(source);
            // TODO: temporary end
        }
    }
}
