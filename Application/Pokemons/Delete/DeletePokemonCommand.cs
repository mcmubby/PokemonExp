using MediatR;

namespace Application.Pokemons.Delete
{
    public record DeletePokemonCommand(int Id) : IRequest;
}
