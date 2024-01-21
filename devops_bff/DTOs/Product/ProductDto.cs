namespace devops_bff.DTOs.Product
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public double Price { get; set; }
        public double? DiscountedPrice { get; set; }
        public required string Color { get; set; }
        public required ImageDTO Images { get; set; }
        public required PropertyDTO[] Properties { get; set; }
        public int ProductTemplateId { get; set; }
        public required string[] Tags { get; set; }
    }

}