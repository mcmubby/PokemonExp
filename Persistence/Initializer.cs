using Application.Interfaces.Persistence;
using Domain.Pokemons;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence
{
    public static class Initializer
    {
        public static void SeedData(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<IAppDbContext>();

            try
            {
                if (!dbContext.Pokemons.Any())
                {
                    var pokemons = ReadCsv();
                    dbContext.Pokemons.AddRange(pokemons);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while seeding data: {ex.Message}");
            }
        }

        private static IEnumerable<Pokemon> ReadCsv()
        {
            // Skip header line when reading
            var pokemonData = File.ReadLines("pokemon.csv").Skip(1);

            var pokemons = pokemonData.Select(pokemon =>
            {
                var data = pokemon.Split(',');

                return new Pokemon
                {
                    Number = Convert.ToInt32(data[0]),
                    Name = data[1],
                    Type1 = data[2],
                    Type2 = data[3],
                    Total = Convert.ToInt32(data[4]),
                    HP = Convert.ToInt32(data[5]),
                    Attack = Convert.ToInt32(data[6]),
                    Defense = Convert.ToInt32(data[7]),
                    SpecialAttack = Convert.ToInt32(data[8]),
                    SpecialDefense = Convert.ToInt32(data[9]),
                    Speed = Convert.ToInt32(data[10]),
                    Generation = Convert.ToInt32(data[11]),
                    Legendary = Convert.ToBoolean(data[12])
                };
            });

            return pokemons;
        }
    }
}
