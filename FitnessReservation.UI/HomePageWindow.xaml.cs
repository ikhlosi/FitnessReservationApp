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
using System.Windows.Shapes;

namespace FitnessReservation.UI {
    /// <summary>
    /// Interaction logic for HomePageWindow.xaml
    /// </summary>
    public partial class HomePageWindow : Window {
        //private string connectionString = @"Data Source=DESKTOP-QT687QR\SQLEXPRESS;Initial Catalog=FitnessCentre;Integrated Security=True";
        private ClientManager cm = new ClientManager(new ClientRepoADO(ConfigurationManager.ConnectionStrings["FitnessCentreDBConnection"].ToString()));
        private ReservationManager rm = new ReservationManager(new ReservationRepoADO(ConfigurationManager.ConnectionStrings["FitnessCentreDBConnection"].ToString()));
        public HomePageWindow(int? clientID, string clientEmail) {
            InitializeComponent();
            Client user = cm.GetClientDetails(clientID, clientEmail);
            string userFname = user.FirstName;
            labelWelcome.Content = $"Welcome, {userFname}";
            var reservations = rm.GetReservations(user.ID);
            listBoxReservations.ItemsSource = reservations;
        }
        //public HomePageWindow(string clientEmail) {
        //    InitializeComponent();
        //}
    }
}
