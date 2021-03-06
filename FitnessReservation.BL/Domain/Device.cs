using FitnessReservation.BL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessReservation.BL.Domain {
    internal class Device {
        public Device(int iD, string type, bool isAvailable) {
            SetID(iD);
            SetType(type);
            SetAvailability(isAvailable);
        }


        public int ID { get; private set; }
        public string Type { get; private set; }
        public bool IsAvailable { get; private set; }

        public void SetID(int id) {
            this.ID = id; 
        }
        public void SetType(string type) {
            if (string.IsNullOrWhiteSpace(type)) {
                throw new DeviceException("SetType");
            }
            this.Type = type;
        }

        private void SetAvailability(bool isAvailable) {
            this.IsAvailable = isAvailable;
        }

        public override string ToString() {
            string availability;
            if (this.IsAvailable) {
                availability = "available";
            } else {
                availability = "unavailable";
            }
            return $"{this.ID}-{this.Type}--{availability}";
        }
    }
}
