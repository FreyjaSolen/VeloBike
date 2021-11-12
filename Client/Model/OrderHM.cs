using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Client.Model
{
    public class OrderHM : INotifyPropertyChanged
    {
        private int id;
        private string text;

        public OrderHM()
        {
            id = -1;
            text = "None";
        }

        public OrderHM(int _id, string order)
        {
            id = _id;
            text = order;
        }

        public int ID
        {
            get { return id; }
            set
            {
                id = value;
                NotifyPropertyChanged("ID");
            }
        }
        public string OrderText
        {
            get { return text; }
            set
            {
                text = value;
                NotifyPropertyChanged("OrderText");
            }
        }

        public override string ToString()
        {
            return OrderText;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
