namespace Core.Entities
{
    public class Product : BaseEntity
    {
        public string? ItemCode { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public string? ImageName { get; set; } 
        public string? ShortDescription { get; set; }
        public string? Tags { get; set; }
        public bool Active { get; set; }

        // Include Properties 
        public Category? Category { get; set; }
        public int CategoryID { get; set; }
        public Brand? Brand { get; set; }
        public int BrandID { get; set; }
        public Branch Branch { get; set; }
        public int BranchID { get; set; }

    }
}
