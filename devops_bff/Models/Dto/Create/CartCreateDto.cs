namespace devops_bff.Models.Dto.Create
{
    public class CartCreateDto
    {
        public required CartOverviewCreateDto CartOverview { get; set; }
        public required List<CartProductCreateDto> CartProducts { get; set; }
    }
}