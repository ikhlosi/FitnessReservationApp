using FitnessReservation.BL.Managers;
using FitnessReservation.DL;
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

namespace FitnessReservation.UI {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private ClientManager clientManager;
        public MainWindow() {
            InitializeComponent();
            clientManager = new ClientManager(new ClientRepoADO("...."));
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e) {
            try {
                //int clientID;
                //string clientEmail;
                if (!string.IsNullOrWhiteSpace(txtClientID.Text)) {
                    int clientID = int.Parse(txtClientID.Text);
                    clientManager.GetClientById(clientID);
                    HomePageWindow homePageWindow = new HomePageWindow();
                    homePageWindow.ShowDialog();
                } else if (!string.IsNullOrWhiteSpace(txtEmail.Text)) {
                    string clientEmail = txtEmail.Text;
                    HomePageWindow homePageWindow = new HomePageWindow();
                    homePageWindow.ShowDialog();
                } else {
                    MessageBox.Show("Please provide either a Client ID or an E-mail");
                }
                //if (string.IsNullOrWhiteSpace(txtClientID.Text)) {
                //    if (string.IsNullOrWhiteSpace(txtEmail.Text)) {
                //        ;
                //    } else {
                //                           }
                //} else {
                //    HomePageWindow homePageWindow = new HomePageWindow();
                //    homePageWindow.ShowDialog();
                //}
            } catch (Exception ex){
                MessageBox.Show(ex.Message, "Login");
            }
        }
    }
}
