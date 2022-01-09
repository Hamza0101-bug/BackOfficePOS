namespace BackOfficePOS.DTOs
{
    public class CategoryDto
    {
        public string? Name { get; set; }
        public string? CategoryImage { get; set; }
        public string? Description { get; set; }
        public string? ShortDescription { get; set; }
        public int ParantID { get; set; }
        public int BranchID { get; set; }

    }

    public class SaveCategoryDTO : CategoryDto
    {
        public IFormFile ImageFile { get; set; }

    }
}
