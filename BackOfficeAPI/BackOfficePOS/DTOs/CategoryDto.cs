namespace BackOfficePOS.DTOs
{
    public class CategoryBaseDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? CategoryImage { get; set; }
        public string? Description { get; set; }
        public string? ShortDescription { get; set; }
        public int ParantID { get; set; }
        public int BranchID { get; set; }
        public bool Active { get; set; }

    }
    public class CategoryDto : CategoryBaseDto
    {
        public string? Branch { get; set; }
    }
    public class SaveCategoryDTO : CategoryBaseDto
    {
        public IFormFile ImageFile { get; set; }

    }
}
