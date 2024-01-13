namespace devops_bff.DTOs.Cart.Update
{
    public class CartOverviewUpdateDto
    {
        public int cartId { get; set; }
        public int userId { get; set; }
        public decimal discount { get; set; }
        public decimal totalPrice { get; set; }
        public bool isCheckedOut { get; set; }
    }
}