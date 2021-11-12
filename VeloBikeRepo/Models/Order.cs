using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeloBikeRepo.Models
{
    public class Order
    {
        private int user;
        private long date;
        private int beginSt;
        private int byke;

        public Order() { }
        public Order(int user, long date, int beginSt, int byke)
        {
            this.user = user;
            this.date = date;
            this.beginSt = beginSt;
            this.byke = byke;
        }

        public int User
        {
            get { return user; }
            set { user = value; }
        }
        public long Date
        {
            get { return date; }
            set { date = value; }
        }
        public int BeginSt
        {
            get { return beginSt; }
            set { beginSt = value; }
        }
        public int Byke
        {
            get { return byke; }
            set { byke = value; }
        }
    }
}
