using Application.Interfaces.Persistence;
using Application.Pokemons.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Pokemons.Get
{
    public class GetPokemonsQueryHandler : IRequestHandler<GetPokemonsQuery, PaginatedResult<PokemonResponse>>
    {
        private readonly IAppDbContext _context;

        public GetPokemonsQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<PaginatedResult<PokemonResponse>> Handle(GetPokemonsQuery request, CancellationToken cancellationToken)
        {
            var pokemonQuery = _context.Pokemons.AsNoTracking().Select(p => new PokemonResponse
            {
                Id = p.Id,
                Number = p.Number,
                Name = p.Name,
                Type1 = p.Type1,
                Type2 = p.Type2,
                Total = p.Total,
                HP = p.HP,
                Attack = p.Attack,
                Defense = p.Defense,
                SpecialAttack = p.SpecialAttack,
                SpecialDefense = p.SpecialDefense,
                Speed = p.Speed,
                Generation = p.Generation,
                Legendary = p.Legendary,
            }).OrderBy(p => p.Id);

            var pokemons = await PaginatedResult<PokemonResponse>.CreateAsync(pokemonQuery, request.Page, request.PageSize);

            return pokemons;
        }
    }
}
