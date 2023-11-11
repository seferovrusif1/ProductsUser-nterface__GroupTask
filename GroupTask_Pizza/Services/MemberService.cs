using GroupTask_Pizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupTask_Pizza.Services
{
    internal class MemberService
    {
        public static void GetPizzaCatalog()
        {
            Database.Products.ForEach(x => Console.WriteLine(x));
        }

        public static void ListsOfOrdered()
        {
            order.Basket.ForEach(x => Console.WriteLine(x));
        }


        //Elave eledik Method

        static Order order = new Order();
        public static void AddToCart()
        {
            Console.WriteLine("Enter the pizza Id to order: ");
            int idd = Convert.ToInt32(Console.ReadLine());
            var a=Database.Products.Find(x => x.Id ==idd );
            if (a == null)
            {
                Console.WriteLine("elemnt tapilmadi");
            }
            else
            {
                Console.WriteLine("pizza sayini daxil et");
                int say = Convert.ToInt32(Console.ReadLine());
                if (say<=a.Count)
                {
                    Product orderedPizza = new Product(a.Name,a.Price,a.Count-say);
                    a.Count =a.Count- say;
                    order.Basket.Add(orderedPizza);
                }
                else
                {
                    Console.WriteLine("Bu qeder mehsul yoxdur");
                }
            }
        }
       
                //Database.Products.Add(orderedPizza);

                //Console.WriteLine($"{orderedPizza.Name} has added to the ordered list.");
          
            
                //Console.WriteLine("Wrong number. Please select a correct number!");
                //Exception yaz
            

        public static void DoOrder()
        {
            if (order.Basket.Count == 0)
            {
                Console.WriteLine("Your Order lists are empty.You must order first.");

                //Exception yaz
            }
            else
            {
                ListsOfOrdered();
                decimal TotalPrice = 0;
                order.Basket.ForEach(x => TotalPrice+=x.Price*x.Count);
                Console.WriteLine($"Total Price: {TotalPrice:C}");
                Console.WriteLine("Adres - phone number");
                string adress=Console.ReadLine();
                string phonenumber=Console.ReadLine();
                order.Adress = adress;           order.OrderDate = DateTime.Now;    order.PhoneNumber = phonenumber;
                Database.OrdersList.Add(order);
                order.PhoneNumber = null;       order.OrderDate = default;          order.Adress = null;  order.Basket = new List<Product>() { };

                Console.WriteLine("Your Order is accepted succesfully. Thanks you!");
            }
        }


    }
}
