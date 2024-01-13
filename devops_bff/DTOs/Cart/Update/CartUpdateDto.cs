namespace devops_bff.DTOs.Cart.Update
{
    public class CartUpdateDto
    {
        public required CartOverviewUpdateDto cartOverview { get; set; }
        public required IEnumerable<CartProductUpdateDto> cartProducts { get; set; }
    }
}