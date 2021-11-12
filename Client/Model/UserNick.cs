using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Client.Model
{
    public class UserNick : INotifyPropertyChanged
    {
        private string nick;

        public UserNick()
        {
            nick = "None";
        }

        public UserNick(string name)
        {
            this.nick = name;
        }

        public string Nick
        {
            get { return nick; }
            set
            {
                nick = value;
                NotifyPropertyChanged("Nick");
            }
        }

        public override string ToString()
        {
            return Nick;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
