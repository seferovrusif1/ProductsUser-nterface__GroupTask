using GroupTask_Pizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GroupTask_Pizza.Utilies.Services
{
    internal static class AdminService
    {
        public static void GetAllUsers()
        {
            Database.Users.ForEach(u => Console.WriteLine(u));
        }
        public static void GetAllProducts()
        {
            Database.Products.ForEach(u => Console.WriteLine(u));
        }
        public static void AddProduct(string name, decimal price, int count)
        {
            Product product = new Product(name, price, count);
            Database.Products.Add(product);
        }
        public static void AddUser(string mail, string password, string name, string surname)
        {
            User user = new User(mail, password, name, surname);
            Database.Users.Add(user);
        }
        public static void RemoveProduct(int id)
        {
            Database.Products.Remove(GetProductById(id));
        }
        public static void RemoveUser(int id)
        {
            Database.Users.Remove(GetUserById(id));
        }
        public static void UpdateUser(int id)
        {
            var a = GetUserById(id);
            Console.WriteLine($"Userin rolu: {a.role}\nRolu deyismek isteyirsizse 1-e basin, Eks halda ferqli bir duymeye basin");
            string b = Console.ReadLine();
            if (b == "1")
            {
                if (a.role == Role.Admin)
                {
                    a.role = Role.Member;
                }
                else
                {
                    a.role = Role.Admin;
                }
            }
        }
        public static void UpdateProduct(int id)
        {
            Product a = GetProductById(id);
            Console.WriteLine(a);
            Console.WriteLine("1. Adi deyismek\n2. Qiymeti deyismek\n3. Sayi deyismek");
            string b = Console.ReadLine();
            switch (b)
            {
                case "1":
                    Console.WriteLine("Yeni adi daxil edin: ");
                    a.Name = Console.ReadLine();
                    break;
                case "2":
                    Console.WriteLine("Yeni qiymet daxil edin: ");
                    a.Price = Convert.ToDecimal(Console.ReadLine());
                    break;
                case "3":
                    Console.WriteLine("Yeni say daxil edin: ");
                    a.Count = Convert.ToInt32(Console.ReadLine());
                    break;
            }
        }
        public static User GetUserById(int id)
        {
            return Database.Users.Find(p => p.Id == id);
        }
        public static Product GetProductById(int id)
        {
            return Database.Products.Find(p => p.Id == id);
        }
    }
}
