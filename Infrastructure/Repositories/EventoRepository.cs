using RedeSocialUniversitaria.Domain.Entities;
using RedeSocialUniversitaria.Domain.Interfaces;
using RedeSocialUniversitaria.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;

namespace RedeSocialUniversitaria.Infrastructure.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly AppDbContext _context;

        public EventoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Evento evento)
        {
            await _context.Eventos.AddAsync(evento);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var evento = await GetByIdAsync(id);
            _context.Eventos.Remove(evento);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Evento>> GetAllAsync()
        {
            return await _context.Eventos.ToListAsync();
        }

        public async Task<Evento> GetByIdAsync(Guid id)
        {
            return await _context.Eventos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task InscreverUsuarioAsync(Guid eventoId, Guid usuarioId)
        {
            var evento = await GetByIdAsync(eventoId);
            evento.Inscritos.Add(usuarioId);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Evento evento)
        {
            _context.Eventos.Update(evento);
            await _context.SaveChangesAsync();
        }
    }
}
