using FitnessReservation.BL.Domain;
using FitnessReservation.BL.DTO;
using FitnessReservation.BL.Exceptions;
using FitnessReservation.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessReservation.BL.Managers {
    internal class ReservationManager {
        private IReservationRepository repo;

        public ReservationManager(IReservationRepository repo) {
            this.repo = repo;
        }

        public IReadOnlyList<ReservationInfoDTO> GetReservations(int id) {
            if (id <= 0) {
                throw new ReservationManagerException("GetReservations - invalid ID");
            }
            return repo.GetReservations(id);
        }

        //public void MakeReservation(int clientID, DateTime? reservationDate, int timeslotID, string deviceType) {
        //    try {
        //        int reservationID = this.WriteReservationInDB(clientID, reservationDate);
        //        this.WriteReservationDetailsInDB;
        //    }
        //    catch (Exception ex) {
        //        throw new ReservationManagerException("MakeReservation", ex);
        //    }

        //}

        public int WriteReservationInDB(int clientID, DateTime reservationDate) {
             if (clientID <= 0) {
                throw new ReservationManagerException("WriteReservationInDB - invalid input");
            }
            return repo.WriteReservationInDB(clientID, reservationDate);
        }

        public void WriteReservationDetailsInDB(int reservationID, int deviceID, int timeslotID) {
            if (reservationID <= 0 || deviceID <= 0 || timeslotID <= 0) {
                throw new ReservationManagerException("GetReservationId - invalid input");
            }
            repo.WriteReservationDetailsInDB(reservationID, deviceID, timeslotID);
        }
        public int? GetReservationId(int reservationID, DateTime reservationDate) { //returns null if none found
            if (reservationID <= 0) {
                throw new ReservationManagerException("GetReservationId - invalid input");
            }
            return repo.GetReservationId(reservationID, reservationDate);
        }
    }
}
