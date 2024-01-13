namespace devops_bff.DTOs.Cart.Create
{
    public class CartOverviewCreateDto
    {
        public int userId { get; set; }
        public decimal discount { get; set; }
        public decimal totalPrice { get; set; }
    }
}