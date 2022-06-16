using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessReservation.BL.Exceptions {
    internal class MakeReservationWindowException : Exception {
        public MakeReservationWindowException(string? message) : base(message) {
        }

        public MakeReservationWindowException(string? message, Exception? innerException) : base(message, innerException) {
        }
    }
}
