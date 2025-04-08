using Microsoft.AspNetCore.Mvc;
using RedeSocialUniversitaria.Domain.Entities;
using RedeSocialUniversitaria.Domain.Interfaces;

namespace RedeSocialUniversitaria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostagemController : ControllerBase
    {
        private readonly IPostagemRepository _postagemRepository;

        public PostagemController(IPostagemRepository postagemRepository)
        {
            _postagemRepository = postagemRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var postagens = await _postagemRepository.GetAllAsync();
            return Ok(postagens);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            var postagem = await _postagemRepository.GetByIdAsync(id);
            if (postagem == null)
                return NotFound();

            return Ok(postagem);
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar(Postagem postagem)
        {
            await _postagemRepository.AddAsync(postagem);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(Guid id, Postagem postagem)
        {
            if (id != postagem.Id)
                return BadRequest();

            await _postagemRepository.UpdateAsync(postagem);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(Guid id)
        {
            await _postagemRepository.DeleteAsync(id);
            return Ok();
        }
    }
}
