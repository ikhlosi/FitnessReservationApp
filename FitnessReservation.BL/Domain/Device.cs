using FitnessReservation.BL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessReservation.BL.Domain {
    internal class Device {
        public Device(int iD, string type) {
            SetID(iD);
            SetType(type);
            IsAvailable = true;
        }

        public int ID { get; private set; }
        public string Type { get; private set; }
        public bool IsAvailable { get; set; }

        public void SetID(int id) {
            this.ID = id; 
        }
        public void SetType(string type) {
            if (string.IsNullOrWhiteSpace(type)) {
                throw new DeviceException("SetType");
            }
        }
    }
}
