﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkeringHus.Models
{
    internal class ParkingHouses
    {
        public int Id { get; set; }
        public string HouseName { get; set; }
        public int CityId { get; set; }
    }
}
