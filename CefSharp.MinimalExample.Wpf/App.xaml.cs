using System;
using System.Windows;
using System.Windows.Threading;

namespace CefSharp.MinimalExample.Wpf
{
    public partial class App : Application
    {
        public App()
        {
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var splashScreen = new SplashScreen();
            splashScreen.AppInitilizationDone += SplashScreenOnAppInitilizationDone;
            //MainWindow = splashScreen;
            splashScreen.Show();

            base.OnStartup(e);
        }

        private void SplashScreenOnAppInitilizationDone(object sender, EventArgs eventArgs)
        {
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
            {
                var splashScreen = MainWindow;
                MainWindow = new MainWindow();
                splashScreen.Close();
                MainWindow.Show();
            }));
        }
    }
}
