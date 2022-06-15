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

namespace FitnessAdmin.UI {
    /// <summary>
    /// Interaction logic for AddDeviceWindow.xaml
    /// </summary>
    public partial class AddDeviceWindow : Window {
        private DeviceManager dm;
        public AddDeviceWindow() {
            InitializeComponent();
            dm = new DeviceManager(new DeviceRepoADO(ConfigurationManager.ConnectionStrings["FitnessCentreDBConnection"].ToString()));
        }

        private void btnAddDevice_Click(object sender, RoutedEventArgs e) {
            
        }
    }
}
