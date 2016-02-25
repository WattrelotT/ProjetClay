using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Clay
{
    /// <summary>
    /// Logique d'interaction pour Graphics.xaml
    /// </summary>
    public partial class Graphics : Window
    {
        public Graphics()
        {
            InitializeComponent();
            DataContext = this;
            Init();
        }
        private void Init()
        {
            _data.Add(new Point(new DateTime(2010, 1, 1), 20));
            _data.Add(new Point(new DateTime(2010, 2, 1), 32));
            _data.Add(new Point(new DateTime(2010, 3, 1), 55));
            _data.Add(new Point(new DateTime(2010, 4, 1), 84));
            _data.Add(new Point(new DateTime(2010, 5, 1), 68));
        }
        ObservableCollection<Point> _data = new ObservableCollection<Point>();
        public ObservableCollection<Point> Data
        {
            get { return _data; }
        }
        public class Point : DependencyObject
        {
            public static readonly DependencyProperty _date = DependencyProperty.Register("Date", typeof(DateTime), typeof(Point));
            public Point(DateTime date, double value)
            {
                Date = date;
                Value = value;
            }
            public DateTime Date
            {
                get { return (DateTime)GetValue(_date); }
                set { SetValue(_date, value); }
            }
            public static readonly DependencyProperty _value = DependencyProperty.Register("Value", typeof(double), typeof(Point));
            public double Value
            {
                get { return (double)GetValue(_value); }
                set { SetValue(_value, value); }
            }
        }
    }
}
