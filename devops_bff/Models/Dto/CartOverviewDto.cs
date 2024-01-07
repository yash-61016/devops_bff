namespace devops_bff.Models.Dto
{
    public class CartOverviewDto
    {
        public int CartId { get; set; }
        public int UserId { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
