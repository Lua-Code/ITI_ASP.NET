namespace ITI_ASP.NET.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public int Stock { get; set; }
        public double Rating { get; set; }
        public bool IsAvailable { get; set; }
    }
}
