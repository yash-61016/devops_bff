using devops_bff.Models;
using devops_bff.Models.Dto.Create;
using devops_bff.Models.Dto.Update;
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
            .Produces(400);

            app.MapPost("/api/cart/create", CreateCart)
            .WithName("CreateCart")
            .Produces<APIResponse>(200)
            .Produces(400);

            app.MapPut("/api/cart/update", UpdateCart)
            .WithName("UpdateCart")
            .Produces<APIResponse>(200)
            .Produces(400);

            app.MapDelete("/api/cart/{cartId}", DeleteCart)
            .WithName("DeleteCart")
            .Produces<APIResponse>(200)
            .Produces(400);
        }

        private static async Task<IResult> DeleteCart(
            ICartService _cartService,
            [FromRoute] int cartId)
        {
            var result = await _cartService.DeleteCartAsync(cartId);
            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }

        private async static Task<IResult> UpdateCart(
            ICartService _cartService,
            [FromBody] CartUpdateDto cart_U_DTO
        )
        {
            var result = await _cartService.UpdateCartAsync(cart_U_DTO);
            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }

        private async static Task<IResult> GetCart(
            ICartService _cartService,
            [FromRoute] int userId)
        {
            var result = await _cartService.GetCartAsync(userId);
            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }

        private async static Task<IResult> CreateCart(
            ICartService _cartService,
            [FromBody] CartCreateDto cart_C_DTO)
        {
            var result = await _cartService.CreateCartAsync(cart_C_DTO);
            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }

    }
}