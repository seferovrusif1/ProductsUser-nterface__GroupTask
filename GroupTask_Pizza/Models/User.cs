using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupTask_Pizza.Models
{
    internal class User
    {
        public string mail { get; set; }
        public string password { get; set; }
        public bool admin { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public User(string mail,string password,string name,string surname)
        {
            this.mail = mail;   
            this.password = password;
            admin = false;
            this.Name = name;
            this.Surname = surname;
        }

    }
}
