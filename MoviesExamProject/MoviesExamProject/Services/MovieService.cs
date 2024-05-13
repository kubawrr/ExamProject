
using Infrastructure;
using Infrastructure.Entities;
using MoviesWebApi.Interfaces;
using MoviesWebApi.Pagination;

namespace MoviesWebApi.Services
{
    public class MovieService : IMovieService
    {
        private readonly AppDbContext _context;
        public MovieService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Keyword>> GetKeywords()
        {
            var keywords = await _context.Keywords.ToPagedListAsync(1, 15);
            return keywords;
        }
    }
}
