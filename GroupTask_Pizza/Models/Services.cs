using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupTask_Pizza.Models
{
    internal static class Services
    {
        public static string SignIn(string name,string password)
        {
            var a=Database.Users.FirstOrDefault(x => x.mail == name);
            if (a == null)
            {
                Console.WriteLine("user not found");
                return null;
            }
            else
            {
                if (a.password==password)
                {
                    return "admin";
                }
                else
                {
                    Console.WriteLine("pasword is wrong!");
                    return null;
                }
            }
        }
        public static void SignUp(string ad,string soyad,string mail ,string password)
        {
            var a=Database.Users.FirstOrDefault(y => y.mail == mail);
            if (a == null)
            {
                User user = new User(mail, password, ad, soyad);
                Database.Users.Add(user);

            }
            else
            {
                Console.WriteLine("User movcuddur!");
            }
        }
    }
}
