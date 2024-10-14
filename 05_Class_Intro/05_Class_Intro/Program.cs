using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Class_Intro
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Product[] allProducts = 
            { 
                new Product("Classic Coke", "Coca-Cola", 1.99),
                new Product("Cool Ranch Doritos", "Doritos", 3.49),
                new Product("Rice Krispies Cereal", "Kellogg's", 4.99),
                new Product("Cherry Garcia Ice Cream", "Ben & Jerry’s", 3.99),
                new Product("Barbecue Potato Chips", "Lay's", 2.49),
                new Product("Kit Kat Bar", "Kit Kat", 1.25),
            };

            PrintProducts(allProducts, 1.49, 3.49);
        }

        static void PrintProducts(Product[] givenProducts, double minValue, double maxValue)
        {
            int count = 1;
            foreach (Product product in givenProducts)
            {
                if (product.Price <= maxValue && product.Price >= minValue)
                { 
                    Console.WriteLine($"{count}.\nName: {product.Name}\nBrandName: {product.BrandName}\nPrice: {product.Price}.\n");
                    count++;
                }
            }
        }
    }
}
