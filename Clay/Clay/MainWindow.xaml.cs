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
using Clay.Properties;
using System.Windows.Controls.Primitives;

namespace Clay
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Graphique_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void columnHeader_Click(object sender, RoutedEventArgs e)
        {
            var columnHeader = sender as DataGridColumnHeader;
            if (columnHeader != null)
            {
                Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.ApplicationIdle, new Action(ProcessRows));
            }
        }
        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            InitializeComponent();
            List<Data.Datas> MalistDeData = new List<Data.Datas>();
            ParseurXml MonParseurXml = new ParseurXml();
            MalistDeData = MonParseurXml.LectureXML(@"C:\Users\eithi\Source\Repos\ProjetClay\Clay\Clay\Resources\lot.xml");
            dataGrid.DataContext = MalistDeData;
            Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.ApplicationIdle, new Action(ProcessRows));
            
           // dataGrid.DataContext = MalistDeData;
        }

        private void ProcessRows()
        {

            foreach (Data.Datas item in dataGrid.ItemsSource)
            {
                var row = dataGrid.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                if (item.quality == "Low")
                {
                    row.Background = Brushes.Pink;
                }
            }
        }
    }
}
