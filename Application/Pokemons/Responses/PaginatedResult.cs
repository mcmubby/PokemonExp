using Microsoft.EntityFrameworkCore;

namespace Application.Pokemons.Responses
{
    public class PaginatedResult<T>
    {
        private PaginatedResult(List<T> pokemons, int page, int pageSize, int totalCount)
        {
            Pokemons = pokemons;
            Page = page;
            PageSize = pageSize;
            TotalCount = totalCount;
        }

        public List<T> Pokemons { get; }

        public int Page { get; }

        public int PageSize { get; }

        public int TotalCount { get; }

        public bool HasNextPage => Page * PageSize < TotalCount;

        public bool HasPreviousPage => Page > 1;

        public static async Task<PaginatedResult<T>> CreateAsync(IQueryable<T> query, int page, int pageSize)
        {
            var totalCount = await query.CountAsync();
            var items = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            return new(items, page, pageSize, totalCount);
        }
    }
}
