namespace RedeSocialUniversitaria.Domain.Entities
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public required string Nome { get; set; }
        public required string Email { get; set; }
        public required string Curso { get; set; }

        public List<Usuario> Seguidores { get; set; } = new List<Usuario>();
        public List<Postagem> Postagens { get; set; } = new List<Postagem>();
    }
}
