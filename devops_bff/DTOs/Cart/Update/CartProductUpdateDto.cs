namespace devops_bff.DTOs.Cart.Update
{
    public class CartProductUpdateDto
    {
        public int cartProductId { get; set; }
        public int productId { get; set; }
        public int quantity { get; set; }
        public bool isDeleted { get; set; }
    }
}