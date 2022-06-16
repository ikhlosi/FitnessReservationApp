using FitnessReservation.BL.Domain;
using FitnessReservation.BL.DTO;
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
    /// Interaction logic for HomePageWindow.xaml
    /// </summary>
    public partial class HomePageWindow : Window {
        //private string connectionString = @"Data Source=DESKTOP-QT687QR\SQLEXPRESS;Initial Catalog=FitnessCentre;Integrated Security=True";
        private ClientManager cm;
        private ReservationManager rm;
        private int clientID;
        public HomePageWindow(int? clientID, string clientEmail) {
            InitializeComponent();
            cm = new ClientManager(new ClientRepoADO(ConfigurationManager.ConnectionStrings["FitnessCentreDBConnection"].ToString()));
            rm = new ReservationManager(new ReservationRepoADO(ConfigurationManager.ConnectionStrings["FitnessCentreDBConnection"].ToString()));
            Client user = cm.GetClientDetails(clientID, clientEmail);
            string userFname = user.FirstName;
            labelWelcome.Content = $"Welcome, {userFname}";
            this.clientID = user.ID;
            IReadOnlyList<ReservationInfoDTO> reservations = rm.GetReservations(this.clientID);
            listBoxReservations.ItemsSource = reservations;

        }

        private void btnReservation_Click(object sender, RoutedEventArgs e) {
            MakeReservationWindow makeReservationWindow = new MakeReservationWindow(this.clientID);
            makeReservationWindow.ShowDialog();
            listBoxReservations.ItemsSource = rm.GetReservations(this.clientID);
        }
        //public HomePageWindow(string clientEmail) {
        //    InitializeComponent();
        //}
    }
}
