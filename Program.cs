using ExercicioFix.Entities;
using ExercicioFix.Entities.Enums;
using System;
using System.Globalization;

namespace ExercicioFix
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime moment = DateTime.Now;
            Console.WriteLine("Enter client data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth date (DD / MM / YYYY): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter order data:");
            Console.Write("Status: ");
            OrderStatus status = Enum.Parse< OrderStatus> (Console.ReadLine());
            Console.Write("How many items to this order ? ");
            int n = int.Parse(Console.ReadLine());

            Client client = new Client(name, email, birthDate);

            Order order = new Order(moment, status, client);

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter #{i} item data:");
                Console.Write("Product name: ");
                string itemName = Console.ReadLine();
                Console.Write("Product price: ");
                double itemPrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Product product = new Product(itemName, itemPrice);
                Console.Write("Quantity: ");
                int itemQuanty = int.Parse(Console.ReadLine());
                OrderItem orderItem = new OrderItem(itemQuanty, product);
                order.AddItem(orderItem);
                Console.WriteLine();
            }
            Console.WriteLine("ORDER SUMMARY:");
            Console.WriteLine(order);
         
        }
    }
}
