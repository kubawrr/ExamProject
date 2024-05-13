using Infrastructure.Entities;

namespace MoviesWebApi.Interfaces
{
    public interface IMovieService
    {
        Task<IEnumerable<Keyword>> GetKeywords();
    }
}
