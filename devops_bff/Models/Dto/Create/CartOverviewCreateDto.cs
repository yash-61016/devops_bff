namespace devops_bff.Models.Dto.Create
{
    public class CartOverviewCreateDto
    {
        public int UserId { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalPrice { get; set; }
    }
}