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
        public void AddToOrder(Product pizza)
        {
            Database.OrderedList.Add(pizza);
        }

        public List<Product> GetOrder()
        {
            return Database.OrderedList;
        }
        public static void AddPizza(Product pizza)
        {
            Database.Products.Add(pizza);
        }

        public static void GetPizzaCatalog()
        {
            Database.Products.ForEach(x => Console.WriteLine(x));
        }




        //Elave eledik Method

        static void ListOfCatalogs()
        {
            for (int i = 0; i < Database.Products.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Database.Products[i].Name} - {Database.Products[i].Price} ");
            }
        }

        static void AddToCart()
        {
            Console.WriteLine("Enter the pizza number to order: ");
            if (int.TryParse(Console.ReadLine(), out int PizzaNumber) && PizzaNumber >= 1
                && PizzaNumber <= Database.Products.Count)
            {
                // Burada -1 yazmagimin sebebi list 0 dan baslayir inputa 1 yazsam gedir 2 cisine dusur ona gore
                Product orderedPizza = Database.Products[PizzaNumber - 1];

                Database.Products.Add(orderedPizza);

                Console.WriteLine($"{orderedPizza.Name} has added to the ordered list.");
            }
            else
            {
                Console.WriteLine("Wrong number. Please select a correct number!");
                //Exception yaz
            }
        }

        static void DoOrder()
        {
            if (Database.OrderedList.Count == 0)
            {
                Console.WriteLine("Your Order lists are empty.You must order first.");
                //Exception yaz
            }
            else
            {
                double TotalPrice = Database.OrderedList.Sum(pizza => pizza.Price);
                ListsOfOrdered();
                Console.WriteLine($"Total Price: {TotalPrice:C}");
                Console.WriteLine("Your Order is accepted succesfully. Thanks you!");
            }
        }

        static void ListsOfOrdered()
        {
            /*Console.WriteLine("List of Orders:");
            for (int i = 0; i < Database.OrderedList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Database.OrderedList[i].Name} - {Database.OrderedList[i].Price:C}");
            }*/

            Database.OrderedList.ForEach(x => Console.WriteLine(x));
        }
    }
}
