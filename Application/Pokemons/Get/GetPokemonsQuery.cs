using Application.Pokemons.Responses;
using MediatR;

namespace Application.Pokemons.Get
{
    public record GetPokemonsQuery(int Page, int PageSize) : IRequest<PaginatedResult<PokemonResponse>>;
}
