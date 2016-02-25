using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Clay
{
    public class NombreLotColor : INotifyPropertyChanged
    {
        private int _nombrelot = 0;
        private string _color = "";

        public int NombreLot
        {
            get
            {
                return _nombrelot;
            }
            set
            {
                _nombrelot = value;
                NotifyPropertyChanged("NombreLot");
            }
        }

        public string Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
                NotifyPropertyChanged("Color");
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
