namespace devops_bff.Models.Dto.Update
{
    public class CartOverviewUpdateDto
    {
        public int cartId { get; set; }
        public int userId { get; set; }
        public decimal discount { get; set; }
        public decimal totalPrice { get; set; }
        public bool isCheckedOut { get; set; }
    }
}