namespace Application.Pokemons.Exceptions
{
    public class ExistingRecordException : Exception
    {
        public ExistingRecordException() : base("Similar Pokemon record exists! Verify pokemon name and number") { }
    }
}
