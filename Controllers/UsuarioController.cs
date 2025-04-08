using Microsoft.AspNetCore.Mvc;
using RedeSocialUniversitaria.Domain.Entities;
using RedeSocialUniversitaria.Domain.Interfaces;

namespace RedeSocialUniversitaria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetAll()
        {
            var usuarios = await _usuarioRepository.GetAllAsync();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetById(Guid id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario == null)
                return NotFound();

            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Usuario usuario)
        {
            await _usuarioRepository.AddAsync(usuario);
            return CreatedAtAction(nameof(GetById), new { id = usuario.Id }, usuario);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, Usuario usuario)
        {
            if (id != usuario.Id)
                return BadRequest();

            var usuarioExistente = await _usuarioRepository.GetByIdAsync(id);
            if (usuarioExistente == null)
                return NotFound();

            await _usuarioRepository.UpdateAsync(usuario);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var usuarioExistente = await _usuarioRepository.GetByIdAsync(id);
            if (usuarioExistente == null)
                return NotFound();

            await _usuarioRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
