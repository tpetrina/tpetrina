// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

using System;
using System.Reactive.Linq;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

namespace Rx4
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var textChanges = (from _ in Observable.FromEventPattern(tbEnter, "TextChanged")
                               select tbEnter.Text)
                               .Throttle(TimeSpan.FromMilliseconds(250));

            textChanges.ObserveOnDispatcher()
                       .Subscribe(t => lb.Items.Insert(0, t));



            var positions = (from _ in Observable.FromEventPattern<PointerRoutedEventArgs>(this, "PointerMoved")
                             let pos = _.EventArgs.GetCurrentPoint(null).Position
                             select pos);

            var changes = (from b in positions.Buffer(2, 1)
                           let diff = (b[1].X - b[0].X) / b[0].X
                           where Math.Abs(diff) > 0.01
                           select diff < 0 ? "left" : "right")
                          .DistinctUntilChanged();

            var res = from c in changes.Buffer(TimeSpan.FromSeconds(3), TimeSpan.FromSeconds(1))
                      where c.Count > 3
                      select true;

            res.ObserveOnDispatcher()
               .Subscribe(delegate { lb.Items.Insert(0, "Shaken!!!"); });

            changes.ObserveOnDispatcher()
                .Subscribe(p => lb.Items.Insert(0, p));




            //select pos.X < Window.Current.Bounds.Width / 2 ? "left" : "right");

            //mousePosChanges.ObserveOnDispatcher()
            //.Subscribe(pos => lb.Items.Insert(0, String.Format("({0}, {1})", pos.X, pos.Y)));
            //.Subscribe(pos => lb.Items.Insert(0, pos));
        }
    }
}
