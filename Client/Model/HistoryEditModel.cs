using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Client.Model
{
    public class HistoryEditModel : INotifyPropertyChanged
    {
        private int id;
        private string user;
        private DateTime date;
        private string endSt;
        private DateTime dateEnd;
        private double cost;

        public HistoryEditModel() { }

        public int OrderID
        {
            get { return id; }
            set
            {
                id = value;
                NotifyPropertyChanged("OrderID");
            }
        }
        public string User
        {
            get { return user; }
            set
            {
                user = value;
                NotifyPropertyChanged("User");
            }
        }
        public DateTime Date
        {
            get { return date; }
            set
            {
                date = value;
                NotifyPropertyChanged("Date");
            }
        }
        public string EndSt
        {
            get { return endSt; }
            set
            {
                endSt = value;
                NotifyPropertyChanged("EndSt");
            }
        }
        public DateTime DateEnd
        {
            get { return dateEnd; }
            set
            {
                dateEnd = value;
                NotifyPropertyChanged("DateEnd");
            }
        }
        public double Cost
        {
            get { return cost; }
            set
            {
                cost = value;
                NotifyPropertyChanged("Cost");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
