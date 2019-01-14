using Common;
using System;
using Xamarin.Forms;

namespace Xamarin
{
    public partial class MainPage : ContentPage
    {
        /*
        BrokenCounterViewModel vm = new BrokenCounterViewModel();
        /*/
        CounterViewModel vm = new CounterViewModel();
        //*/

        public MainPage()
        {
            this.InitializeComponent();
            this.Counter.BindingContext = vm;
        }

        private void Inc_Click(object sender, EventArgs e)
        {
            vm.Inc();
        }
    }
}
