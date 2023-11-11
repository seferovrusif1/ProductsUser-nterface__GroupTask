

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupTask_Pizza.Models;

namespace GroupTask_Pizza.Utilies.Services
{
    internal static class UserService
    {

        public static Role SignIn(string name, string password)
        {
            var a = Database.Users.FirstOrDefault(x => x.mail == name);
            if (a == null)
            {
                Console.WriteLine("user not found");
                return default;
            }
            else
            {
                if (a.password == password)
                {
                    Console.WriteLine($"Xosh geldiniz, {a.Name} {a.Surname}");
                    return a.role;
                }
                else
                {
                    Console.WriteLine("pasword is wrong!");
                    return default;
                }
            }
        }
        public static void SignUp(string ad, string soyad, string mail, string password)
        {
            var a = Database.Users.FirstOrDefault(y => y.mail == mail);
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


