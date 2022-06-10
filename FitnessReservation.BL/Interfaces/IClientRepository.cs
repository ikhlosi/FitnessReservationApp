using FitnessReservation.BL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessReservation.BL.Interfaces {
    internal interface IClientRepository {
        public Client FindClientByEmail(string email);
        public Client FindClientById(int id);
    }
}
