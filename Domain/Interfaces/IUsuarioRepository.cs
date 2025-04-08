using RedeSocialUniversitaria.Domain.Entities;

namespace RedeSocialUniversitaria.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> GetByIdAsync(Guid id);
        Task<IEnumerable<Usuario>> GetAllAsync();
        Task AddAsync(Usuario usuario);
        Task UpdateAsync(Usuario usuario);
        Task DeleteAsync(Guid id);

        Task SeguirUsuarioAsync(Guid usuarioId, Guid seguidorId);
    }
}
