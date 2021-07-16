using ImportProduct.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace ImportProduct
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> list = new List<Product>();
            Console.Write("Enter the number of products: ");
            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                Console.WriteLine($"Product #{i + 1} data:");
                Console.Write("Common, used or imported (c/u/i)? ");
                char letter = char.Parse(Console.ReadLine());
                if (letter == 'i')
                {
                    Console.Write("Nome: ");
                    string nome = Console.ReadLine();
                    Console.Write("Price: ");
                    double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    Console.Write("Customs fee: ");
                    double customs = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    // POLIMORFISMO
                    list.Add(new ImportedProduct(nome, price, customs));
                }
                else if (letter == 'c')
                {
                    Console.Write("Nome: ");
                    string nome = Console.ReadLine();
                    Console.Write("Price: ");
                    double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    list.Add(new Product(nome, price));
                }
                else
                {
                    Console.Write("Nome: ");
                    string nome = Console.ReadLine();
                    Console.Write("Price: ");
                    double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    Console.Write("Manufacture Date (DD/MM/YYYY): ");
                    DateTime date = DateTime.Parse(Console.ReadLine());

                    //POLIMORFISMO
                    list.Add(new UsedProduct(nome, price, date));
                }
            }

            Console.WriteLine();
            Console.WriteLine("PRICE TAGS:");
            foreach (Product p in list)
            {
                Console.WriteLine(p.priceTag());
            }

        }
    }
}
