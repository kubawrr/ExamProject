using Infrastructure.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesWebApi.Interfaces;

namespace MoviesWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private IMovieService _service;
        public MoviesController(IMovieService service)
        {
            _service = service;
        }
        [HttpGet]
        public Task<IEnumerable<Keyword>> GetKeywords()
        {
            return _service.GetKeywords(); 
        }
    }
}
