using FitnessReservation.BL.Domain;
using FitnessReservation.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessReservation.BL.Managers {
    internal class ClientManager {
        private IClientRepository repo;

        public ClientManager(IClientRepository repo) {
            this.repo = repo;
        }

        public Client GetClientById(int id) {
            return repo.FindClientById(id);
        }
    }
}
