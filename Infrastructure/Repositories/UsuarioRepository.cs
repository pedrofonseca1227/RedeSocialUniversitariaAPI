using RedeSocialUniversitaria.Domain.Entities;
using RedeSocialUniversitaria.Domain.Interfaces;
using RedeSocialUniversitaria.Domain.Context;
using Microsoft.EntityFrameworkCore;
using System;

namespace RedeSocialUniversitaria.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var usuario = await GetByIdAsync(id);
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _context.Usuarios
                .Include(u => u.Seguidores)
                .ToListAsync();
        }

        public async Task<Usuario> GetByIdAsync(Guid id)
        {
            return await _context.Usuarios
                .Include(u => u.Seguidores)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task SeguirUsuarioAsync(Guid usuarioId, Guid seguidorId)
        {
            var usuario = await GetByIdAsync(usuarioId);
            var seguidor = await GetByIdAsync(seguidorId);

            usuario.Seguidores.Add(seguidor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
        }
    }
}
