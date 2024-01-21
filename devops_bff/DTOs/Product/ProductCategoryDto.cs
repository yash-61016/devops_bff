namespace devops_bff.DTOs.Product
{
    public class ProductCategoryDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int PreferenceIndex { get; set; }
    }
}