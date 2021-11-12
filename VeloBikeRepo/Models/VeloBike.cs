using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeloBikeRepo.Models
{
    public class VeloBike : Bike
    {
        private string stateiD;
        private string stationID;

        public VeloBike() { }

        public string StateiD
        {
            get { return stateiD; }
            set { stateiD = value; }
        }
        public string StationID
        {
            get { return stationID; }
            set { stationID = value; }
        }
    }
}