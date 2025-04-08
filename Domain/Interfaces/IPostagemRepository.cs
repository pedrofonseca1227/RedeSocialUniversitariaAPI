using RedeSocialUniversitaria.Domain.Entities;

namespace RedeSocialUniversitaria.Domain.Interfaces
{
    public interface IPostagemRepository
    {
        Task<Postagem> GetByIdAsync(Guid id);
        Task<IEnumerable<Postagem>> GetAllAsync();
        Task AddAsync(Postagem postagem);
        Task UpdateAsync(Postagem postagem);
        Task DeleteAsync(Guid id);

        Task CurtirPostagemAsync(Guid postagemId, Guid usuarioId);
        Task ComentarPostagemAsync(Guid postagemId, string comentario);
        Task ObterTodosAsync();
    }
}
