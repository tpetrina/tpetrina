using Common;
using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /*
        BrokenCounterViewModel vm = new BrokenCounterViewModel();
        /*/
        CounterViewModel vm = new CounterViewModel();
        //*/

        public MainWindow()
        {
            InitializeComponent();

            this.Counter.DataContext = vm;
        }

        private void Inc_Click(object sender, RoutedEventArgs e)
        {
            vm.Inc();
        }
    }
}
