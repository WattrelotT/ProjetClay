﻿using System;
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

        public List<string> lot { get; set; }
        public List<string> component { get; set; }
        public List<string> layout { get; set; }
        public List<string> quality { get; set; }
        public List<string> performance { get; set; }
        public List<string> month { get; set; }

        public bool programmaticChange { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            
            List<Data> MalistDeData = new List<Data>();
            ParseurXml MonParseurXml = new ParseurXml();
            
            lot = new List<string>();
            quality = new List<string>();
            performance = new List<string>();
            layout = new List<string>();
            component = new List<string>();
            month = new List<string>();

            MalistDeData = MonParseurXml.LectureXML(@"C:\Users\eithi\Source\Repos\ProjetClay\Clay\Clay\Resources\09092016.xml");
            DataAcess MonDataAcess = new DataAcess();
            MonDataAcess.SetData(MalistDeData);
            dataGrid.DataContext = MonDataAcess.GetAllData();
            foreach (var item in MalistDeData)
            {
                lot.Add(item.lot);
                if (!isInList(quality, item.quality))
                {
                    quality.Add(item.quality);
                }

                if (!isInList(layout, item.layout.ToString()))
                {
                    layout.Add(item.layout.ToString());
                }
                if (!isInList(performance, item.performance))
                {
                    performance.Add(item.performance);
                }
                if (!isInList(component, item.component))
                {
                    component.Add(item.component);
                }
                if(!isInList(month, item.date.ToString("MMyyyy")))
                {
                    month.Add(item.date.ToString("MMyyyy"));
            }

            }

            LotDropDown.ItemsSource = lot;
            LotDropDown.Items.Refresh();
            QualityDropDown.ItemsSource = quality;
            QualityDropDown.Items.Refresh();
            PerformanceDropDown.ItemsSource = performance;
            PerformanceDropDown.Items.Refresh();
            ComponentDropDown.ItemsSource = component;
            ComponentDropDown.Items.Refresh();
            LayoutDropDown.ItemsSource = layout;
            LayoutDropDown.Items.Refresh();
            MonthDropDown.ItemsSource = month;
            MonthDropDown.Items.Refresh();

            Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.ApplicationIdle, new Action(ProcessRows));
        }

        private void Graphique_Click(object sender, RoutedEventArgs e)
        {
            Graphics FenetreGraph = new Graphics();
            FenetreGraph.Show();
        }

        private void Init()
        {
            lot = new List<string>();
            quality = new List<string>();
            performance = new List<string>();
            layout = new List<string>();
            component = new List<string>();

            DataAcess MonDataAcess = new DataAcess();
            dataGrid.DataContext = MonDataAcess.GetAllData();
            dataGrid.ItemsSource = MonDataAcess.GetAllData();
            List<Data> MalistDeData = new List<Data>();
            MalistDeData = MonDataAcess.GetAllData();

            foreach (var item in MalistDeData)
            {
                lot.Add(item.lot);
                if (!isInList(quality, item.quality))
                {
                    quality.Add(item.quality);
                }
                layout.Add(item.layout.ToString());
                if (!isInList(performance, item.performance))
                {
                    performance.Add(item.performance);
                }

                component.Add(item.component);
            }
            
            LotDropDown.ItemsSource = lot;
            LotDropDown.Items.Refresh();
            QualityDropDown.ItemsSource = quality;
            QualityDropDown.Items.Refresh();
            PerformanceDropDown.ItemsSource = performance;
            PerformanceDropDown.Items.Refresh();
            ComponentDropDown.ItemsSource = component;
            ComponentDropDown.Items.Refresh();
            LayoutDropDown.ItemsSource = layout;
            LayoutDropDown.Items.Refresh();

            Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.ApplicationIdle, new Action(ProcessRows));
        }

        private bool isInList(List<string> list, string value)
        {
            foreach ( string s in list)
            {
                if (s.ToLower() == value.ToLower())
        {
                    return true;
                }
            }
            return false;

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

            List<Data> MalistDeData = new List<Data>();
            ParseurXml MonParseurXml = new ParseurXml();


            DataAcess MonDataAcess = new DataAcess();
            MalistDeData = MonDataAcess.GetAllData();


            string _lot = LotDropDown.SelectedValue == null ? "" : LotDropDown.SelectedValue.ToString();
            string _layout = LayoutDropDown.SelectedValue == null ? "" : LayoutDropDown.SelectedValue.ToString();
            string _component = ComponentDropDown.SelectedValue == null ? "" : ComponentDropDown.SelectedValue.ToString();
            string _performance = PerformanceDropDown.SelectedValue == null ? "" : PerformanceDropDown.SelectedValue.ToString();
            string _quality = QualityDropDown.SelectedValue == null ? "" : QualityDropDown.SelectedValue.ToString();

            var items = from lotItem in MalistDeData
                    where (_quality == "" || lotItem.quality == _quality) &&
                          (_performance == "" || lotItem.performance == _performance) &&
                          (_layout == "" || lotItem.layout.ToString() == _layout) &&
                          (_component == "" || lotItem.component == _component) &&
                          (_lot == "" || lotItem.lot == _lot)
                    select lotItem;
            dataGrid.DataContext = items.ToList();
            dataGrid.ItemsSource = items.ToList();

            Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.ApplicationIdle, new Action(ProcessRows));
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            programmaticChange = true;
            InitializeComponent();
            Init();
            LotDropDown.SelectedIndex = -1;
            ComponentDropDown.SelectedIndex = -1;
            QualityDropDown.SelectedIndex = -1;
            PerformanceDropDown.SelectedIndex = -1;
            LayoutDropDown.SelectedIndex = -1;
            programmaticChange = false;
            //LotDropDown.Text = "";
            //ComponentDropDown.Text = "";
            //LayoutDropDown.Text = "";
            //QualityDropDown.Text = "";
            //PerformanceDropDown.Text = "";
        }

        private DataGridCell GetCell(int rowIndex, int colIndex, DataGrid dg)
        {
            DataGridRow row = dg.ItemContainerGenerator.ContainerFromIndex(rowIndex) as DataGridRow;
            DataGridCellsPresenter p = GetVisualChild<DataGridCellsPresenter>(row);
            DataGridCell cell = p.ItemContainerGenerator.ContainerFromIndex(colIndex) as DataGridCell;

            return cell;
        }

        public static T GetVisualChild<T>(Visual parent) where T : Visual
        {
            T child = default(T);
            int numVisuals = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < numVisuals; i++)
            {
                Visual v = (Visual)VisualTreeHelper.GetChild(parent, i);
                child = v as T;
                if (child == null)
                {
                    child = GetVisualChild<T>(v);
                }
                if (child != null)
                {
                    break;
                }
            }
            return child;
        }

        private void ComboBox_SelectionChanged_Month(object sender, SelectionChangedEventArgs e)
        {
            if (programmaticChange)
            {
                return;
            }
            // ... Get the ComboBox.
            var comboBox = sender as ComboBox;

            // ... Set SelectedItem as Window Title.
            var value = comboBox.SelectedItem;

            List<Data> MalistDeData = new List<Data>();

            List<string> lMonth = new List<string>();

            DataAcess MonDataAcess = new DataAcess();
            MalistDeData = MonDataAcess.GetAllData();

            string _Month = MonthDropDown.SelectedValue == null ? "" : MonthDropDown.SelectedValue.ToString();

            var m = from MonthItem in MalistDeData
                    select MonthItem.date.ToString("MMyyyy");
            lMonth = m.Distinct().ToList();

            month = lMonth;
            MonthDropDown.ItemsSource = month;
            MonthDropDown.Items.Refresh();

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (programmaticChange)
            {
                return;
            }
            // ... Get the ComboBox.
            var comboBox = sender as ComboBox;

            // ... Set SelectedItem as Window Title.
            var value = comboBox.SelectedItem;

            List<Data> MalistDeData = new List<Data>();
            
            List<string> lLot = new List<string>();
            List<string> lLayout = new List<string>();
            List<string> lComponent = new List<string>();
            List<string> lQuality = new List<string>();
            List<string> lPerformance = new List<string>();
            
            DataAcess MonDataAcess = new DataAcess();
            MalistDeData = MonDataAcess.GetAllData();

            string _lot = LotDropDown.SelectedValue == null ? "" : LotDropDown.SelectedValue.ToString();
            string _layout = LayoutDropDown.SelectedValue == null ? "" : LayoutDropDown.SelectedValue.ToString();
            string _component = ComponentDropDown.SelectedValue == null ? "" : ComponentDropDown.SelectedValue.ToString();
            string _performance = PerformanceDropDown.SelectedValue == null ? "" : PerformanceDropDown.SelectedValue.ToString();
            string _quality = QualityDropDown.SelectedValue == null ? "" : QualityDropDown.SelectedValue.ToString();

            var l = from lotItem in MalistDeData
                   where (_quality == "" || lotItem.quality == _quality) &&
                         (_performance == "" || lotItem.performance == _performance) &&
                         (_layout == "" || lotItem.layout.ToString() == _layout) &&
                         (_component == "" || lotItem.component == _component) 
                    select lotItem.lot;
            lLot = l.Distinct().ToList();
            var p = from lotItem in MalistDeData
                    where (_quality == "" || lotItem.quality == _quality) &&
                          (_lot == "" || lotItem.lot == _lot) &&
                          (_layout == "" || lotItem.layout.ToString() == _layout) &&
                          (_component == "" || lotItem.component == _component)
                    select lotItem.performance;
            lPerformance = p.Distinct().ToList();
            var q = from lotItem in MalistDeData
                    where (_lot == "" || lotItem.lot == _lot) &&
                          (_performance == "" || lotItem.performance == _performance) &&
                          (_layout == "" || lotItem.layout.ToString() == _layout) &&
                          (_component == "" || lotItem.component == _component)
                    select lotItem.quality;
            lQuality = q.Distinct().ToList();
            var c = from lotItem in MalistDeData
                    where (_quality == "" || lotItem.quality == _quality) &&
                          (_performance == "" || lotItem.performance == _performance) &&
                          (_layout == "" || lotItem.layout.ToString() == _layout) &&
                          (_lot == "" || lotItem.lot == _lot)
                    select lotItem.component;
            lComponent = c.Distinct().ToList();
            var la = from lotItem in MalistDeData
                    where (_quality == "" || lotItem.quality == _quality) &&
                          (_performance == "" || lotItem.performance == _performance) &&
                          (_lot == "" || lotItem.lot == _lot) &&
                          (_component == "" || lotItem.component == _component)
                    select lotItem.layout.ToString();
            lLayout = la.Distinct().ToList();


            
            //LotDropDown.Items.Clear();
            lot = lLot;
            LotDropDown.ItemsSource = lot;
            LotDropDown.Items.Refresh();

            //QualityDropDown.Items.Clear();
            quality = lQuality;
            QualityDropDown.ItemsSource = quality;
            QualityDropDown.Items.Refresh();
 
            //PerformanceDropDown.Items.Clear();
            performance = lPerformance;
            PerformanceDropDown.ItemsSource = performance;
            PerformanceDropDown.Items.Refresh();

            //LayoutDropDown.Items.Clear();
            layout = lLayout;
            LayoutDropDown.ItemsSource = layout;
            LayoutDropDown.Items.Refresh();

            //ComponentDropDown.Items.Clear();
            component = lComponent;
            ComponentDropDown.ItemsSource = component;
            ComponentDropDown.Items.Refresh();
        }

        private void ProcessRows()
        {
            foreach (Data item in dataGrid.ItemsSource)
            {
                //dataGrid.UpdateLayout();
                var row = dataGrid.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                DataGridCell cell = GetCell(row.GetIndex(), 3, dataGrid);
                string color = item.colorbound;
                if (item.quality == "Low")
                {
                    row.Background = Brushes.Pink;
                }
                switch (color)
                {

                    case "Green":
                        cell.Background = new SolidColorBrush(Colors.DarkGreen);
                        cell.Foreground = new SolidColorBrush(Colors.White);
                        break;
                    case "Black":
                        cell.Background = new SolidColorBrush(Colors.Black);
                        cell.Foreground = new SolidColorBrush(Colors.White);
                        break;
                    case "Yellow":
                        cell.Background = new SolidColorBrush(Colors.Yellow);
                        cell.Foreground = new SolidColorBrush(Colors.Black);
                        break;
                    case "Red":
                        cell.Background = new SolidColorBrush(Colors.Red);
                        cell.Foreground = new SolidColorBrush(Colors.White);
                        break;
                    case "Pink":
                        cell.Background = new SolidColorBrush(Colors.LightPink);
                        cell.Foreground = new SolidColorBrush(Colors.Black);
                        break;
                    case "Gray":
                        cell.Background = new SolidColorBrush(Colors.Gray);
                        cell.Foreground = new SolidColorBrush(Colors.DarkGreen);
                        break;
                    case "Blue":
                        cell.Background = new SolidColorBrush(Colors.Blue);
                        cell.Foreground = new SolidColorBrush(Colors.White);
                        break;
                    case "White":
                        cell.Background = new SolidColorBrush(Colors.White);
                        cell.Foreground = new SolidColorBrush(Colors.Black);
                        break;
                    case "Orange":
                        cell.Background = new SolidColorBrush(Colors.Orange);
                        cell.Foreground = new SolidColorBrush(Colors.Black);
                        break;
                    default:
                        cell.Background = new SolidColorBrush(Colors.Transparent);
                        cell.Foreground = new SolidColorBrush(Colors.Black);
                        break;

                }
            }
        }

        private void Extraire_Click(object sender, RoutedEventArgs e)
        {
            InitializeComponent();

            ParseurXml MonParseurXml = new ParseurXml();
            //List<Data> MalistDeData = new List<Data>();
            //MalistDeData = MonParseurXml.LectureXML(@"C:\Users\Thomas\Source\Repos\ProjetClay\Clay\Clay\Resources\lot.xml")

            // ... Set SelectedItem as Window Title.
            var value = MonthDropDown.SelectedItem;


            string pMoisAnnee = value.ToString();

            List<Data> ListeTrier = new List<Data>();
            DataAcess MonDataAcess = new DataAcess();
           

            foreach (var item in MonDataAcess.GetAllData())
            {
                if (item.date.ToString("MMyyyy") == pMoisAnnee)
                {
                    ListeTrier.Add(item);
                }
            }

            MonParseurXml.WriteXmlDependMonth(ListeTrier, pMoisAnnee);
        }
    }
}
