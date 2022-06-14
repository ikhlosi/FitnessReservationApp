using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessReservation.BL.DTO {
    internal class ReservationInfoDTO {
        public ReservationInfoDTO(DateTime reservationDate, string reservedSlot, string reservedDevice) {
            ReservationDate = reservationDate;
            ReservedSlot = reservedSlot;
            ReservedDevice = reservedDevice;
        }

        public DateTime ReservationDate { get; private set; }
        public string ReservedSlot { get; private set; }
        public string ReservedDevice { get; private set; }

        public override string ToString() {
            return $"{this.ReservationDate.Day}/{this.ReservationDate.Month}/{this.ReservationDate.Year} | {this.ReservedSlot} | {this.ReservedDevice}";
        }
    }
}
