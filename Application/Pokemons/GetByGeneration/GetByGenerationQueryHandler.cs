using Application.Interfaces.Persistence;
using Application.Pokemons.Exceptions;
using Application.Pokemons.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Pokemons.GetByGeneration
{
    public class GetByGenerationQueryHandler : IRequestHandler<GetByGenerationQuery, PaginatedResult<PokemonResponse>>
    {
        private readonly IAppDbContext _context;

        public GetByGenerationQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<PaginatedResult<PokemonResponse>> Handle(GetByGenerationQuery request, CancellationToken cancellationToken)
        {
            var pokemonQuery = _context.Pokemons.Where(p => p.Generation == request.Generation).AsNoTracking().Select(p => new PokemonResponse
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

            return !pokemonQuery.Any() ? throw new PokemonNotFoundException() : await PaginatedResult<PokemonResponse>.CreateAsync(pokemonQuery, request.Page, request.PageSize);
        }
    }
}
