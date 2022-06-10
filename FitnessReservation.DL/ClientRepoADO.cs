using FitnessReservation.BL.Interfaces;
using FitnessReservation.BL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessReservation.DL {
    internal class ClientRepoADO : IClientRepository {
        private string connectionString;

        public ClientRepoADO(string connectionString) {
            this.connectionString = connectionString;
        }

        public Client FindClientByEmail(string email) {
            throw new NotImplementedException();
        }

        public Client FindClientById(int id) {
            throw new NotImplementedException();
        }
    }
}
