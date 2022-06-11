using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessReservation.BL.Exceptions {
    internal class DeviceException : Exception {
        public DeviceException(string message) : base(message) { }
        public DeviceException(string message, Exception innerException) : base(message, innerException) { }
    }
}
