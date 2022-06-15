using FitnessReservation.BL.Domain;
using FitnessReservation.BL.Interfaces;
using System;
using System.Collections;
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

        public IReadOnlyList<Device> GetAllDevices() { // TODO: check for faults
            return repo.GetAllDevices();
        }

        public IReadOnlyList<Device> GetDevicesOfType(string selectedItem) {
            return repo.GetDevicesOfType(selectedItem);
        }

        internal void RemoveDevice(int deviceID) { // TODO: check for faults
            repo.RemoveDevice(deviceID);
        }

        internal void MarkDeviceAvailable(int iD) {
            repo.MarkDeviceAvailable(iD);
        }

        internal void AddDevice(string type) { // TODO: check for faults
            repo.AddDevice(type);
        }

        internal void MarkDeviceUnAvailable(int iD) {
            repo.MarkDeviceUnAvailable(iD);
        }
    }
}
