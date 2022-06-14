using FitnessReservation.BL.Domain;
using FitnessReservation.BL.Exceptions;
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

        public string GetClientFname(int? id, string email) {
            return repo.FindClient(id, email);
        }
        //public Client GetClientById(int id) {
        //    if (id <= 0) {
        //        throw new ClientManagerException("GetClientById");
        //    }
        //    return repo.FindClientById(id);
        //}

        //public Client GetClientByEmail(string email) {
        //    return repo.FindClientByEmail(email);
        //}
    }
}
