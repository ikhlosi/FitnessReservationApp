using FitnessReservation.BL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessReservation.BL.Domain {
    internal class Client {
        public Client(int iD, string email, string firstName, string lastName) {
            SetID(iD);
            SetEmail(email);
            SetFirstName(firstName);
            SetLastName(lastName);
        }

        public int ID { get; private set; }
        public string Email { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public void SetID(int id) {
            if (id <= 0) {
                throw new ClientException("SetId");
            }        
            this.ID = id;
        }

        public void SetEmail(string email) {
            if (string.IsNullOrWhiteSpace(email)) {
                throw new ClientException("SetEmail");
            }
            this.Email = email;
        }

        public void SetFirstName(string name) {
            if (string.IsNullOrWhiteSpace(name)) {
                throw new ClientException("SetFirstName");
            }
            this.FirstName = name;
        }
        public void SetLastName(string name) {
            if (string.IsNullOrWhiteSpace(name)) {
                throw new ClientException("SetFirstName");
            }
            this.LastName = name;
        }

    }
}
