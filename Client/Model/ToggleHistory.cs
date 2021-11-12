using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Client.Model
{
    public class ToggleHistory : INotifyPropertyChanged
    {
        private bool switcher;
        private string content;

        public ToggleHistory()
        {
            switcher = false;
            content = "Отобразить только текущие заказы";
        }

        public string ContentBTN
        {
            get { return content; }
            set
            {
                content = value;
                NotifyPropertyChanged("ContentBTN");
            }
        }

        public bool getSwitcher()
        {
            return switcher;
        }

        public void switchBTN()
        {
            if (switcher)
            {
                ContentBTN = "Отобразить только текущие заказы";
                switcher = false;
            }
            else
            {
                ContentBTN = "Отобразить архив истории заказов";
                switcher = true;
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
