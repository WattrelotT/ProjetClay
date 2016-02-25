using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Clay
{
    public class QualityLot : INotifyPropertyChanged
    {
        private int _quality = 0;
        private double _lot = 0;

        public int Quality
        {
            get
            {
                return _quality;
            }
            set
            {
                _quality = value;
                NotifyPropertyChanged("Quality");
            }
        }

        public double Lot
        {
            get
            {
                return _lot;
            }
            set
            {
                _lot = value;
                NotifyPropertyChanged("Lot");
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
