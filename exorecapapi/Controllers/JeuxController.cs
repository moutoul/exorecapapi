using exorecapapi.Entities;
using exorecapapi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace exorecapapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JeuxController : ControllerBase
    {
        private readonly JeuxRepository _repository;

        public JeuxController(JeuxRepository repository)
        {
            _repository = repository;
        }
        [HttpPost]
        [Route("Jeux/{leJeux:int}")]
        public IActionResult AjouterJeu([FromBody] JeuxPOCO jeu)
        {
            _repository.Add(jeu);
            return Ok(jeu);
        }
    }
}
