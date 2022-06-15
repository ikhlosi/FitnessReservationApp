using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessReservation.DL.Exceptions {
    internal class TimeSlotRepoADOException : Exception {
        public TimeSlotRepoADOException(string? message) : base(message) {
        }

        public TimeSlotRepoADOException(string? message, Exception? innerException) : base(message, innerException) {
        }
    }
}
