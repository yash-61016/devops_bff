
using devops_bff.DTOs.Cart.Create;
using devops_bff.DTOs.Cart.Update;
using devops_bff.Models;
using devops_bff.Services;
using devops_bff.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace devops_bff.Endpoints
{
    public static class BffEndpoints
    {
        public static void ConfigureBffEndpoints(this WebApplication app)
        {
            app.MapGet("/api/cart/user-{userId}", GetCart)
            .WithName("GetCart")
            .Produces<APIResponse>(200)
            .Produces(400)
            .RequireAuthorization();

            app.MapPost("/api/cart/create", CreateCart)
            .WithName("CreateCart")
            .Produces<APIResponse>(200)
            .Produces(400)
            .RequireAuthorization();

            app.MapPut("/api/cart/update", UpdateCart)
            .WithName("UpdateCart")
            .Produces<APIResponse>(200)
            .Produces(400)
            .RequireAuthorization();

            app.MapDelete("/api/card/{cartId}", DeleteCart)
            .WithName("DeleteCart")
            .Produces<APIResponse>(200)
            .Produces(400)
            .RequireAuthorization();

            app.MapGet("/api/product/categories", GetProductCategories)
            .WithName("GetProductCategories")
            .Produces<APIResponse>(200)
            .Produces(400)
            .RequireAuthorization();

            app.MapGet("/api/products/{categoryId}", GetProductsByCategory)
            .WithName("GetProducts")
            .Produces<APIResponse>(200)
            .Produces(400)
            .RequireAuthorization();

            app.MapGet("/api/featured-product/{categoryId}", GetFeaturedProduct)
            .WithName("GetFeaturedProduct")
            .Produces<APIResponse>(200)
            .Produces(400)
            .RequireAuthorization();
        }

        private static async Task<IResult> DeleteCart(
            ICartService _cartService,
            ITokenService _tokenService,
            [FromRoute] int cartId)
        {
            var accessToken = await _tokenService.GetTokenAsync("Auth:Audience_Cart", "Auth:ClientId_Cart");
            var result = await _cartService.DeleteCartAsync(cartId, accessToken);
            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }

        private async static Task<IResult> UpdateCart(
            ICartService _cartService,
            ITokenService _tokenService,
            [FromBody] CartUpdateDto cart_U_DTO
        )
        {
            var accessToken = await _tokenService.GetTokenAsync("Auth:Audience_Cart", "Auth:ClientId_Cart");
            var result = await _cartService.UpdateCartAsync(cart_U_DTO, accessToken);
            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }

        private async static Task<IResult> GetCart(
            ICartService _cartService,
            ITokenService _tokenService,
            [FromRoute] int userId)
        {
            var accessToken = await _tokenService.GetTokenAsync("Auth:Audience_Cart", "Auth:ClientId_Cart");
            var result = await _cartService.GetCartAsync(userId, accessToken);
            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }

        private async static Task<IResult> CreateCart(
            ICartService _cartService,
            ITokenService _tokenService,
            [FromBody] CartCreateDto cart_C_DTO)
        {
            var accessToken = await _tokenService.GetTokenAsync("Auth:Audience_Cart", "Auth:ClientId_Cart");
            var result = await _cartService.CreateCartAsync(cart_C_DTO, accessToken);
            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }

        private async static Task<IResult> GetProductCategories(
            IProductService _productService)
        {
            var result = await _productService.GetProductCategoriesAsync();
            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }

        private async static Task<IResult> GetProductsByCategory(
            IProductService _productService,
            [FromRoute] int categoryId)
        {
            var result = await _productService.GetProductsAsync(categoryId);
            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }

        private async static Task<IResult> GetFeaturedProduct(
            IProductService _productService,
            [FromRoute] int categoryId)
        {
            var result = await _productService.GetFeaturedProductAsync(categoryId);
            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}