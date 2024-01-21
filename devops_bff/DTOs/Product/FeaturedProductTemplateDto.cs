namespace devops_bff.DTOs.Product
{
    public class FeaturedProductTemplateDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string BriefDescription { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public double StartingPrice { get; set; }
        public required ImageDTO NewFeatureImage { get; set; }
        public required string NewFeatureDescription { get; set; }
        public required ImageDTO NewFeatureImage2 { get; set; }
        public required string NewFeatureDescription2 { get; set; }
        public required string BannerTitle { get; set; }
        public required ImageDTO[] BannerImages { get; set; }
        public required ImageDTO[] FeaturedImages { get; set; }
        public int ProductCategoryId { get; set; }
        public required ProductDTO[] Products { get; set; }
        public required PropertyDTO[] Properties { get; set; }
    }
}