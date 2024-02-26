using Application.Interfaces.Persistence;
using Application.Pokemons.Exceptions;
using Application.Pokemons.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Pokemons.GetById
{
    public class GetPokemonQueryHandler : IRequestHandler<GetPokemonQuery, PokemonResponse>
    {
        private readonly IAppDbContext _context;

        public GetPokemonQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<PokemonResponse> Handle(GetPokemonQuery request, CancellationToken cancellationToken)
        {
            var pokemon = await _context.Pokemons.Where(p => p.Id == request.Id).AsNoTracking().Select(p => new PokemonResponse
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
            }).FirstOrDefaultAsync(cancellationToken);

            return pokemon is  null ? throw new PokemonNotFoundException() : pokemon;
        }
    }
}
