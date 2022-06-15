using FitnessReservation.BL.Domain;
using FitnessReservation.BL.Managers;
using FitnessReservation.DL;
using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace FitnessAdmin.UI {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private DeviceManager dm;
        public MainWindow() {
            InitializeComponent();
            dm = new DeviceManager(new DeviceRepoADO(ConfigurationManager.ConnectionStrings["FitnessCentreDBConnection"].ToString()));
            listBoxDevices.ItemsSource = dm.GetAllDevices();
            comboFilterDevice.ItemsSource = dm.SelectDevices();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e) {
            Device selectedItem = (Device)listBoxDevices.SelectedItem;
            //int deviceID = int.Parse(selectedItem.Split('-')[0]);
            //dm.RemoveDevice(deviceID);
            dm.RemoveDevice(selectedItem.ID);
        }

        private void btnMarkAvailable_Click(object sender, RoutedEventArgs e) {
            Device selectedItem = (Device)listBoxDevices.SelectedItem;
            dm.MarkDeviceAvailable(selectedItem.ID);
        }

        private void btnMarkUnAvailable_Click(object sender, RoutedEventArgs e) {
            Device selectedItem = (Device)listBoxDevices.SelectedItem;
            dm.MarkDeviceUnAvailable(selectedItem.ID);
        }

        private void btnAddDevice_Click(object sender, RoutedEventArgs e) {
            AddDeviceWindow addDeviceWindow = new AddDeviceWindow();
            addDeviceWindow.ShowDialog();
        }

        private void comboFilterDevice_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            listBoxDevices.ItemsSource = dm.GetDevicesOfType((string)comboFilterDevice.SelectedItem);
        }

        private void txtFilterID_TextChanged(object sender, TextChangedEventArgs e) {
        }

        private void listBoxDevices_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            btnDelete.IsEnabled = true;
            btnMarkAvailable.IsEnabled = true;
            btnMarkUnAvailable.IsEnabled = true;
        }
    }
}
