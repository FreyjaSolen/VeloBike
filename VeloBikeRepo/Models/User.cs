using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeloBikeRepo.Models
{
    public class User
    {
        private int id;
        private string userName;
        private string name;
        private string lstName;
        private string password;

        public User() { }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string LastName
        {
            get { return lstName; }
            set { lstName = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
    }
}
