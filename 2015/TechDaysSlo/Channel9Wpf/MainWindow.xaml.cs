using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Channel9Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            //Debugger.Break();
            var root = await Downloader.DownloadAsync();
            if (root == null)
                return;

            //Debugger.Break();

            //var items = root.channel.item.OrderBy(i => i.creator)
            //    .ToList(); ;

            List.ItemsSource = root.channel.item
                                   .Where(i => i.thumbnail != null &&
                                               i.thumbnail.Any())
                                   .OrderBy(i => i.creator)
                                   .ToList();
            Trace.TraceInformation("Download complete");
        }
    }
}
