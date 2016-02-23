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

        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            List<Data.Datas> MalistDeData = new List<Data.Datas>();
            ParseurXml MonParseurXml = new ParseurXml();
            MalistDeData = MonParseurXml.LectureXML("C:/Users/eithi/Desktop/TEST.xml");
            Console.WriteLine();

            dataGrid.DataContext = MalistDeData;
            foreach(Data.Datas item in dataGrid.ItemsSource)
            {
                var row = dataGrid.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                if(item.quality == "low")
                {
                    row.Background = Brushes.Pink;
                }
            }
           // dataGrid.DataContext = MalistDeData;
        }
    }
}
