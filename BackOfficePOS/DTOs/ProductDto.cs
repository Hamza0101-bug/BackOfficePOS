namespace BackOfficePOS.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public string? ImageUrl { get; set; }
        public string? Category { get; set; }
        public int CategoryID { get; set; }
        public string? Brand { get; set; }
        public int BrandID { get; set; }
    }
}
