using GroupTask_Pizza.Models;
using GroupTask_Pizza.Utilies.Services;
using GroupTask_Pizza.Utilies.Validation;
using System.Runtime.ConstrainedExecution;

namespace GroupTask_Pizza
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Database.Products.Add(new Product("Italiano Pizza", 15,5));
            Database.Products.Add(new Product("Mixed Pizza", 20, 5));
            Database.Products.Add(new Product("Mexican Pizza", 30, 5));
            Database.Products.Add(new Product("Head Papa John's Pizza", 25, 5));
            Database.Products.Add(new Product("Vegetarian Pizza", 15, 5));


            User user1 = new User("rs@gmail.com", "1234abcd", "Rusif", "Safarov"); user1.role = Role.Admin;
            User user2 = new User("fd@gmail.com", "1234abcd", "Fuad", "Khalilov"); user2.role = Role.Admin;
            User user3 = new User("nc@gmail.com", "1234abcd", "Nihad", "Cafarov"); user3.role = Role.Admin;

            Database.Users.Add(user1); Database.Users.Add(user2); Database.Users.Add(user3);


            Role rol = Role.Default;
            bool iscontinue = true;
            while (iscontinue)
            {
            point1:
                Console.WriteLine("1. Girish edin\n2. Qeydiyatdan kechin\n3. Proqrami dayandirin");
                string a = Console.ReadLine();
                switch (a)
                {
                    case "1":
                        Console.WriteLine("Mail-i daxil edin:"); string mail = Console.ReadLine();
                        if (regex.MailValidation(mail))
                        {
                            Console.WriteLine("Shifreni daxil edin:"); string password = Console.ReadLine();
                            if (regex.PasswordValidation(password))
                            {
                                rol = UserService.SignIn(mail, password);
                            }
                            else
                            {
                                Console.WriteLine("Yanlish Melumat!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Yanlish Melumat!");
                        }
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
                    Console.WriteLine($"1. Pizzalar(Admin)\n2. Userler(Adim)\n3. Mehsullara bax\n4. Sebete elave et\n5. Sebete bax\n6. Sifarisi tamamla\n7. Sifarishlere bax\n8. Hesabdan Cix ");
                    string b = Console.ReadLine();
                    switch (b)
          
                    {

                        case "1":             case "2":
                            Console.WriteLine($"1. Hamsina bax\n2. Elave et\n3. Duzelis et (ID ile)\n4. Sil (ID ile)");
                            b =b+ Console.ReadLine();
                            switch (b)
                            {
                                case "11":
                                    AdminService.GetAllProducts();
                                    break;
                                case "21":
                                    AdminService.GetAllUsers();
                                    break;
                                case "12":
                                    Console.WriteLine("NAme-Price-count");
                                    AdminService.AddProduct(Console.ReadLine(), Convert.ToDecimal(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()));
                                    break;
                                case "22":
                                    AdminService.AddUser(Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), Console.ReadLine());
                                    break;
                                case "13":
                                    Console.WriteLine("enter id");
                                    AdminService.UpdateProduct(Convert.ToInt32(Console.ReadLine()));
                                    break;
                                case "23":
                                    Console.WriteLine("enter id");
                                    AdminService.UpdateUser(Convert.ToInt32(Console.ReadLine()));
                                    break;
                                case "14":
                                    Console.WriteLine("enter id");
                                    AdminService.RemoveProduct(Convert.ToInt32(Console.ReadLine()));
                                    break;
                                case "24":
                                    Console.WriteLine("enter id");
                                    AdminService.RemoveUser(Convert.ToInt32(Console.ReadLine()));

                                    break;
                            }
                            break;
                        case "3":
                            MemberService.GetPizzaCatalog();
                            break;
                        case "4":
                            MemberService.AddToCart();
                            break;
                        case "5":
                            MemberService.ListsOfBasket();
                            break;
                        case "6":
                            MemberService.DoOrder();
                            break;
                        case "7":
                            MemberService.ListsOfOrdered();
                            break;
                        case "8":
                            //if (MemberService.CompleteOrder == false)
                            //{
                            //    MemberService.UnCompletedOrder();
                            //}
                            rol = Role.Default;
                            break;

                        default:
                            Console.WriteLine("Wrong Option.Please opt again.");
                            break;

                    }
                }
                while (rol == Role.Member)
                {
                        Console.WriteLine($"1. Mehsullara bax\n2. Sebete elave et\n3. Sebete bax\n4. Sifarisi tamamla\n5. Hesabdan cix");
                        string opt = Console.ReadLine();
                        switch (opt)
                        {
                            case "1":
                                MemberService.GetPizzaCatalog();
                                break;
                            case "2":
                                MemberService.AddToCart();
                                break;
                            case "3":
                                MemberService.ListsOfBasket();
                                break;
                            case "4":
                                MemberService.DoOrder();
                                break;
                            case "5":
                            //if (MemberService.CompleteOrder == false)
                            //{
                            //    MemberService.UnCompletedOrder();
                            //}
                                rol = Role.Default;
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










