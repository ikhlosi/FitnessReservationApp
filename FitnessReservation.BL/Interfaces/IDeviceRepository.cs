using FitnessReservation.BL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessReservation.BL.Interfaces {
    internal interface IDeviceRepository {
        IReadOnlyList<string> SelectDevices();
        IReadOnlyList<Device> GetAllDevices();
        IReadOnlyList<Device> GetDevicesOfType(string selectedItem);
        void RemoveDevice(int deviceID);
        void MarkDeviceAvailable(int iD);
        void MarkDeviceUnAvailable(int iD);
        void AddDevice(string type);
    }
}
