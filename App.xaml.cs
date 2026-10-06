using System.Windows;
using System.Windows.Interop;

namespace Tempo
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            DispatcherUnhandledException += (s, args) =>
                MessageBox.Show(args.Exception.Message, "Tempo Error", MessageBoxButton.OK, MessageBoxImage.Error);
            base.OnStartup(e);
        }
    }
}
