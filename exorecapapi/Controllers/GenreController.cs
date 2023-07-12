using exorecapapi.Entities;
using exorecapapi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace exorecapapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly GenreRepository _repository;

        public GenreController(GenreRepository repository)
        {
            _repository = repository;
        }
        [HttpPost]
        [Route("Genre/{leGenre:int}")]
        public IActionResult AjouterJeu([FromBody] GenrePOCO genr)
        {
            _repository.Add(genr);
            return Ok(genr);
        }
    }
}
