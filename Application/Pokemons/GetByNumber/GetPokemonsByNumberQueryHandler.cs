using Application.Interfaces.Persistence;
using Application.Pokemons.Exceptions;
using Application.Pokemons.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Pokemons.GetByNumber
{
    public class GetPokemonsByNumberQueryHandler : IRequestHandler<GetPokemonsByNumberQuery, List<PokemonResponse>>
    {
        private readonly IAppDbContext _context;

        public GetPokemonsByNumberQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<PokemonResponse>> Handle(GetPokemonsByNumberQuery request, CancellationToken cancellationToken)
        {
            var pokemon = _context.Pokemons.Where(p => p.Number == request.number).AsNoTracking().Select(p => new PokemonResponse
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
            });

            return !pokemon.Any() ? throw new PokemonNotFoundException() : await pokemon.ToListAsync();
        }
    }
}
