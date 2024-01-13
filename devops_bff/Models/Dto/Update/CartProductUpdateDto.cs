namespace devops_bff.Models.Dto.Update
{
    public class CartProductUpdateDto
    {
        public int cartProductId { get; set; }
        public int productId { get; set; }
        public int quantity { get; set; }
        public bool isDeleted { get; set; }
    }
}