using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using VaabenbogenProvider.Data;
using VaabenbogenProvider.Models;
namespace VaabenbogenProvider.Controllers;

public static class JaegerEndpoints
{
    public static void MapJaegerEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Jaeger").WithTags(nameof(Jaeger));

        group.MapGet("/", async (VaabenBogenContext db) =>
        {
            return await db.Jaegere.ToListAsync();
        })
        .WithName("GetAllJaegers")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Jaeger>, NotFound>> (int id, VaabenBogenContext db) =>
        {
            return await db.Jaegere.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is Jaeger model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetJaegerById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, Jaeger jaeger, VaabenBogenContext db) =>
        {
            var affected = await db.Jaegere
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Id, jaeger.Id)
                    .SetProperty(m => m.Fornavn, jaeger.Fornavn)
                    .SetProperty(m => m.Efternavn, jaeger.Efternavn)
                    .SetProperty(m => m.Foedselsdato, jaeger.Foedselsdato)
                    .SetProperty(m => m.JaegerId, jaeger.JaegerId)
                    .SetProperty(m => m.Telefon, jaeger.Telefon)
                    .SetProperty(m => m.Mobil, jaeger.Mobil)
                    .SetProperty(m => m.Email, jaeger.Email)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateJaeger")
        .WithOpenApi();

        group.MapPost("/", async (Jaeger jaeger, VaabenBogenContext db) =>
        {
            db.Jaegere.Add(jaeger);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Jaeger/{jaeger.Id}",jaeger);
        })
        .WithName("CreateJaeger")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, VaabenBogenContext db) =>
        {
            var affected = await db.Jaegere
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteJaeger")
        .WithOpenApi();
    }
}
