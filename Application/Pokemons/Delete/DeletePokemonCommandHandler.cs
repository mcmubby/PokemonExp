using Application.Interfaces.Persistence;
using Application.Pokemons.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Pokemons.Delete
{
    public class DeletePokemonCommandHandler : IRequestHandler<DeletePokemonCommand>
    {
        private readonly IAppDbContext _context;

        public DeletePokemonCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task Handle(DeletePokemonCommand request, CancellationToken cancellationToken)
        {
            var pokemon = await _context.Pokemons.Where(p => p.Id == request.Id).FirstOrDefaultAsync() ?? throw new PokemonNotFoundException();

            _context.Pokemons.Remove(pokemon);
            _context.SaveChanges();
        }
    }
}
