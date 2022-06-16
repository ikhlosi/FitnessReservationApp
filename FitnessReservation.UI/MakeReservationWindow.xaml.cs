using FitnessReservation.BL.Domain;
using FitnessReservation.BL.DTO;
using FitnessReservation.BL.Exceptions;
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
        //private string selectedDeviceType;
        //private int selectedTimeSlotID;
        private int clientID;
        private ReservationManager rm;
       
        public MakeReservationWindow(int clientID) {
            InitializeComponent();
            this.clientID = clientID;
            rm = new ReservationManager(new ReservationRepoADO(ConfigurationManager.ConnectionStrings["FitnessCentreDBConnection"].ToString()));
            dateReservation.DisplayDateStart = DateTime.Today.AddDays(1);
            dateReservation.DisplayDateEnd = DateTime.Today.AddDays(7);
        }

        private void btnAddTimeSlot_Click(object sender, RoutedEventArgs e) {
            AddTimeSlotWindow addTimeSlotWindow = new AddTimeSlotWindow((DateTime)dateReservation.SelectedDate);
            if (addTimeSlotWindow.ShowDialog() == true) {
                string selectedDeviceType = (string)addTimeSlotWindow.comboDevice.SelectedItem;
                int selectedTimeSlotID = (int)addTimeSlotWindow.comboTimeslot.SelectedIndex + 1;
                var timeslotsList = from i in listBoxAddedTimeSlots.Items.Cast<ReservationInfoDTO>().ToList() select i.ReservedSlotID;
                //var sequences = timeslotsList.Distinct()
                //     .GroupBy(num => Enumerable.Range(num, 100 - num + 1).TakeWhile(timeslotsList.Contains).Last())  
                //     .Where(seq => seq.Count() >= 2);
                listBoxAddedTimeSlots.Items.Add(new ReservationInfoDTO((DateTime)dateReservation.SelectedDate, selectedTimeSlotID, selectedDeviceType));
                if (listBoxAddedTimeSlots.Items.Count > 4) {
                    listBoxAddedTimeSlots.Items.RemoveAt(listBoxAddedTimeSlots.Items.Count-1);
                    MessageBox.Show("Cannot have more than 4 timeslots/day");
                }
            }
        }

        private void btnMakeReservation_Click(object sender, RoutedEventArgs e) {
            try {
                rm.MakeReservation(this.clientID, listBoxAddedTimeSlots.Items.Cast<ReservationInfoDTO>().ToList());
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            DialogResult = true;
            this.Close();
        }

        private void dateReservation_SelectedDateChanged(object sender, SelectionChangedEventArgs e) {
            listBoxAddedTimeSlots.Items.Clear();
        }
    }
}
