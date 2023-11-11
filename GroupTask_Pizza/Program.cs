using GroupTask_Pizza.Models;
using GroupTask_Pizza.Services;
using System.Runtime.ConstrainedExecution;

namespace GroupTask_Pizza
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Database.Products.Add(new Product("Italiano Pizza", 15));
            Database.Products.Add(new Product("Mixed Pizza", 20));
            Database.Products.Add(new Product("Mexican Pizza", 30));
            Database.Products.Add(new Product("Head Papa John's Pizza", 25));
            Database.Products.Add(new Product("Vegetarian Pizza", 15));


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
                        rol =UserService.SignIn(Console.ReadLine(), Console.ReadLine());
                        break;
                    case "2":
                        Console.WriteLine("ad soyad mail password");
                        UserService.SignUp(Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), Console.ReadLine());
                        goto point1;
                    case "3":
                        iscontinue = false;
                        break;
                }
                while (rol == Role.Admin)
                {
                    Console.WriteLine($"1. Pizzalara bax\n2. Sifaris ver\n3. Pizzalar\n4. Userler\n5. Hesabdan Cix ");
                    string b = Console.ReadLine();
                    switch (b)
                    {
                        case "1":
                            break;
                        case "2":
                            break;
                        case "3":             case "4":
                            Console.WriteLine($"1. Hamsina bax\n2. Elave et\n3. Duzelis et (ID ile)\n4. Sil (ID ile)");
                            b += Console.ReadLine();
                            switch (b)
                            {
                                case "31":
                                    AdminService.GetAllProducts();
                                    break;
                                case "41":
                                    AdminService.GetAllUsers();
                                    break;
                                case "32":
                                    Console.WriteLine("NAme-Price");
                                    AdminService.AddProduct(Console.ReadLine(), Convert.ToDecimal(Console.ReadLine()));
                                    break;
                                case "42":
                                    AdminService.AddUser(Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), Console.ReadLine());
                                    break;
                                case "33":
                                    Console.WriteLine("enter id");
                                    AdminService.UpdateProduct(Convert.ToInt32(Console.ReadLine()));
                                    break;
                                case "43":
                                    Console.WriteLine("enter id");
                                    AdminService.UpdateUser(Convert.ToInt32(Console.ReadLine()));
                                    break;
                                case "34":
                                    Console.WriteLine("enter id");
                                    AdminService.RemoveProduct(Convert.ToInt32(Console.ReadLine()));
                                    break;
                                case "44":
                                    Console.WriteLine("enter id");
                                    AdminService.RemoveUser(Convert.ToInt32(Console.ReadLine()));

                                    break;
                            }
                            break;
                        case "5":
                            rol = Role.Default;
                            break;

                    }
                }
                while (rol == Role.Member)
                {
                    /* Console.WriteLine($"1. Pizzalara bax\n2. Sifariş ver\n3. Hesabdan Cix ");
                     string b = Console.ReadLine();
                     switch (b)
                     {
                         case "1":
                             break;
                         case "2":
                             break;
                         case "3":
                             rol = Role.Default;
                             break;
                     }*/

                    // --------------------------------------

                    bool IsContinue = true;
                    while (IsContinue)
                    {
                        Console.WriteLine("Pizza Catalogs: \n");

                        Console.WriteLine("1. View Pizzas");
                        Console.WriteLine("2. Add to Cart");
                        Console.WriteLine("3. Place an Order");
                        Console.WriteLine("4. Exit");

                        byte opt = Convert.ToByte(Console.ReadLine());
                        switch (opt)
                        {
                            case 1:
                                ListOfCatalogs();
                                break;
                            case 2:
                                AddToCart();
                                break;
                            case 3:
                                DoOrder();
                                break;
                            case 4:
                                IsContinue = false;
                                Console.WriteLine("Thanks for Visiting!");
                                break;
                            default:
                                Console.WriteLine("Wrong Option.Please opt again.");
                                break;
                        }
                    }

                }
            }
        }
    }
}










