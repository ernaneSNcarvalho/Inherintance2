using System;
using System.Collections.Generic;
using System.Globalization;
using Inherintance2.Entities;

namespace Inherintance2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            List<Product> products = new List<Product>();
            Console.Write("Enter the number of products: ");
            int n = int.Parse(Console.ReadLine());
            
            for(int i=1; i <= n; i++)
            {
                Console.WriteLine($"Product #{i} data: ");
                Console.Write("Common, used or imported (c/u/i): ");
                char response = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                if(response == 'i')
                {
                    Console.Write("Customs fee: ");
                    double customsFee = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    products.Add(new ImportedProduct(name, price, customsFee));
                }
                else if(response == 'c')
                {
                    products.Add(new Product(name, price));
                }
                else
                {
                    Console.Write("Manufacture date (dd/MM/yyyy): ");
                    DateTime manufactureDate = DateTime.Parse(Console.ReadLine());
                    products.Add(new UsedProduct(name, price, manufactureDate));
                }
            }
            Console.WriteLine();
            Console.WriteLine("PRICE TAGS: ");
            foreach(var product in products)
            {
                Console.WriteLine(product.PriceTag());
            }
        }
    }
}
