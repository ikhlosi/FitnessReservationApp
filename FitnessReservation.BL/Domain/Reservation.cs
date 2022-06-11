using FitnessReservation.BL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessReservation.BL.Domain {
    internal class Reservation {
        public int ID { get; private set; }
        public DateTime ReservationDate{ get; private set; }
        //public Device Device{ get; private set; }
        //public List<TimeSlot> ChosenTimeslots { get; private set; }
        public Client Client;
        private Dictionary<int, int> Sessions = new Dictionary<int, int>(); // key: TimeSlot.ID; value Device.ID

        public Reservation(int id, DateTime date, Client c) {
            SetID(id);
            SetReservationDate(date);
            SetClient(c);
        }

        public void SetID(int id) {
            this.ID = id;
        }
        
        public void SetReservationDate(DateTime date) {
            this.ReservationDate = date;
        }

        public void SetClient(Client c) {
            if (c == null) {
                throw new ReservationException("SetClient");
            }
            this.Client = c;
        }

        public void AddSession(int timeslotId, int deviceId) {
            if (Sessions.ContainsKey(timeslotId)) {
                throw new ReservationException("AddSession");
            }
            Sessions.Add(timeslotId, deviceId);
        }

    }
}
