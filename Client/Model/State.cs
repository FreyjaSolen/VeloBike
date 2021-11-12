using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Client.Model
{
    public class State : INotifyPropertyChanged
    {
        private string stateName;

        public State()
        {
            stateName = "None";
        }

        public State(string name)
        {
            stateName = name;
        }

        public string StateName
        {
            get { return stateName; }
            set
            {
                stateName = value;
                NotifyPropertyChanged("StateName");
            }
        }

        public override string ToString()
        {
            return StateName;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
