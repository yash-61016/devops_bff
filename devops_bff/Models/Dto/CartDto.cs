using devops_bff.Models.Dto;

namespace devops_cart_service.Models.Dto
{
    public class CartDto
    {
        public required CartOverviewDto cartOverview { get; set; }
        public IEnumerable<CartProductDto>? cartProducts { get; set; }
    }
}