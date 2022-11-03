namespace Final_Project
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string? BestSeller { get; set; }
        public string? Seasonal { get; set; }
        public int CategoryID { get; set; }

        public IEnumerable<Category> Categories { get; set; }

    }
}