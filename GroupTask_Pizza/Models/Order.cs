using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GroupTask_Pizza.Models
{
    internal class Order
    {
        public int Id { get; } = 1;
        public string Adress { get; set; }
        public string PhoneNumber {  get; set; }
        public DateTime OrderDate { get; set; }
        public  List<Product> Basket = new List<Product>() { };

    }
}
