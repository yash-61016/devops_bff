using devops_bff.Models;

namespace devops_bff.Services.IServices
{
    public interface IProductService
    {
        Task<APIResponse> GetProductsAsync(int categoryId);
        Task<APIResponse> GetProductByIdAsync(int productId);
        Task<APIResponse> GetProductCategoriesAsync();
        Task<APIResponse> GetFeaturedProductAsync(int categoryId);
    }
}