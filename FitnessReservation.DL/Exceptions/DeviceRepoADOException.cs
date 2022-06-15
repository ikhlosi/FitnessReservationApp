using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessReservation.DL.Exceptions {
    internal class DeviceRepoADOException : Exception {
        public DeviceRepoADOException(string? message) : base(message) {
        }

        public DeviceRepoADOException(string? message, Exception? innerException) : base(message, innerException) {
        }
    }
}
