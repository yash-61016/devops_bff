namespace devops_bff.Models.Dto.Create
{
    public class CartOverviewCreateDto
    {
        public int userId { get; set; }
        public decimal discount { get; set; }
        public decimal totalPrice { get; set; }
    }
}