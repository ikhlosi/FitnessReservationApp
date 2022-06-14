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
    }
}
