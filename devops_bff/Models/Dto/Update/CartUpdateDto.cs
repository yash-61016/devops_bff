namespace devops_bff.Models.Dto.Update
{
    public class CartUpdateDto
    {
        public required CartOverviewUpdateDto CartOverview { get; set; }
        public required IEnumerable<CartProductUpdateDto> CartProducts { get; set; }
    }
}