using System;
namespace Final_Project
{
    public interface ICategoryRepo
    {
        void DeleteCategory(Category category);
        IEnumerable<Category> GetCategories();
        Category GetCategory(int id);
        void InsertCategory(Category categoryToInsert);
        void UpdateCategory(Category category);
    }
}

