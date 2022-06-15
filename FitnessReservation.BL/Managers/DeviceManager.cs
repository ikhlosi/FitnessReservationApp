using FitnessReservation.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessReservation.BL.Managers {
    internal class DeviceManager {
         private IDeviceRepository repo;

        public DeviceManager(IDeviceRepository repo) {
            this.repo = repo;
        }

        public IReadOnlyList<string> SelectDevices() {
            return repo.SelectDevices();
        }
    }
}
