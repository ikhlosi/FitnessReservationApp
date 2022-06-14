using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessReservation.DL.Exceptions {
    internal class ReservationRepoADOException : Exception {
        public ReservationRepoADOException(string? message) : base(message) {
        }

        public ReservationRepoADOException(string? message, Exception? innerException) : base(message, innerException) {
        }
    }
}
