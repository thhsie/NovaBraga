using Application.Products.Create;
using Application.Products.GetById;
using Ardalis.Result;
using Contracts.Products;
using MediatR;
using WebApi.Extensions;
using IResult = Microsoft.AspNetCore.Http.IResult;

namespace WebApi.Endpoints;

public static class ProductEndpoints
{
    public static void MapProductEndpoints(this WebApplication app)
    {
        app.MapPost("/products", CreateProduct)
            .WithName("CreateProduct")
            .WithOpenApi();

        app.MapGet("/products/{id}", GetProductById)
            .WithName("GetProductById")
            .WithOpenApi();
    }

    private static async Task<IResult> CreateProduct(
        CreateProductRequest request,
        ISender mediator,
        CancellationToken cancellationToken)
    {
        var command = new CreateProductCommand(request);
        var result = await mediator.Send(command, cancellationToken);

        return result.ToHttpResult();
    }

    private static async Task<IResult> GetProductById(
        Guid id,
        ISender mediator,
        CancellationToken cancellationToken)
    {
        var query = new GetProductByIdQuery(id);
        var result = await mediator.Send(query, cancellationToken);

        return result.ToHttpResult();
    }
}