using devops_bff.Models;
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
        }

        private async static Task<IResult> GetCart(
            ICartService _cartService,
            [FromRoute] int userId)
        {
            var result = await _cartService.GetCartAsync(userId);
            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}