﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessReservation.BL.Interfaces {
    internal interface IDeviceRepository {
        public IReadOnlyList<string> SelectDevices();
    }
}
