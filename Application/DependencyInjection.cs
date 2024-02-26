using Microsoft.Extensions.DependencyInjection;
using Application.Pokemons.Validators;
using FluentValidation;

namespace Application
{
    public static class DependencyInjection
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining<ApplicationAssemblyReference>() );
            services.AddValidatorsFromAssemblyContaining<CreatePokemonCommandValidator>();
        }
    }
}
