namespace devops_bff.DTOs.Product
{
    public class ProductTemplateDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Brand { get; set; }
        public double DisplayPrice { get; set; }
        public double? DisplayDiscountedPrice { get; set; }
        public required string Description { get; set; }
        public required ImageDTO[] DefaultImages { get; set; }
        public int ProductCategoryId { get; set; }
        public required ProductDTO[] Products { get; set; }
        public required string[] Badges { get; set; }
    }
}