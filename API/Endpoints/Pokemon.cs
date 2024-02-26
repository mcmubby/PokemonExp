using Application.Pokemons.Get;
using Application.Pokemons.GetByGeneration;
using Application.Pokemons.Exceptions;
using MediatR;
using Application.Pokemons.GetById;
using Application.Pokemons.GetByNumber;
using Application.Pokemons.Create;
using Application.Pokemons.Update;
using Application.Pokemons.Delete;
using Application.Pokemons.Responses;

namespace API.Endpoints
{
    internal static class Pokemon
    {
        internal static void MapPokemonEndpoint(this WebApplication app)
        {
            var group = app.MapGroup("api/v1/pokemons")
                           .WithTags("Pokemons");


            group.MapPost("/", async (CreatePokemonCommand command, ISender sender) =>
            {
                try
                {
                    await sender.Send(command);
                    return Results.Created();
                }
                catch (ExistingRecordException e)
                {
                    return Results.BadRequest(e.Message);
                }
            }).AddEndpointFilter<ValidationFilter<CreatePokemonCommand>>()
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status201Created)
            .WithOpenApi(o => new(o) { Summary = "Create a new pokemon" });


            group.MapGet("/", async (ISender sender, int page = 1, int pageSize = 20) =>
            {
                var response = await sender.Send(new GetPokemonsQuery(page, pageSize));
                return TypedResults.Ok(response);
            }).WithOpenApi(o => new(o){ Summary = "Get a paginated list of all pokemons available on the database" });


            group.MapGet("/generation/{generation:int}", async (ISender sender, int generation, int page = 1, int pageSize = 20) =>
            {
                try
                {
                    var response = await sender.Send(new GetByGenerationQuery(generation, page, pageSize));
                    return TypedResults.Ok(response);
                }
                catch (PokemonNotFoundException e)
                {
                    return Results.NotFound(e.Message);
                }
            }).Produces(StatusCodes.Status404NotFound)
            .Produces<PaginatedResult<PokemonResponse>>(StatusCodes.Status200OK)
            .WithOpenApi(o => new(o) { Summary = "Get all pokemons from a specific generation. Records for generation 1 to 6 available" });


            group.MapGet("/{id:int}", async (int id, ISender sender) =>
            {
                try
                {
                    var response = await sender.Send(new GetPokemonQuery(id));
                    return TypedResults.Ok(response);
                }
                catch (PokemonNotFoundException e)
                {
                    return Results.NotFound(e.Message);
                }
            }).Produces(StatusCodes.Status404NotFound)
            .Produces<PokemonResponse>(StatusCodes.Status200OK)
            .WithOpenApi(o => new(o) { Summary = "Get a pokemon using its system assigned id" });


            group.MapGet("number/{number:int}", async (int number, ISender sender) =>
            {
                try
                {
                    var response = await sender.Send(new GetPokemonsByNumberQuery(number));
                    return TypedResults.Ok(response);
                }
                catch (PokemonNotFoundException e)
                {
                    return Results.NotFound(e.Message);
                }
            }).Produces(StatusCodes.Status404NotFound)
            .Produces<List<PokemonResponse>>(StatusCodes.Status200OK)
            .WithOpenApi(o => new(o) { Summary = "Get pokemon(s) with the pokemon #" });


            group.MapPut("/", async (UpdatePokemonCommand command, ISender sender) =>
            {
                try
                {
                    await sender.Send(command);
                    return Results.Ok();
                }
                catch (PokemonNotFoundException e)
                {
                    return TypedResults.BadRequest(e.Message);
                }
            }).AddEndpointFilter<ValidationFilter<UpdatePokemonCommand>>()
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi(o => new(o) { Summary = "Update a pokemon using system assigned id as key. Full payload required." });


            group.MapDelete("/{id:int}", async (int id, ISender sender) =>
            {
                try
                {
                    await sender.Send(new DeletePokemonCommand(id));
                    return Results.Ok();
                }
                catch (PokemonNotFoundException e)
                {
                    return TypedResults.NotFound(e.Message);
                }
            }).Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi(o => new(o) { Summary = "Delete a pokemon using system assigned id as key." });
        }
    }
}
