using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using EdgeJs;

namespace EdgeTest {

    public partial class App : Application {

        public static void Log(string message) {
            (App.Current.MainWindow as MainWindow).TextView.Text += string.Format("[{0}] {1}\n", DateTime.Now.ToLongTimeString(), message);
            (App.Current.MainWindow as MainWindow).TextView.ScrollToEnd();
        }

        private void Application_Exit(object sender, ExitEventArgs e) {
            EdgeServer.Stop().ConfigureAwait(false);
        }

        private void Application_Startup(object sender, StartupEventArgs e) {
            EdgeServer.Start().ConfigureAwait(false);
        }
    }
}