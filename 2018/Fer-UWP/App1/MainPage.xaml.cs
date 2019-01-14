using Common;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace App1
{
    public sealed partial class MainPage : Page
    {
        /*
        BrokenCounterViewModel vm = new BrokenCounterViewModel();
        /*/
        CounterViewModel vm = new CounterViewModel();
        //*/

        public MainPage()
        {
            this.InitializeComponent();
            this.CounterHolder.DataContext = vm;

            this.Web.DataContext = new PostsViewModel();
        }

        private void Inc_Click(object sender, RoutedEventArgs e)
        {
            vm.Inc();
        }
    }
}
