using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeloBikeRepo.Models
{
    public class OrderText
    {
        private int id;
        private string text;

        public OrderText()
        {
            id = -1;
            text = "None";
        }

        public OrderText(int ID, string name)
        {
            id = ID;
            this.text = name;
        }
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
