using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BbDatabase
{
    public class ProductRepository : IProductRepository
    {
        private readonly IConnectionStringProvider connectionStringProvider;

        public ProductRepository(IConnectionStringProvider connectionStringProvider)
        {
            this.connectionStringProvider = connectionStringProvider;
        }

        public Product AssignCategory()
        {
            var categoryList = GetCategories();
            var product = new Product();
            product.Categories = categoryList;

            return product;
        }

        public void DeleteProduct(Product product)
        {
            using var conn = new MySqlConnection(connectionStringProvider.GetConnectionString());
            conn.Execute("DELETE FROM REVIEWS WHERE ProductID = @id;",
                                       new { id = product.ProductID });
            conn.Execute("DELETE FROM Sales WHERE ProductID = @id;",
                                       new { id = product.ProductID });
            conn.Execute("DELETE FROM Products WHERE ProductID = @id;",
                                       new { id = product.ProductID });
        }


        public IEnumerable<Product> GetAllProducts()
        {
            using var conn = new MySqlConnection(connectionStringProvider.GetConnectionString());
            return conn.Query<Product>("SELECT * FROM PRODUCTS;");
        }

        public IEnumerable<Category> GetCategories()
        {
            using var conn = new MySqlConnection(connectionStringProvider.GetConnectionString());
            return conn.Query<Category>("SELECT * FROM categories;");
        }


        public Product GetProduct(int id)
        {
            using var conn = new MySqlConnection(connectionStringProvider.GetConnectionString());
            return conn.QuerySingle<Product>("SELECT * FROM PRODUCTS WHERE PRODUCTID = @id",
                new { id = id });
        }

        public void InsertProduct(Product productToInsert)
        {
            using var conn = new MySqlConnection(connectionStringProvider.GetConnectionString());
            conn.Execute("INSERT INTO products (NAME, PRICE, CATEGORYID) VALUES (@name, @price, @categoryID);",
                new { name = productToInsert.Name, price = productToInsert.Price, categoryID = productToInsert.CategoryID });
        }


        public void UpdateProduct(Product product)
        {
            using var conn = new MySqlConnection(connectionStringProvider.GetConnectionString());
            conn.Execute("UPDATE products SET Name = @name, Price = @price WHERE ProductID = @id",
                new { name = product.Name, price = product.Price, id = product.ProductID });
        }

    }
}
