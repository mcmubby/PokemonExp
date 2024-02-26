using Application.Pokemons.Responses;
using MediatR;

namespace Application.Pokemons.GetById
{
    public record GetPokemonQuery(int Id) : IRequest<PokemonResponse>;
}
