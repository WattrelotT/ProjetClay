using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Clay
{
    /// <summary>
    /// Logique d'interaction pour GraphNombreLotColor.xaml
    /// </summary>
    public partial class GraphNombreLotColor : Page
    {
        public GraphNombreLotColor(List<ClayData.Data> MalistDeData)
        {
            InitializeComponent();
            this.DataContext = new MainViewModel(MalistDeData);
        }
    }
}
