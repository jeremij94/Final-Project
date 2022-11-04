using System;
using System.Data;
using Dapper;

namespace Final_Project
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly IDbConnection _conn;

        public CategoryRepo(IDbConnection conn)
        {
            _conn = conn;
        }

        public Category GetCategory(int id)
        {
            return _conn.QuerySingle<Category>("SELECT * FROM categories WHERE CategoryID = @id;",
                new {id = id});
        }
        public IEnumerable<Category> GetCategories()
        {
            return _conn.Query<Category>("SELECT * FROM categories;") ;
        }

        public void DeleteCategory(Category category)
        {
            _conn.Execute("DELETE FROM categories WHERE CategoryID = @id;", new { id = category.CategoryID });
        }

        public void InsertCategory(Category categoryToInsert)
        {
            _conn.Execute("INSERT INTO categories (NAME, CATEGORYID) VALUES (@name, @categoryID);",
                new { name = categoryToInsert.Name, categoryID = categoryToInsert.CategoryID });
        }

        public void UpdateCategory(Category category)
        {
            _conn.Execute("UPDATE categories SET Name = @name WHERE CategoryID = @id",
            new { name = category.Name, id = category.CategoryID });
        }
    }
}

