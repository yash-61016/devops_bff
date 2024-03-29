using devops_bff.DTOs.Cart.Create;
using devops_bff.DTOs.Cart.Update;
using devops_bff.Models;

namespace devops_bff.Services.IServices
{
    public interface ICartService
    {
        Task<APIResponse> CreateCartAsync(CartCreateDto cart_C_DTO, string token);
        Task<APIResponse> GetCartAsync(int userId, string token);
        Task<APIResponse> UpdateCartAsync(CartUpdateDto cart_U_DTO, string token);
        Task<APIResponse> DeleteCartAsync(int cartId, string token);
    }
}
