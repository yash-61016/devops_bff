namespace devops_bff.Models.Dto.Create
{
    public class CartCreateDto
    {
        public required CartOverviewCreateDto cartOverview { get; set; }
        public required List<CartProductCreateDto> cartProducts { get; set; }
    }
}