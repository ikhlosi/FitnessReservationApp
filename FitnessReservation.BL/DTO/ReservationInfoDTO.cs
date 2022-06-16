using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessReservation.BL.DTO {
    internal class ReservationInfoDTO {
        private string[] slots = { "08:00 - 09:00",
                                   "09:00 - 10:00",
                                   "10:00 - 11:00",
                                   "11:00 - 12:00",
                                   "12:00 - 13:00",
                                   "13:00 - 14:00",
                                   "14:00 - 15:00",
                                   "15:00 - 16:00",
                                   "16:00 - 17:00",
                                   "17:00 - 18:00",
                                   "18:00 - 19:00",
                                   "19:00 - 20:00",
                                   "20:00 - 21:00",
                                   "21:00 - 22:00"};
        public ReservationInfoDTO(DateTime reservationDate, string reservedSlot, string reservedDevice) {
            ReservationDate = reservationDate;
            ReservedSlot = reservedSlot;
            ReservedDevice = reservedDevice;
        }
        public ReservationInfoDTO(DateTime reservationDate, int reservedSlotID, string reservedDevice) {
            ReservationDate = reservationDate;
            ReservedSlotID = reservedSlotID;
            ReservedDevice = reservedDevice;
            this.ReservedSlot = this.slots[reservedSlotID - 1];
        }

        public DateTime ReservationDate { get; private set; }
        public string ReservedSlot { get; private set; }
        public int ReservedSlotID { get; private set; }
        public string ReservedDevice { get; private set; }

        public override string ToString() {
            return $"{this.ReservationDate.Day}/{this.ReservationDate.Month}/{this.ReservationDate.Year} | {this.ReservedSlot} | {this.ReservedDevice}";
        }
    }
}
