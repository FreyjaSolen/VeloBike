using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Client.Model
{
    public class ClientHM : INotifyPropertyChanged
    {
        private string order;

        public ClientHM()
        {
            order = "None";
        }

        public ClientHM(string name)
        {
            this.order = name;
        }

        public string Order
        {
            get { return order; }
            set
            {
                order = value;
                NotifyPropertyChanged("Order");
            }
        }

        public override string ToString()
        {
            return Order;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
