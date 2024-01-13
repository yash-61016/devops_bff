using System;
using System.Net;
using devops_bff.Models;
using devops_bff.Services.IServices;

using System.Text.Json;
using devops_bff.DTOs.Cart.Create;
using devops_bff.DTOs.Cart;
using devops_bff.DTOs.Cart.Update;

namespace devops_bff.Services
{
    public class CartService : ICartService
    {
        private readonly HttpClient _client;
        private readonly ILogger<CartService> _logger;
        public CartService(HttpClient client, ILogger<CartService> logger)
        {
            client.BaseAddress = new Uri("http://localhost:7020/");
            client.Timeout = TimeSpan.FromSeconds(5);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client = client;
            _logger = logger;
        }

        public async Task<APIResponse> CreateCartAsync(CartCreateDto cart_C_DTO)
        {
            var apiResponse = new APIResponse();
            try
            {
                var response = await _client.PostAsJsonAsync("/cart/create", cart_C_DTO);

                if (response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.BadRequest)
                {
                    _logger.LogError("Bad request when creating cart for user ID {UserId}", cart_C_DTO.cartOverview.userId);

                    apiResponse.IsSuccess = false;
                    apiResponse.StatusCode = response.StatusCode;
                    apiResponse.ErrorMessages.Add("Bad request when creating cart");
                    return apiResponse;
                }

                response.EnsureSuccessStatusCode();
                var cartServiceApiResponse = await response.Content.ReadFromJsonAsync<APIResponse>();

                if (cartServiceApiResponse != null && cartServiceApiResponse.IsSuccess)
                {
                    var _cartDto = JsonSerializer.Deserialize<CartDto>(JsonSerializer.Serialize(cartServiceApiResponse.Result));

                    if (_cartDto != null)
                    {
                        apiResponse.IsSuccess = true;
                        apiResponse.StatusCode = HttpStatusCode.OK;
                        apiResponse.Result = cartServiceApiResponse.Result;
                        return apiResponse;
                    }
                    else
                    {
                        apiResponse.IsSuccess = false;
                        apiResponse.StatusCode = HttpStatusCode.InternalServerError;
                        apiResponse.ErrorMessages.Add("Error creating cart");
                        return apiResponse;
                    }
                }
                else
                {
                    apiResponse.IsSuccess = false;
                    apiResponse.StatusCode = cartServiceApiResponse?.StatusCode ?? HttpStatusCode.InternalServerError;
                    apiResponse.ErrorMessages.Add("Error creating cart");

                    _logger.LogError("Error creating cart for user ID {UserId}. Status code: {StatusCode}, Error messages: {ErrorMessages}",
                                     cart_C_DTO.cartOverview.userId, apiResponse.StatusCode, string.Join(", ", apiResponse.ErrorMessages));
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected exception occurred: {Message}", ex.Message);

                apiResponse.IsSuccess = false;
                apiResponse.StatusCode = HttpStatusCode.InternalServerError;
                apiResponse.ErrorMessages.Add($"An unexpected error occurred: {ex.Message}");
            }

            return apiResponse;
        }

        public async Task<APIResponse> DeleteCartAsync(int cartId)
        {
            var apiResponse = new APIResponse();

            try
            {
                var response = await _client.DeleteAsync($"cart/{cartId}");

                if (response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.BadRequest)
                {
                    _logger.LogError("Cart not found for cart ID {CartId}", cartId);

                    apiResponse.IsSuccess = false;
                    apiResponse.StatusCode = response.StatusCode;
                    apiResponse.ErrorMessages.Add("Cart not found");
                    return apiResponse;
                }

                response.EnsureSuccessStatusCode();

                if (response.StatusCode == HttpStatusCode.NoContent || response.StatusCode == HttpStatusCode.OK)
                {
                    apiResponse.IsSuccess = true;
                    apiResponse.StatusCode = HttpStatusCode.NoContent;
                }
                else
                {
                    apiResponse.IsSuccess = false;
                    apiResponse.StatusCode = HttpStatusCode.InternalServerError;
                    apiResponse.ErrorMessages.Add("Error deleting cart");

                    _logger.LogError("Error deleting cart for cart ID {CartId}. Status code: {StatusCode}, Error messages: {ErrorMessages}",
                                     cartId, apiResponse.StatusCode, string.Join(", ", apiResponse.ErrorMessages));
                }
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "HttpRequestException occurred: {Message}", ex.Message);

                apiResponse.IsSuccess = false;
                apiResponse.StatusCode = HttpStatusCode.InternalServerError;
                apiResponse.ErrorMessages.Add($"An error occurred: {ex.Message}");
            }
            catch (JsonException ex)
            {
                _logger.LogError(ex, "JsonException occurred: {Message}", ex.Message);

                apiResponse.IsSuccess = false;
                apiResponse.StatusCode = HttpStatusCode.InternalServerError;
                apiResponse.ErrorMessages.Add($"An error occurred: {ex.Message}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected exception occurred: {Message}", ex.Message);

                apiResponse.IsSuccess = false;
                apiResponse.StatusCode = HttpStatusCode.InternalServerError;
                apiResponse.ErrorMessages.Add($"An unexpected error occurred: {ex.Message}");
            }

            return apiResponse;
        }

        public async Task<APIResponse> GetCartAsync(int userId)
        {
            var apiResponse = new APIResponse();

            try
            {
                var response = await _client.GetAsync($"cart/user-{userId}");

                if (response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.BadRequest)
                {
                    _logger.LogError("Cart not found for user ID {UserId}", userId);

                    apiResponse.IsSuccess = false;
                    apiResponse.StatusCode = response.StatusCode;
                    apiResponse.ErrorMessages.Add("Cart not found");
                    return apiResponse;
                }

                response.EnsureSuccessStatusCode();
                var cartServiceApiResponse = await response.Content.ReadFromJsonAsync<APIResponse>();

                if (cartServiceApiResponse != null && cartServiceApiResponse.IsSuccess)
                {
                    var _cartDto = JsonSerializer.Deserialize<CartDto>(JsonSerializer.Serialize(cartServiceApiResponse.Result));

                    if (_cartDto != null)
                    {
                        apiResponse.IsSuccess = true;
                        apiResponse.StatusCode = HttpStatusCode.OK;
                        apiResponse.Result = cartServiceApiResponse.Result;
                        return apiResponse;
                    }
                    else
                    {
                        apiResponse.IsSuccess = false;
                        apiResponse.StatusCode = HttpStatusCode.InternalServerError;
                        apiResponse.ErrorMessages.Add("Error retrieving cart");
                        return apiResponse;
                    }
                }
                else
                {
                    apiResponse.IsSuccess = false;
                    apiResponse.StatusCode = cartServiceApiResponse?.StatusCode ?? HttpStatusCode.InternalServerError;
                    apiResponse.ErrorMessages.Add("Error retrieving cart");

                    _logger.LogError("Error retrieving cart for user ID {UserId}. Status code: {StatusCode}, Error messages: {ErrorMessages}",
                                     userId, apiResponse.StatusCode, string.Join(", ", apiResponse.ErrorMessages));
                }
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "HttpRequestException occurred: {Message}", ex.Message);

                apiResponse.IsSuccess = false;
                apiResponse.StatusCode = HttpStatusCode.InternalServerError;
                apiResponse.ErrorMessages.Add($"An error occurred: {ex.Message}");
            }
            catch (JsonException ex)
            {
                _logger.LogError(ex, "JsonException occurred: {Message}", ex.Message);

                apiResponse.IsSuccess = false;
                apiResponse.StatusCode = HttpStatusCode.InternalServerError;
                apiResponse.ErrorMessages.Add($"An error occurred: {ex.Message}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected exception occurred: {Message}", ex.Message);

                apiResponse.IsSuccess = false;
                apiResponse.StatusCode = HttpStatusCode.InternalServerError;
                apiResponse.ErrorMessages.Add($"An unexpected error occurred: {ex.Message}");
            }

            return apiResponse;
        }

        public async Task<APIResponse> UpdateCartAsync(CartUpdateDto cart_U_DTO)
        {
            var apiResponse = new APIResponse();
            try
            {
                var response = await _client.PutAsJsonAsync("/cart/update", cart_U_DTO);

                if (response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.BadRequest)
                {
                    _logger.LogError("Bad request when updating cart for user ID {UserId}", cart_U_DTO.cartOverview.userId);

                    apiResponse.IsSuccess = false;
                    apiResponse.StatusCode = response.StatusCode;
                    apiResponse.ErrorMessages.Add("Bad request when updating cart");
                    return apiResponse;
                }

                response.EnsureSuccessStatusCode();
                var cartServiceApiResponse = await response.Content.ReadFromJsonAsync<APIResponse>();

                if (cartServiceApiResponse != null && cartServiceApiResponse.IsSuccess)
                {
                    var _cartDto = JsonSerializer.Deserialize<CartDto>(JsonSerializer.Serialize(cartServiceApiResponse.Result));

                    if (_cartDto != null)
                    {
                        apiResponse.IsSuccess = true;
                        apiResponse.StatusCode = HttpStatusCode.OK;
                        apiResponse.Result = cartServiceApiResponse.Result;
                        return apiResponse;
                    }
                    else
                    {
                        apiResponse.IsSuccess = false;
                        apiResponse.StatusCode = HttpStatusCode.InternalServerError;
                        apiResponse.ErrorMessages.Add("Error updating cart");
                        return apiResponse;
                    }
                }
                else
                {
                    apiResponse.IsSuccess = false;
                    apiResponse.StatusCode = cartServiceApiResponse?.StatusCode ?? HttpStatusCode.InternalServerError;
                    apiResponse.ErrorMessages.Add("Error updating cart");

                    _logger.LogError("Error updating cart for user ID {UserId}. Status code: {StatusCode}, Error messages: {ErrorMessages}",
                                     cart_U_DTO.cartOverview.userId, apiResponse.StatusCode, string.Join(", ", apiResponse.ErrorMessages));
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected exception occurred: {Message}", ex.Message);

                apiResponse.IsSuccess = false;
                apiResponse.StatusCode = HttpStatusCode.InternalServerError;
                apiResponse.ErrorMessages.Add($"An unexpected error occurred: {ex.Message}");
            }

            return apiResponse;
        }
    }
}