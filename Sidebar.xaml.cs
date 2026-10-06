using System.Windows.Controls;
using Tempo.Services;
using Tempo.ViewModels;

namespace Tempo
{
    public partial class Sidebar : UserControl
    {
        private readonly SidebarViewModel _viewModel;

        public Sidebar()
        {
            InitializeComponent();
            var mockData = new MockDataService();
            _viewModel = new SidebarViewModel(mockData);
            DataContext = _viewModel;
        }
    }
}
