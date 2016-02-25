using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Clay
{
    public class QualitiComponent : INotifyPropertyChanged
    {
        private int _quality = 0;
        private string _component = "";

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

        public string Component
        {
            get
            {
                return _component;
            }
            set
            {
                _component = value;
                NotifyPropertyChanged("Component");
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
