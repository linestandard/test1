using DataAccess;
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
            var sourceUri = new Uri("http://feeds.feedburner.com/EtsBreakingNews");
            var uriFeedReader = new UriFeedReader(sourceUri);
            var feed = uriFeedReader.ReadFeed();
            // TODO: temporary end
        }
    }
}
