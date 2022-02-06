namespace BackOfficePOS.DTOs
{
    public class BranchDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
    }
  
    public class SaveBranchDTO : BranchDto
    {
        //public IFormFile ImageFile { get; set; }
    }
}
