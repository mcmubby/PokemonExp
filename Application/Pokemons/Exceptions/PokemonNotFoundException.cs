namespace Application.Pokemons.Exceptions
{
    public class PokemonNotFoundException : Exception
    {
        public PokemonNotFoundException() : base("Pokemon not found!") { }
    }
}
