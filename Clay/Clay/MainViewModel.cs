using ClayData;
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
        private readonly ObservableCollection<QualitiComponent> _qualitycomponent = new ObservableCollection<QualitiComponent>();
        private readonly ObservableCollection<PerformanceLayout> _performancelayout = new ObservableCollection<PerformanceLayout>();
        private readonly ObservableCollection<NombreLotColor> _nombrelotcolor = new ObservableCollection<NombreLotColor>();
        public ObservableCollection<QualityLot> QualityLot
        {
            get
            {
                return _qualitylot;
            }
        }
        public ObservableCollection<QualitiComponent> QualityComponent
        {
            get
            {
                return _qualitycomponent;
            }
        }
        public ObservableCollection<PerformanceLayout> PerformanceLayout
        {
            get
            {
                return _performancelayout;
            }
        }
        public ObservableCollection<NombreLotColor> NombreLotColor
        {
            get
            {
                return _nombrelotcolor;
            }
        }

        public MainViewModel(List<ClayData.Data> MalistDeData)
        {
            List<Couleur> MaListeDecouleur = new List<Couleur>();
            foreach (var a in MalistDeData)
            {
                if (!isInList(MaListeDecouleur, a.colorbound))
                {
                    MaListeDecouleur.Add(new Couleur() { name = a.colorbound, count = 0 });
                }
                

                int q;
                int p;
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

                if(a.performance == "Low")
                {
                    p = 1;
                }
                else if(a.performance == "Medium")
                {
                    p = 2;
                }
                else
                {
                    p = 3;
                }
                _qualitylot.Add(new QualityLot() { Quality = q, Lot = int.Parse(a.lot) });
                _qualitycomponent.Add(new QualitiComponent() { Quality = q, Component = a.component });
                _performancelayout.Add(new PerformanceLayout() { Performance = p, Layout = a.layout });
                
            }
            foreach ( Couleur item in MaListeDecouleur)
            {
                foreach ( Data d in MalistDeData)
                {
                    if ( d.colorbound == item.name){
                        item.count++;
                    }
                }
            }
            foreach (Couleur item in MaListeDecouleur)
            {
                _nombrelotcolor.Add(new NombreLotColor() { Color = item.name , NombreLot = item.count});
            }
            //_populations.Add(new Population() { Name = "China", Count = 1340 });
            //_populations.Add(new Population() { Name = "India", Count = 1220 });
            //_populations.Add(new Population() { Name = "United States", Count = 309 });
            //_populations.Add(new Population() { Name = "Indonesia", Count = 240 });
            //_populations.Add(new Population() { Name = "Brazil", Count = 195 });
            //_populations.Add(new Population() { Name = "Pakistan", Count = 174 });
            //_populations.Add(new Population() { Name = "Nigeria", Count = 158 });
        }

        private bool isInList(List<Couleur> list, string value)
        {
            foreach (Couleur item in list)
            {
                if (item.name == value)
                {
                    return true;
                }
            }
            return false;

        }
    }
}
