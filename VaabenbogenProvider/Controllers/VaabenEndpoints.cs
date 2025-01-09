using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using VaabenbogenProvider.Data;
using VaabenbogenProvider.Models;
namespace VaabenbogenProvider.Controllers;

public static class VaabenEndpoints
{
    public static void MapVaabenEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Vaaben").WithTags(nameof(Vaaben));

        group.MapGet("/", async (VaabenBogenContext db) =>
        {
            return await db.Vaaben.ToListAsync();
        })
        .WithName("GetAllVaabens")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Vaaben>, NotFound>> (int id, VaabenBogenContext db) =>
        {
            return await db.Vaaben.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is Vaaben model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetVaabenById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, Vaaben vaaben, VaabenBogenContext db) =>
        {
            var affected = await db.Vaaben
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Id, vaaben.Id)
                    .SetProperty(m => m.Navn, vaaben.Navn)
                    .SetProperty(m => m.Fabrikat, vaaben.Fabrikat)
                    .SetProperty(m => m.Ladefunktion, vaaben.Ladefunktion)
                    .SetProperty(m => m.Loebenummer, vaaben.Loebenummer)
                    .SetProperty(m => m.Type, vaaben.Type)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateVaaben")
        .WithOpenApi();

        group.MapPost("/", async (Vaaben vaaben, VaabenBogenContext db) =>
        {
            db.Vaaben.Add(vaaben);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Vaaben/{vaaben.Id}",vaaben);
        })
        .WithName("CreateVaaben")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, VaabenBogenContext db) =>
        {
            var affected = await db.Vaaben
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteVaaben")
        .WithOpenApi();
    }
}
