using Application.Pokemons.Create;
using Application.Pokemons.Update;
using FluentValidation;

namespace Application.Pokemons.Validators
{
    public class UpdatePokemonCommandValidator : AbstractValidator<UpdatePokemonCommand>
    {
        public UpdatePokemonCommandValidator()
        {
            RuleFor(p => p.Id).GreaterThan(0);
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Number).GreaterThan(0);
            RuleFor(p => p.Generation).GreaterThan(0);
        }
    }
}
