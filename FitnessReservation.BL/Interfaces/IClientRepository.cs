using FitnessReservation.BL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessReservation.BL.Interfaces {
    internal interface IClientRepository {
        public string FindClient(int? id, string email);
        //public Client FindClientById(int id);
        //public bool ClientExists(int? id, string email);
        public Client GetClientDetails(int? id, string email);
    }
}
