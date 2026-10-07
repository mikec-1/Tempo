using System.Collections.Generic;
using Tempo.Models;
using Tempo.Services;

namespace Tempo.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public List<QuickAccessItem> QuickAccessItems { get; }
        public List<CardGroup> CardGroups { get; }

        public HomeViewModel(MockDataService mockData)
        {
            QuickAccessItems = mockData.QuickAccessItems;
            CardGroups = mockData.CardGroups;
        }
    }
}
