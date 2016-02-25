using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Clay
{
    public class PerformanceLayout : INotifyPropertyChanged
    {
        private int _performance = 0;
        private int _layout = 0;

        public int Performance
        {
            get
            {
                return _performance;
            }
            set
            {
                _performance = value;
                NotifyPropertyChanged("Performance");
            }
        }

        public int Layout
        {
            get
            {
                return _layout;
            }
            set
            {
                _layout = value;
                NotifyPropertyChanged("Layout");
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
