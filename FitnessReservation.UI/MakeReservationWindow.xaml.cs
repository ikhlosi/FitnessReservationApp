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
    /// Interaction logic for MakeReservationWindow.xaml
    /// </summary>
    public partial class MakeReservationWindow : Window {
        private ReservationManager rm;
        private TimeSlotManager tm;
        private DeviceManager dm;
        private int clientID;
        public MakeReservationWindow(int clientID) {
            InitializeComponent();
            rm = new ReservationManager(new ReservationRepoADO(ConfigurationManager.ConnectionStrings["FitnessCentreDBConnection"].ToString()));
            tm = new TimeSlotManager(new TimeSlotRepoADO(ConfigurationManager.ConnectionStrings["FitnessCentreDBConnection"].ToString()));
            dm = new DeviceManager(new DeviceRepoADO(ConfigurationManager.ConnectionStrings["FitnessCentreDBConnection"].ToString()));
            this.clientID = clientID;
            dateReservation.DisplayDateStart = DateTime.Today.AddDays(1);
            dateReservation.DisplayDateEnd = DateTime.Today.AddDays(7);
            comboTimeslot.ItemsSource = tm.SelectTimeSlots();
            comboDevice.ItemsSource = dm.SelectDevices();
            //comboDevice.ItemsSource = new List<string> { "ltreadmill", "bike"};
        }

        private void btnReserve_Click(object sender, RoutedEventArgs e) {
            DateTime? selectedDate = null;
            string selectedDeviceType = null;
            int? selectedTimeslotId = null;
            try {
                int clientId = this.clientID;
                selectedDate = dateReservation.SelectedDate;
                selectedTimeslotId = ++comboTimeslot.SelectedIndex;
                selectedDeviceType = (string)comboDevice.SelectedItem;
                rm.MakeReservation(clientID, selectedDate, selectedTimeslotId,selectedDeviceType);
                //int reservationID = rm.WriteReservationInDB(clientId, selectedDate);

                //comboTimeslot.SelectedIndex
                //comboTimeslot.SelectedIndex = 0;
            }
            catch (Exception ex) { 
                MessageBox.Show(ex.Message);
            }
            //if (dateReservation.SelectedDate < DateTime.Today.AddDays(1) || dateReservation.SelectedDate > DateTime.Today.AddDays(7)) {
            //    MessageBox.Show("Only allowed to choose a date which is in the future (maximum 1 week)");
            //}
        }

        private void dateReservation_SelectedDateChanged(object sender, SelectionChangedEventArgs e) {
            comboDevice.IsEnabled = true;
        }

        private void comboTimeslot_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            btnReserve.IsEnabled = true;
        }

        private void comboDevice_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            comboTimeslot.IsEnabled = true;
        }
    }
}
