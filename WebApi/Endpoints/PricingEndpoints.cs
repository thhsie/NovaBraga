using Application.Pricing.Create;
using Application.Pricing.GetByProductId;
using Ardalis.Result;
using Contracts.Pricing;
using MediatR;
using WebApi.Extensions;
using IResult = Microsoft.AspNetCore.Http.IResult;

namespace WebApi.Endpoints;

public static class PricingEndpoints
{
    public static void MapPricingEndpoints(this WebApplication app)
    {
        app.MapPost("/pricing", CreatePricing)
            .WithName("CreatePricing")
            .WithOpenApi();

        app.MapGet("/pricing/{productId}", GetPricingByProductId)
            .WithName("GetPricingByProductId")
            .WithOpenApi();
    }

    private static async Task<IResult> CreatePricing(
        CreatePricingRequest request,
        ISender mediator,
        CancellationToken cancellationToken)
    {
        var command = new CreatePricingCommand(request);
        var result = await mediator.Send(command, cancellationToken);

        return result.ToHttpResult();
    }

    private static async Task<IResult> GetPricingByProductId(
        Guid productId,
        ISender mediator,
        CancellationToken cancellationToken)
    {
        var query = new GetPricingByProductIdQuery(productId);
        var result = await mediator.Send(query, cancellationToken);

        return result.ToHttpResult();
    }
}