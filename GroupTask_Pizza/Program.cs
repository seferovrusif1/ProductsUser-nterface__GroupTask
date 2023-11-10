using GroupTask_Pizza.Models;

namespace GroupTask_Pizza
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user1 = new User("rs@gmail.com", "1234abcd", "Rusif", "Safarov"); user1.role = Role.Admin;
            User user2 = new User("fd@gmail.com", "1234abcd", "Fuad", "Khalilov"); user2.role = Role.Admin;
            User user3 = new User("nc@gmail.com", "1234abcd", "Nihad", "Cafarov"); user3.role = Role.Admin;

            Database.Users.Add(user1); Database.Users.Add(user2); Database.Users.Add(user3);


            Role rol = Role.Default;
            bool iscontinue = true;
            while (iscontinue)
            {
            point1:
                Console.WriteLine("1. Sign In\n2. Sign Up\n3. Quit");
                string a = Console.ReadLine();
                switch (a)
                {
                    case "1":
                        Console.WriteLine("name->Pasword");
                        rol = Services.SignIn(Console.ReadLine(), Console.ReadLine());
                        break;
                    case "2":
                        Console.WriteLine("ad soyad mail password");
                        Services.SignUp(Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), Console.ReadLine());
                        goto point1;
                    case "3":
                        iscontinue = false;
                        break;
                }
                if (rol == Role.Admin)
                {
                    Console.WriteLine($"1. Pizzalara bax\n2. Sifaris ver\n3. Pizzalar\n4. Userler");
                    string b = Console.ReadLine();
                    switch (b)
                    {
                        case "1":
                            break;
                        case "2":
                            break;
                        case "3":
                        case "4":
                            Console.WriteLine($"1. Hamsina bax\n2. Elave et\n3. Duzelis et (ID ile)\n4. Sil (ID ile)");
                            break;

                    }
                }
            }
        }
    }
}










