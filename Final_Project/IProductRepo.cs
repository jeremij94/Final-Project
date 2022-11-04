namespace Final_Project
{
    public interface IProductRepo
    {
        Product AssignCategory();
        void DeleteProduct(Product product);
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Category> GetCategories();
        Product GetProduct(int id);
        void InsertProduct(Product productToInsert);
        void UpdateProduct(Product product);

        public IEnumerable<Product> Pastries();
        public IEnumerable<Product> Cakes();
        public IEnumerable<Product> Cheesecakes();
        public IEnumerable<Product> Pies();
        public IEnumerable<Product> Specials();
        public IEnumerable<Product> Merch();
    }
}