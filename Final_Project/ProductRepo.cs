using System;
using System.Data;
using Dapper;

namespace Final_Project
{
    public class ProductRepo : IProductRepo
    {
        private readonly IDbConnection _conn;

        public ProductRepo(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _conn.Query<Product>("SELECT * FROM products;");
        }

        public IEnumerable<Category> GetCategories()
        {
            return _conn.Query<Category>("SELECT * FROM categories;");
        }

        public Product AssignCategory()
        {
            var categoryList = GetCategories();
            var product = new Product();
            product.Categories = categoryList;
            return product;
        }

        public Product GetProduct(int id)
        {
            return _conn.QuerySingle<Product>("SELECT * FROM PRODUCTS WHERE PRODUCTID = @id", new { id = id });
        }

        public void UpdateProduct(Product product)
        {
            _conn.Execute("UPDATE products SET Name = @name, Price = @price WHERE ProductID = @id",
            new { name = product.Name, price = product.Price, id = product.ProductID });
        }

        public void InsertProduct(Product productToInsert)
        {
            _conn.Execute("INSERT INTO products (NAME, PRICE, CATEGORYID) VALUES (@name, @price, @categoryID);",
                new { name = productToInsert.Name, price = productToInsert.Price, categoryID = productToInsert.CategoryID });
        }

        public void DeleteProduct(Product product)
        {
            _conn.Execute("DELETE FROM Products WHERE ProductID = @id;", new { id = product.ProductID });
        }

        public IEnumerable<Product> Pastries()
        {
            return _conn.Query<Product>("SELECT * FROM products WHERE CategoryID = 1;");
        }

        public IEnumerable<Product> Cakes()
        {
            return _conn.Query<Product>("SELECT * FROM products WHERE CategoryID = 2;");
        }

        public IEnumerable<Product> Cheesecakes()
        {
            return _conn.Query<Product>("SELECT * FROM products WHERE CategoryID = 3;");
        }

        public IEnumerable<Product> Pies()
        {
            return _conn.Query<Product>("SELECT * FROM products WHERE CategoryID = 4;");
        }

        public IEnumerable<Product> Specials()
        {
            return _conn.Query<Product>("SELECT * FROM products WHERE CategoryID = 5;");
        }

        public IEnumerable<Product> Merch()
        {
            return _conn.Query<Product>("SELECT * FROM products WHERE CategoryID = 6;");
        }
    }
}


