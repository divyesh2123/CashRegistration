using System;

namespace CashRegistration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductManagment product =  ProductManagment.GetInstance();

            Console.WriteLine("Welcome to Walmart....");

            Console.WriteLine("Press 0 to exit and checkout");
            Console.WriteLine("A");
            Console.WriteLine("B");
            Console.WriteLine("C"); 
            Console.WriteLine("D");
          


            while (true)
            {
                Console.WriteLine("Please Enter the Item/Exit");
                var item = Console.ReadLine();

                switch(item)
                {
                    case "A":
                    case "B":
                    case "C":
                    case "D":
                    case "E":

                        product.Scan(item);

                        break;

                    case "0":

                      var totalPrice =  product.GetTotalPrice();

                        Console.WriteLine("Total Price" + totalPrice);

                        break;

                }

               
                




            }


        }
    }
}
