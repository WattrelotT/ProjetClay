using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clay
{
    public class MainViewModel
    {
        private readonly ObservableCollection<Population> _populations = new ObservableCollection<Population>();
        public ObservableCollection<Population> Populations
        {
            get
            {
                return _populations;
            }
        }

        public MainViewModel()
        {
            _populations.Add(new Population() { Name = "China", Count = 1340 });
            _populations.Add(new Population() { Name = "India", Count = 1220 });
            _populations.Add(new Population() { Name = "United States", Count = 309 });
            _populations.Add(new Population() { Name = "Indonesia", Count = 240 });
            _populations.Add(new Population() { Name = "Brazil", Count = 195 });
            _populations.Add(new Population() { Name = "Pakistan", Count = 174 });
            _populations.Add(new Population() { Name = "Nigeria", Count = 158 });
        }
    }
}
