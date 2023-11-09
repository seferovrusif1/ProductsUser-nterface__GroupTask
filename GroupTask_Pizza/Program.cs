using GroupTask_Pizza.Models;

namespace GroupTask_Pizza
{
    internal class Program
    {
        static void Main(string[] args)
        {
            point1:
            Console.WriteLine("1.Sign In\n2. Sign Up");
            string a=Console.ReadLine();
            switch (a)
            {
                case "1":
                    Console.WriteLine("name->Pasword");
                    Services.SignIn(Console.ReadLine(), Console.ReadLine());
                    break;
                case "2":
                    Console.WriteLine("ad soyad mail password");
                    Services.SignUp(Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), Console.ReadLine());
                    goto point1;
            }
            bool admin = true;
            switch(admin)
            {
                case true:

                    break;

            }




        }
    }
}