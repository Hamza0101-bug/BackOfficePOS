namespace BackOfficePOS.DTOs
{
    public class BrandBaseDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ShortDescription { get; set; }
        public string? BrandImage { get; set; }
        public int BranchID { get; set; }
    }
    public class BrandDto: BrandBaseDto
    {
        public string? Branch { get; set; }
    }
    public class SaveBrandDTO : BrandBaseDto
    {
        public IFormFile ImageFile { get; set; }
    }
}
