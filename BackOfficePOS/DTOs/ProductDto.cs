namespace BackOfficePOS.DTOs
{
    public class BaseDto 
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public string? ImageName { get; set; }
        public int BrandID { get; set; }
        public int CategoryID { get; set; }

    }

    public class ProductDto : BaseDto
    {
        public string? Category { get; set; }
        public string? Brand { get; set; }

    }
    public class productSaveDto : BaseDto
    {
        public IFormFile ProductImage { get; set; }
    }
}
