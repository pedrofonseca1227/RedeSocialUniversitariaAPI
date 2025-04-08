using Microsoft.AspNetCore.Mvc;
using RedeSocialUniversitaria.Domain.Entities;
using RedeSocialUniversitaria.Domain.Interfaces;

namespace RedeSocialUniversitaria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        private readonly IEventoRepository _eventoRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public EventoController(IEventoRepository eventoRepository, IUsuarioRepository usuarioRepository)
        {
            _eventoRepository = eventoRepository;
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Evento>>> GetAll()
        {
            var eventos = await _eventoRepository.GetAllAsync();
            return Ok(eventos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Evento>> GetById(Guid id)
        {
            var evento = await _eventoRepository.GetByIdAsync(id);
            if (evento == null)
                return NotFound();

            return Ok(evento);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Evento evento)
        {
            await _eventoRepository.AddAsync(evento);
            return CreatedAtAction(nameof(GetById), new { id = evento.Id }, evento);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, Evento evento)
        {
            if (id != evento.Id)
                return BadRequest();

            var eventoExistente = await _eventoRepository.GetByIdAsync(id);
            if (eventoExistente == null)
                return NotFound();

            await _eventoRepository.UpdateAsync(evento);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var eventoExistente = await _eventoRepository.GetByIdAsync(id);
            if (eventoExistente == null)
                return NotFound();

            await _eventoRepository.DeleteAsync(id);
            return NoContent();
        }

        // Inscrição em Evento
        [HttpPost("{eventoId}/inscrever/{usuarioId}")]
        public async Task<ActionResult> Inscrever(Guid eventoId, Guid usuarioId)
        {
            var evento = await _eventoRepository.GetByIdAsync(eventoId);
            if (evento == null)
                return NotFound("Evento não encontrado.");

            var usuario = await _usuarioRepository.GetByIdAsync(usuarioId);
            if (usuario == null)
                return NotFound("Usuário não encontrado.");

            evento.Inscritos.Add(usuario);
            await _eventoRepository.UpdateAsync(evento);

            return NoContent();
        }
    }
}
