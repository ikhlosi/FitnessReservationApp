using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessReservation.BL.Domain {
    internal class TimeSlot {
        public TimeSlot(int id) {
            SetID(id);
        }

        public int ID { get; private set; }
        public void SetID(int ID) { 
            this.ID = ID;
        }
    }
}
