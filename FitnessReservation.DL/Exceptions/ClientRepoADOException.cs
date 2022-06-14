using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessReservation.DL.Exceptions {
    internal class ClientRepoADOException : Exception {
        public ClientRepoADOException(string message) : base(message) { }
        public ClientRepoADOException(string message, Exception innerException) : base(message, innerException) { }
    }
}
