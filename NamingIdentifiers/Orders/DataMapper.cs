
namespace Orders
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using Models;

    public class DataMapper
    {
        private const string CategoriesFileNameDefault = "../../Data/categories.txt";
        private const string ProductsFileNameDefault = "../../Data/products.txt";
        private const string OrdersFileNameDefault = "../../Data/orders.txt";


        public DataMapper()
        {
            this.CategoriesFileName = CategoriesFileNameDefault;
            this.ProductsFileName = ProductsFileNameDefault;
            this.OrdersFileName = OrdersFileNameDefault;
        }

        public string CategoriesFileName { get; private set; }

        public string ProductsFileName { get; private set; }

        public string OrdersFileName { get; private set; }

        public IEnumerable<Category> GetAllCategories()
        {
            List<string> categories = ReadFileLines(this.CategoriesFileName, true);

            return categories
                .Select(c => c.Split(','))
                .Select(c => new Category
                {
                    Id = int.Parse(c[0]),
                    Name = c[1],
                    Description = c[2]
                });
        }

        public IEnumerable<Product> GetAllProducts()
        {
            List<string> prod = ReadFileLines(this.ProductsFileName, true);
            return prod
                .Select(p => p.Split(','))
                .Select(p => new Product
                {
                    Id = int.Parse(p[0]),
                    Nome = p[1],
                    CategoryId = int.Parse(p[2]),
                    Price = decimal.Parse(p[3]),
                    UnitsInStock = int.Parse(p[4]),
                });
        }

        public IEnumerable<Order> GetAllOrders()
        {
            List<string> orders = ReadFileLines(this.OrdersFileName, true);

            return orders
                .Select(p => p.Split(','))
                .Select(p => new Order
                {
                    Id = int.Parse(p[0]),
                    ProductId = int.Parse(p[1]),
                    Quant = int.Parse(p[2]),
                    Discount = decimal.Parse(p[3]),
                });
        }

        private List<string> ReadFileLines(string fileName, bool hasHeader)
        {
            List<string> allLines = new List<string>();

            StreamReader reader = new StreamReader(fileName);

            using (reader)
            {
                string currentLine;

                if (hasHeader)
                {
                    reader.ReadLine();
                }

                while ((currentLine = reader.ReadLine()) != null)
                {
                    allLines.Add(currentLine);
                }
            }

            return allLines;
        }
    }
}
