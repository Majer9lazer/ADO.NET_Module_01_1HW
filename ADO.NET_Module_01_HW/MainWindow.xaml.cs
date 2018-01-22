using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using ADO.NET_Module_01_HW.Model;
using Exception = System.Exception;

namespace ADO.NET_Module_01_HW
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    { 

        private  DB db= new DB();
         
        public MainWindow()
        {

                InitializeComponent();
            TablesManufacturerListView.ItemsSource = db.TablesManufacturers.ToList();
            TablesListView.ItemsSource = db.newEquipments.ToList();
            TablesStopReasonListView.ItemsSource = db.TablesStopReasons.ToList();
        }


        private void UIElement_OnGotFocus(object sender, RoutedEventArgs e)
        {
            ForwrapPanelDefinbition.Height = new GridLength(40);
            TablesManufacturerWrapPanel.Visibility = Visibility.Visible;
           
       
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
               
                TablesManufacturer t = (TablesManufacturer) TablesManufacturerListView.SelectedItem;
                db.Entry(t).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                ErrorOrSuccessTextBlock.Text = ex.Message;
            }
        }

        private void UIElement_OnGotFocus1(object sender, RoutedEventArgs e)
        {
            TablesListView.ItemsSource = db.newEquipments.ToList();
            ForwrapPanelDefinbition.Height = new GridLength(0);
            TablesManufacturerWrapPanel.Visibility = Visibility.Hidden;
        }

        private void UIElement_OnGotFocus2(object sender, RoutedEventArgs e)
        {
            TablesStopReasonListView.ItemsSource = db.TablesStopReasons.ToList();
            ForwrapPanelDefinbition.Height = new GridLength(0);
            TablesManufacturerWrapPanel.Visibility = Visibility.Hidden;
        }

        private void UIElement_OnGotFocus3(object sender, RoutedEventArgs e)
        {
            ForwrapPanelDefinbition.Height = new GridLength(0);
            TablesManufacturerWrapPanel.Visibility = Visibility.Hidden;
            var tracklist = db.TrackMeters.Select(s => new
            {
                s.intEquipmentID,
                s.dMeterDate,
                s.intMeterReading,
                s.intHoursHoursOperation
            });
            TrackMeterListView.ItemsSource = tracklist.ToList();
        }
    }
}
