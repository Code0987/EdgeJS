using System;
using System.Net;
using System.Windows;
using System.Windows.Threading;

namespace EdgeTest {

    public partial class MainWindow : Window {
        private DispatcherTimer timer;

        public MainWindow() {
            InitializeComponent();
        }

        private void timer_Tick(object sender, EventArgs e) {
            App.Log((new WebClient()).DownloadString(new Uri(string.Format("http://localhost:{0}/{1}", EdgeServer.ServerPort, DateTime.Now.Ticks))));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            timer = new DispatcherTimer();

            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;

            timer.Start();
        }
    }
}