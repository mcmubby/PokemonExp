using Application.Pokemons.Create;
using FluentValidation;

namespace Application.Pokemons.Validators
{
    public class CreatePokemonCommandValidator : AbstractValidator<CreatePokemonCommand>
    {
        public CreatePokemonCommandValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Number).GreaterThan(0);
            RuleFor(p => p.Generation).GreaterThan(0);
        }
    }
}
