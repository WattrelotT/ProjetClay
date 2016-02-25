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
        private readonly ObservableCollection<QualityLot> _qualitylot = new ObservableCollection<QualityLot>();
        public ObservableCollection<QualityLot> QualityLot
        {
            get
            {
                return _qualitylot;
            }
        }

        public MainViewModel(List<ClayData.Data> MalistDeData)
        {
            foreach (var a in MalistDeData)
            {
                int q;
                if(a.quality == "Low")
                {
                    q = 1;
                }
                else if(a.quality == "Medium")
                {
                    q = 2;
                }
                else
                {
                    q = 3;
                }
                _qualitylot.Add(new QualityLot() { Quality = q, Lot = int.Parse(a.lot) });
            }

            //_populations.Add(new Population() { Name = "China", Count = 1340 });
            //_populations.Add(new Population() { Name = "India", Count = 1220 });
            //_populations.Add(new Population() { Name = "United States", Count = 309 });
            //_populations.Add(new Population() { Name = "Indonesia", Count = 240 });
            //_populations.Add(new Population() { Name = "Brazil", Count = 195 });
            //_populations.Add(new Population() { Name = "Pakistan", Count = 174 });
            //_populations.Add(new Population() { Name = "Nigeria", Count = 158 });
        }
    }
}
