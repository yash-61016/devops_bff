namespace devops_bff.Models.Dto.Update
{
    public class CartUpdateDto
    {
        public required CartOverviewUpdateDto cartOverview { get; set; }
        public required IEnumerable<CartProductUpdateDto> cartProducts { get; set; }
    }
}