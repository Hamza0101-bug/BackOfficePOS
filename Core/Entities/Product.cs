namespace Core.Entities
{
    public class Product : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public string? ImageUrl { get; set; }
        public Category? Category { get; set; }
        public int CategoryID { get; set; }
        public Brand? Brand { get; set; }
        public int BrandID { get; set; }
    }
}
