using Application.Pokemons.Responses;
using MediatR;

namespace Application.Pokemons.GetByGeneration
{
    public record GetByGenerationQuery(int Generation, int Page, int PageSize) : IRequest<PaginatedResult<PokemonResponse>>;
}
