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
using System.Windows.Shapes;

namespace FitnessReservation.UI {
    /// <summary>
    /// Interaction logic for AddTimeSlotWindow.xaml
    /// </summary>
    public partial class AddTimeSlotWindow : Window {
        //private ReservationManager rm;
        private TimeSlotManager tm;
        private DeviceManager dm;
        //private int clientID;
        //private DateTime reservationDate;
        public AddTimeSlotWindow(DateTime date) {
            InitializeComponent();
            //rm = new ReservationManager(new ReservationRepoADO(ConfigurationManager.ConnectionStrings["FitnessCentreDBConnection"].ToString()));
            tm = new TimeSlotManager(new TimeSlotRepoADO(ConfigurationManager.ConnectionStrings["FitnessCentreDBConnection"].ToString()));
            dm = new DeviceManager(new DeviceRepoADO(ConfigurationManager.ConnectionStrings["FitnessCentreDBConnection"].ToString()));
            //this.clientID = clientID;
            //this.reservationDate = date;
            comboTimeslot.ItemsSource = tm.SelectTimeSlots();
            comboDevice.ItemsSource = dm.SelectDevices();
            //comboDevice.ItemsSource = new List<string> { "ltreadmill", "bike"};
        }
        private void btnReserve_Click(object sender, RoutedEventArgs e) {
            DialogResult = true;
            this.Close();
        }


        private void comboTimeslot_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            btnReserve.IsEnabled = true;
        }

        private void comboDevice_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            comboTimeslot.IsEnabled = true;
        }
    }
}
