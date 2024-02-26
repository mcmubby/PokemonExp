using Application.Interfaces.Persistence;
using Application.Pokemons.Exceptions;
using Domain.Pokemons;
using MediatR;

namespace Application.Pokemons.Create
{
    public class CreatePokemonCommandHandler : IRequestHandler<CreatePokemonCommand>
    {
        private readonly IAppDbContext _context;

        public CreatePokemonCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public Task Handle(CreatePokemonCommand request, CancellationToken cancellationToken)
        {
            if(_context.Pokemons.Any(p => p.Name == request.Name && p.Number == request.Number)) { throw new ExistingRecordException(); }

            var pokemon = new Pokemon
            {
                Number = request.Number,
                Name = request.Name,
                Type1 = request.Type1,
                Type2 = request.Type2,
                Total = request.Total,
                HP = request.HP,
                Attack = request.Attack,
                Defense = request.Defense,
                SpecialAttack = request.SpecialAttack,
                SpecialDefense = request.SpecialDefense,
                Speed = request.Speed,
                Generation = request.Generation,
                Legendary = request.Legendary
            };

            _context.Pokemons.Add(pokemon);
            _context.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
