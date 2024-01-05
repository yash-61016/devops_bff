using System;
using System.Net;
using devops_bff.Models;
using devops_bff.Services.IServices;
using devops_cart_service.Models.Dto;

namespace devops_bff.Services
{
    public class CartService : ICartService
    {
        private readonly HttpClient _client;
        public CartService(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri("http://localhost:5002/api/");
        }

        public Task<APIResponse> CreateCartAsync(CartCreateDto cart_C_DTO)
        {
            throw new NotImplementedException();
        }

        public Task<APIResponse> DeleteCartAsync(int cartId)
        {
            throw new NotImplementedException();
        }

        public async Task<APIResponse> GetCartAsync(int userId)
        {
            var apiResponse = new APIResponse();
            var response = await _client.GetAsync($"cart/{userId}");
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                apiResponse.IsSuccess = false;
                apiResponse.StatusCode = HttpStatusCode.NotFound;
                apiResponse.ErrorMessages.Add("Cart not found");
                return apiResponse;
            }
            response.EnsureSuccessStatusCode();
            var cart = await response.Content.ReadFromJsonAsync<APIResponse>();
            apiResponse.IsSuccess = true;
            apiResponse.StatusCode = HttpStatusCode.OK;
            apiResponse.Result = cart;
            return apiResponse;
        }

        public Task<APIResponse> UpdateCartAsync(CartUpdateDto cart_U_DTO)
        {
            throw new NotImplementedException();
        }
    }
}