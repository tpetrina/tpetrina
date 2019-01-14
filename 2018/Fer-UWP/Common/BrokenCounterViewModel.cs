using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Common
{
    public class BrokenCounterViewModel
    {
        public int Counter { get; set; } = -1;

        public void Inc() => Counter++;

        public ICommand IncCommand { get; }

        public BrokenCounterViewModel()
        {
            IncCommand = new Command(IncImpl);
        }

        private void IncImpl(object o)
        {
            Counter++;
        }
    }

    public class CounterViewModel : BaseViewModel
    {
        private int counter;
        public int Counter
        {
            get => counter;
            private set
            {
                counter = value;
                RaisePropertyChanged();
            }
        }

        public void Inc() => Counter++;

        public ICommand IncCommand { get; }

        public CounterViewModel()
        {
            IncCommand = new Command(IncImpl);
        }

        private void IncImpl(object o)
        {
            Counter++;
        }
    }
}
