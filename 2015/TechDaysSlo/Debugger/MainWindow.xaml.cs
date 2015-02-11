using System;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace Debugger
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Files_Click(object sender, RoutedEventArgs e)
        {
            var json = File.ReadAllText("input.json");
            var xml = File.ReadAllText("input.xml");
            var html = File.ReadAllText("input.html");
        }

        private void Debug_Click(object sender, RoutedEventArgs e)
        {
            var instance = new MyClass();
        }
    }
}