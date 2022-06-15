using FitnessReservation.BL.Domain;
using FitnessReservation.BL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessReservation.BL.Interfaces {
    internal interface IReservationRepository {
        IReadOnlyList<ReservationInfoDTO> GetReservations(int id);
        int? GetReservationId(int clientID, DateTime reservationDate);
        int WriteReservationInDB(int clientID, DateTime reservationDate);
        void WriteReservationDetailsInDB(int reservationID, int deviceID, int timeslotID);
    }
}
