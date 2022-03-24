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

    public IEnumerable<Product> GetAllProducts()
        {
            using var conn = new MySqlConnection(connectionStringProvider.GetConnectionString());
            return conn.Query<Product>("SELECT * FROM PRODUCTS;");
        }

        public Product GetProduct(int id)
        {
            using var conn = new MySqlConnection(connectionStringProvider.GetConnectionString());
            return conn.QuerySingle<Product>("SELECT * FROM PRODUCTS WHERE PRODUCTID = @id",
                new { id = id });
        }

    }
}
