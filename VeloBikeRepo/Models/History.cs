using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeloBikeRepo.Models
{
    public class History
    {
        private int id;
        private string user;
        private long date;
        private string beginSt;
        private string endSt;
        private string bike;
        private double cost;

        public History()
        {
            id = -1;
            user = "-1";
            endSt = "-1";
            cost = -1;
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public string User
        {
            get { return user; }
            set { user = value; }
        }
        public long Date
        {
            get { return date; }
            set { date = value; }
        }
        public string BeginSt
        {
            get { return beginSt; }
            set { beginSt = value; }
        }
        public string EndSt
        {
            get { return endSt; }
            set { endSt = value; }
        }
        public string Bike
        {
            get { return bike; }
            set { bike = value; }
        }
        public double Cost
        {
            get { return cost; }
            set { cost = value; }
        }
    }
}
