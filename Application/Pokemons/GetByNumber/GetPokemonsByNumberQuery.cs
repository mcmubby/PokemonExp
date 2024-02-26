using Application.Pokemons.Responses;
using MediatR;

namespace Application.Pokemons.GetByNumber
{
    public record GetPokemonsByNumberQuery(int number) : IRequest<List<PokemonResponse>>;
}
