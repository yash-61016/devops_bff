namespace devops_bff.Models.Dto.Update
{
    public class CartProductUpdateDto
    {
        public int CartProductId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public bool IsDeleted { get; set; }
    }
}