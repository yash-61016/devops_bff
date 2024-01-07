using devops_bff.Models;
using devops_bff.Models.Dto.Create;
using devops_bff.Models.Dto.Update;

namespace devops_bff.Services.IServices
{
    public interface ICartService
    {
        Task<APIResponse> CreateCartAsync(CartCreateDto cart_C_DTO);
        Task<APIResponse> GetCartAsync(int userId);
        Task<APIResponse> UpdateCartAsync(CartUpdateDto cart_U_DTO);
        Task<APIResponse> DeleteCartAsync(int cartId);
    }
}
