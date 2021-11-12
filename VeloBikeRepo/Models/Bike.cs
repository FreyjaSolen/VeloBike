using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeloBikeRepo.Models
{
    public class Bike
    {
        private int id;
        private string model;

        public Bike() { }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
    }
}
