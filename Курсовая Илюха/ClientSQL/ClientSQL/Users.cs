using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientSQL
{
    class Users
    {
        string name;

        public Users(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
