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
using ClayData;

namespace Clay
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Data> MalistDeData;
        public MainWindow()
        {
            InitializeComponent();

            
             MalistDeData = new List<Data>();
            ParseurXml MonParseurXml = new ParseurXml();
            MalistDeData = MonParseurXml.LectureXML(@"C:\Users\eithi\Source\Repos\ProjetClay\Clay\Clay\Resources\lot.xml");
            

            DataAcess MonDataAcess = new DataAcess();
            MonDataAcess.SetData(MalistDeData);

            dataGrid.DataContext = MonDataAcess.GetAllData();
            Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.ApplicationIdle, new Action(ProcessRows));
        }

        private void Graphique_Click(object sender, RoutedEventArgs e)
        {
            Graphique MaFenetreGraphique = new Graphique(MalistDeData);
            MaFenetreGraphique.Show();
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
            
            
           // dataGrid.DataContext = MalistDeData;
        }

        private void ProcessRows()
        {

            foreach (Data item in dataGrid.ItemsSource)
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
