using Tempo.Services;
using Tempo.ViewModels;

namespace Tempo.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MockDataService MockData { get; }
        public SidebarViewModel Sidebar { get; }
        public PlayerBarViewModel PlayerBar { get; }

        public MainViewModel()
        {
            MockData = new MockDataService();
            Sidebar = new SidebarViewModel(MockData);
            PlayerBar = new PlayerBarViewModel();
        }
    }
}
