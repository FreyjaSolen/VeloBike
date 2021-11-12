using System;
using System.Collections.Generic;

namespace Client.Model
{
    public class UserInfo
    {
        private int id;
        private string nickName;
        private string name;
        private string lstName;

        public UserInfo() { }

        public UserInfo(int _id, string _nickName)
        {
            id = _id;
            nickName = _nickName;
        }

        public void addName(string _name)
        {
            name = _name;
        }
        public void addlstName(string _lstName)
        {
            lstName = _lstName;
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public string NickName
        {
            get { return nickName; }
            set { nickName = value; }
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
    }
}
