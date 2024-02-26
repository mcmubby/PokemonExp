using Application.Interfaces.Persistence;
using Application.Pokemons.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Pokemons.Update
{
    public class UpdatePokemonCommandHandler : IRequestHandler<UpdatePokemonCommand>
    {
        private readonly IAppDbContext _context;

        public UpdatePokemonCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdatePokemonCommand request, CancellationToken cancellationToken)
        {
            var pokemon = await _context.Pokemons.Where(p => p.Id == request.Id).FirstOrDefaultAsync() ?? throw new PokemonNotFoundException();

            pokemon.Id = request.Id;
            pokemon.Number = request.Number;
            pokemon.Name = request.Name;
            pokemon.Type1 = request.Type1;
            pokemon.Type2 = request.Type2;
            pokemon.Total = request.Total;
            pokemon.HP = request.HP;
            pokemon.Attack = request.Attack;
            pokemon.Defense = request.Defense;
            pokemon.SpecialAttack = request.SpecialAttack;
            pokemon.SpecialDefense = request.SpecialDefense;
            pokemon.Speed = request.Speed;
            pokemon.Generation = request.Generation;
            pokemon.Legendary = request.Legendary;

            _context.Pokemons.Update(pokemon);
            _context.SaveChanges();
        }
    }
}
