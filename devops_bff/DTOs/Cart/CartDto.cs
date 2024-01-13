

namespace devops_bff.DTOs.Cart
{
    public class CartDto
    {
        public required CartOverviewDto cartOverview { get; set; }
        public IEnumerable<CartProductDto>? cartProducts { get; set; }
    }
}