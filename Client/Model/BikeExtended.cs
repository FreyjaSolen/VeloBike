using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Client.Model
{
    public class BikeExtended : Byke, INotifyPropertyChanged
    {
        private string state;
        private string station;

        public BikeExtended() { }

        public BikeExtended(int BikeID)
        {
            ID = BikeID;
        }

        public string StateiD
        {
            get { return state; }
            set
            {
                state = value;
                NotifyPropertyChanged("StateiD");
            }
        }
        public string StationID
        {
            get { return station; }
            set
            {
                station = value;
                NotifyPropertyChanged("StationID");
            }
        }
    }
}
