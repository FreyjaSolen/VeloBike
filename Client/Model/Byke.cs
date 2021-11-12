using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Client.Model
{
    public class Byke : INotifyPropertyChanged
    {
        private int id;
        private string model;

        public Byke()
        {
            id = -1;
            model = "None";
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public string Model
        {
            get { return model; }
            set
            {
                model = value;
                NotifyPropertyChanged("Model");
            }
        }

        public override string ToString()
        {
            return Model;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}