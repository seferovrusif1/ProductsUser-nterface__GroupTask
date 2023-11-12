using GroupTask_Pizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupTask_Pizza.Utilies.Services
{
    internal class MemberService
    {
        public static void GetPizzaCatalog()
        {
            Database.Products.ForEach(x => Console.WriteLine(x));
        }

        public static void ListsOfBasket()
        {
            order.Basket.ForEach(x => Console.WriteLine(x));
        }
        public static void ListsOfOrdered()
        {
            Database.OrdersList.ForEach(x => Console.WriteLine(x));
        }


        
        static Order order = new Order(null,null, default,new List<Product>() { });
        public static List<(int,int)> BasketTemp = new List<(int,int)>();
        public static bool  CompleteOrder=true;

        public static void AddToCart()
        {
            Console.WriteLine("Enter the pizza Id to order: ");
            int idd = Convert.ToInt32(Console.ReadLine());
            var a = Database.Products.Find(x => x.Id == idd);
            if (a == null)
            {
                Console.WriteLine("elemnt tapilmadi");
            }
            else
            {   
                Console.WriteLine("pizza sayini daxil et");
                int say = Convert.ToInt32(Console.ReadLine());
                if (say <= a.Count && say>0)
                {
                    Product orderedPizza = new Product(a.Name, a.Price, say);
                   // a.Count = a.Count - say;
                    order.Basket.Add(orderedPizza);
                    BasketTemp.Add((a.Id, say));
                    CompleteOrder = false;
                }
                else
                {
                    Console.WriteLine("Mehsul sayi yanlisdir");
                }
            }
        }
        public static void DoOrder()
        {
            if (order.Basket.Count == 0)
            {
                Console.WriteLine("Your Order lists are empty.You must order first.");
            }
            else
            {
                ListsOfBasket();
                decimal TotalPrice = 0;
                order.Basket.ForEach(x => TotalPrice += x.Price * x.Count);
                Console.WriteLine($"Total Price: {TotalPrice:C}"); 
                Console.WriteLine("Adres - phone number");
                string adress = Console.ReadLine();
                string phonenumber = Console.ReadLine();
                order=new Order(adress,phonenumber,DateTime.Now,order.Basket);
                Database.OrdersList.Add(order);
                order.Adress = null; order.PhoneNumber = null; order.OrderDate = default;  order.Basket=new List<Product>() { };
                Console.WriteLine("Sifarish tamamlandi!");
                CompleteOrder = true;
                BasketTemp.Clear();

                CompletedOrder();
                
            }
        }


        public static void CompletedOrder()
        {

            order.Adress = null;
            order.PhoneNumber = null;
            order.OrderDate = default;
            order.Basket = new List<Product>() { };
            foreach (var item in BasketTemp)
            {
                foreach (var prod in Database.Products)
                {
                    if (item.Item1 == prod.Id)
                    {
                        prod.Count -= item.Item2;
                    }
                }
            }
        }





        public static void UnCompletedOrder()
        {

            order.Adress = null;
            order.PhoneNumber = null;
            order.OrderDate = default;
            order.Basket = new List<Product>() { };
            foreach (var item in BasketTemp)
            {
                foreach (var prod in Database.Products)
                {
                    if (item.Item1==prod.Id)
                    {
                        prod.Count += item.Item2;
                    }
                }
            }
        }


    }
}
