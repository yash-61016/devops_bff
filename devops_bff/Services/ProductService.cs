using System.Net;
using System.Text.Json;
using devops_bff.DTOs.Product;
using devops_bff.Models;
using devops_bff.Services.IServices;

namespace devops_bff.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _client;
        private readonly ILogger<CartService> _logger;

        public ProductService(HttpClient client, ILogger<CartService> logger)
        {
            client.BaseAddress = new Uri("http://localhost:7030/");
            client.Timeout = TimeSpan.FromSeconds(5);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client = client;
            _logger = logger;
        }

        public async Task<APIResponse> GetProductByIdAsync(int productId)
        {
            var apiResponse = new APIResponse();
            try
            {
                var response = await _client.GetAsync($"api/product/{productId}");

                if (response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.BadRequest)
                {
                    _logger.LogError("product can not be found for ID {ProductId}", productId);

                    apiResponse.IsSuccess = false;
                    apiResponse.StatusCode = response.StatusCode;
                    apiResponse.ErrorMessages.Add("Product not found");
                    return apiResponse;
                }

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError("Error occurred while fetching product for ID {ProductId}", productId);

                    apiResponse.IsSuccess = false;
                    apiResponse.StatusCode = response.StatusCode;
                    apiResponse.ErrorMessages.Add("Error occurred while fetching product");
                    return apiResponse;
                }

                var content = await response.Content.ReadAsStringAsync();
                var product = JsonSerializer.Deserialize<ProductDTO>(content);

                apiResponse.Result = product;
                apiResponse.IsSuccess = true;
                apiResponse.StatusCode = response.StatusCode;


            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching product");
                apiResponse.IsSuccess = false;
                apiResponse.StatusCode = HttpStatusCode.InternalServerError;
                apiResponse.ErrorMessages.Add($"An unexpected error occurred: {ex.Message}");
            }

            return apiResponse;
        }

        public async Task<APIResponse> GetProductCategoriesAsync()
        {
            var apiResponse = new APIResponse();
            try
            {
                var response = await _client.GetAsync($"api/product/category");

                if (response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.BadRequest)
                {
                    _logger.LogError("product categories can not be found");

                    apiResponse.IsSuccess = false;
                    apiResponse.StatusCode = response.StatusCode;
                    apiResponse.ErrorMessages.Add("Product categories not found");
                    return apiResponse;
                }

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError("Error occurred while fetching product categories");

                    apiResponse.IsSuccess = false;
                    apiResponse.StatusCode = response.StatusCode;
                    apiResponse.ErrorMessages.Add("Error occurred while fetching product categories");
                    return apiResponse;
                }

                var content = await response.Content.ReadAsStringAsync();
                var productCategories = JsonSerializer.Deserialize<ProductCategoryDTO[]>(content);

                apiResponse.Result = productCategories;
                apiResponse.IsSuccess = true;
                apiResponse.StatusCode = response.StatusCode;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching product categories");
                apiResponse.IsSuccess = false;
                apiResponse.StatusCode = HttpStatusCode.InternalServerError;
                apiResponse.ErrorMessages.Add($"An unexpected error occurred: {ex.Message}");
            }

            return apiResponse;
        }

        public async Task<APIResponse> GetProductsAsync(int categoryId)
        {
            var apiResponse = new APIResponse();
            try
            {
                var response = await _client.GetAsync($"api/product/{categoryId}");

                if (response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.BadRequest)
                {
                    _logger.LogError("products can not be found");

                    apiResponse.IsSuccess = false;
                    apiResponse.StatusCode = response.StatusCode;
                    apiResponse.ErrorMessages.Add("Products not found");
                    return apiResponse;
                }

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError("Error occurred while fetching products");

                    apiResponse.IsSuccess = false;
                    apiResponse.StatusCode = response.StatusCode;
                    apiResponse.ErrorMessages.Add("Error occurred while fetching products");
                    return apiResponse;
                }

                var content = await response.Content.ReadAsStringAsync();
                var products = JsonSerializer.Deserialize<ProductDTO[]>(content);

                apiResponse.Result = products;
                apiResponse.IsSuccess = true;
                apiResponse.StatusCode = response.StatusCode;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching products");
                apiResponse.IsSuccess = false;
                apiResponse.StatusCode = HttpStatusCode.InternalServerError;
                apiResponse.ErrorMessages.Add($"An unexpected error occurred: {ex.Message}");
            }

            return apiResponse;
        }

        public async Task<APIResponse> GetFeaturedProductAsync(int categoryId)
        {
            var apiResponse = new APIResponse();
            try
            {
                var response = await _client.GetAsync($"api/product/featured/{categoryId}");

                if (response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.BadRequest)
                {
                    _logger.LogError("featured product can not be found");

                    apiResponse.IsSuccess = false;
                    apiResponse.StatusCode = response.StatusCode;
                    apiResponse.ErrorMessages.Add("Featured product not found");
                    return apiResponse;
                }

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError("Error occurred while fetching featured product");

                    apiResponse.IsSuccess = false;
                    apiResponse.StatusCode = response.StatusCode;
                    apiResponse.ErrorMessages.Add("Error occurred while fetching featured product");
                    return apiResponse;
                }

                var content = await response.Content.ReadAsStringAsync();
                var featuredProduct = JsonSerializer.Deserialize<ProductDTO>(content);

                apiResponse.Result = featuredProduct;
                apiResponse.IsSuccess = true;
                apiResponse.StatusCode = response.StatusCode;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching featured product");
                apiResponse.IsSuccess = false;
                apiResponse.StatusCode = HttpStatusCode.InternalServerError;
                apiResponse.ErrorMessages.Add($"An unexpected error occurred: {ex.Message}");
            }

            return apiResponse;
        }
    }

}