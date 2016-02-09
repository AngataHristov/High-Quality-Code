
namespace Orders
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using Models;

    public class OrdersMain
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            DataMapper dataMapper = new DataMapper();

            IEnumerable<Category> allCategories = dataMapper.GetAllCategories();
            IEnumerable<Product> allProducts = dataMapper.GetAllProducts();
            IEnumerable<Order> allOrders = dataMapper.GetAllOrders();

            IEnumerable<string> FiveMostExpensiveProducts = NewMethod(allProducts);

            Console.WriteLine(string.Join(Environment.NewLine, FiveMostExpensiveProducts));

            DrawSeparationLine();

            var numberOfProductsByCategory = allProducts
                .GroupBy(p => p.CategoryId)
                .Select(grp => new { Category = allCategories.First(c => c.Id == grp.Key).Name, Count = grp.Count() })
                .ToList();

            foreach (var item in numberOfProductsByCategory)
            {
                Console.WriteLine("{0}: {1}", item.Category, item.Count);
            }

            DrawSeparationLine();

            var fiveTopProductsbyQuantity = allOrders
                 .GroupBy(o => o.ProductId)
                 .Select(grp => new { Product = allProducts.First(p => p.Id == grp.Key).Nome, Quantities = grp.Sum(grpgrp => grpgrp.Quant) })
                 .OrderByDescending(q => q.Quantities)
                 .Take(5);

            foreach (var item in fiveTopProductsbyQuantity)
            {
                Console.WriteLine("{0}: {1}", item.Product, item.Quantities);
            }

            DrawSeparationLine();

            // The most profitable category
            var category = allOrders
                .GroupBy(o => o.ProductId)
                .Select(g => new { catId = allProducts.First(p => p.Id == g.Key).CategoryId, price = allProducts.First(p => p.Id == g.Key).Price, quantity = g.Sum(p => p.Quant) })
                .GroupBy(gg => gg.catId)
                .Select(grp => new { category_name = allCategories.First(c => c.Id == grp.Key).Name, total_quantity = grp.Sum(g => g.quantity * g.price) })
                .OrderByDescending(g => g.total_quantity)
                .First();

            Console.WriteLine("{0}: {1}", category.category_name, category.total_quantity);
        }

        private static void DrawSeparationLine()
        {
            Console.WriteLine(new string('-', 10));
        }

        private static IEnumerable<string> NewMethod(IEnumerable<Product> allProducts)
        {
            return allProducts
                            .OrderByDescending(p => p.Price)
                            .Take(5)
                            .Select(p => p.Nome);
        }
    }
}
