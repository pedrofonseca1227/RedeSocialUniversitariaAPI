using RedeSocialUniversitaria.Domain.Entities;

namespace RedeSocialUniversitaria.Domain.Interfaces
{
    public interface IEventoRepository
    {
        Task<Evento> GetByIdAsync(Guid id);
        Task<IEnumerable<Evento>> GetAllAsync();
        Task AddAsync(Evento evento);
        Task UpdateAsync(Evento evento);
        Task DeleteAsync(Guid id);

        Task InscreverUsuarioAsync(Guid eventoId, Guid usuarioId);
    }
}
