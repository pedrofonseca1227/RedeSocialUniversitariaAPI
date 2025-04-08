using RedeSocialUniversitaria.Domain.Entities;
using RedeSocialUniversitaria.Domain.Interfaces;
using RedeSocialUniversitaria.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;

namespace RedeSocialUniversitaria.Infrastructure.Repositories
{
    public class PostagemRepository : IPostagemRepository
    {
        private readonly AppDbContext _context;

        public PostagemRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Postagem>> ObterTodosAsync()
        {
            return await _context.Postagens
                .Include(p => p.Autor)
                .Include(p => p.Curtidas)
                .ToListAsync();
        }

        public async Task<Postagem?> ObterPorIdAsync(Guid id)
        {
            return await _context.Postagens
                .Include(p => p.Autor)
                .Include(p => p.Curtidas)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AdicionarAsync(Postagem postagem)
        {
            _context.Postagens.Add(postagem);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Postagem postagem)
        {
            _context.Postagens.Update(postagem);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(Guid id)
        {
            var postagem = await ObterPorIdAsync(id);
            if (postagem != null)
            {
                _context.Postagens.Remove(postagem);
                await _context.SaveChangesAsync();
            }
        }
    }
}