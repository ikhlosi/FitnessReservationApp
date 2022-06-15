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

        public void MakeReservation(int clientID, DateTime? reservationDate, int? timeslotID, string deviceType) {
            try {
            if (reservationDate < DateTime.Today.AddDays(1) || reservationDate > DateTime.Today.AddDays(7)) {
                throw new ReservationManagerException("Only allowed to choose a date which is in the future (maximum 1 week)");
            }
                int reservationID = this.WriteReservationInDB(clientID, (DateTime)reservationDate);
                int deviceID = this.AssignDevice((DateTime)reservationDate, deviceType, (int)timeslotID);
                this.WriteReservationDetailsInDB(reservationID,deviceID,(int)timeslotID);
            }
            catch (ReservationManagerException) {
                throw;
            }
            catch (Exception ex) {
                throw new ReservationManagerException("MakeReservation", ex);
            }

        }

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

        public int AssignDevice(DateTime date, string type, int timeslotID) { // TODO: check for faults
            IReadOnlyList<int> deviceIDs = repo.GetAvailableDevices(date, type, timeslotID);
            Random r = new Random();
            int index = r.Next(deviceIDs.Count);
            return deviceIDs[index];
            
            //return repo.AssignDevice(date, type, timeslot);
        }
    }
}
