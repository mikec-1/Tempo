using System;
using System.IO;
using System.Windows;
using System.Windows.Interop;

namespace Tempo
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            DispatcherUnhandledException += (s, args) =>
            {
                Exception ex = args.Exception;
                while (ex.InnerException != null)
                    ex = ex.InnerException;

                MessageBox.Show(ex.Message, "Tempo Error", MessageBoxButton.OK, MessageBoxImage.Error);

                try
                {
                    string crashLogPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "crash.log");
                    File.WriteAllText(crashLogPath, args.Exception.ToString());
                }
                catch { }

                args.Handled = true;

                if (MainWindow == null || !MainWindow.IsVisible)
                    Shutdown();
            };
            base.OnStartup(e);
        }
    }
}
