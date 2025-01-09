using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using VaabenbogenProvider.Data;
using VaabenbogenProvider.Models;
namespace VaabenbogenProvider.Controllers;

public static class VirksomhedEndpoints
{
    public static void MapVirksomhedEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Virksomhed").WithTags(nameof(Virksomhed));

        group.MapGet("/", async (VaabenBogenContext db) =>
        {
            return await db.Virksomheder.ToListAsync();
        })
        .WithName("GetAllVirksomheds")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Virksomhed>, NotFound>> (int id, VaabenBogenContext db) =>
        {
            return await db.Virksomheder.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is Virksomhed model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetVirksomhedById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, Virksomhed virksomhed, VaabenBogenContext db) =>
        {
            var affected = await db.Virksomheder
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Id, virksomhed.Id)
                    .SetProperty(m => m.Cvr, virksomhed.Cvr)
                    .SetProperty(m => m.Navn, virksomhed.Navn)
                    .SetProperty(m => m.Adresse, virksomhed.Adresse)
                    .SetProperty(m => m.ZipCode, virksomhed.ZipCode)
                    .SetProperty(m => m.By, virksomhed.By)
                    .SetProperty(m => m.Telefon, virksomhed.Telefon)
                    .SetProperty(m => m.Email, virksomhed.Email)
                    .SetProperty(m => m.StartDato, virksomhed.StartDato)
                    .SetProperty(m => m.EndDato, virksomhed.EndDato)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateVirksomhed")
        .WithOpenApi();

        group.MapPost("/", async (Virksomhed virksomhed, VaabenBogenContext db) =>
        {
            db.Virksomheder.Add(virksomhed);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Virksomhed/{virksomhed.Id}",virksomhed);
        })
        .WithName("CreateVirksomhed")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, VaabenBogenContext db) =>
        {
            var affected = await db.Virksomheder
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteVirksomhed")
        .WithOpenApi();
    }
}
