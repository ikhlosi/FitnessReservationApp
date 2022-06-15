using FitnessReservation.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessReservation.BL.Managers {
    internal class TimeSlotManager {
        private ITimeSlotRepository repo;

        public TimeSlotManager(ITimeSlotRepository repo) {
            this.repo = repo;
        }

        public IReadOnlyList<string> SelectTimeSlots() {
            return repo.SelectTimeSlots();
        }
    }
}
