namespace RedeSocialUniversitaria.Domain.Entities
{
    public class Postagem
    {
        public Guid Id { get; set; }
        public Guid AutorId { get; set; }
        public required Usuario Autor { get; set; }
        public required string Conteudo { get; set; }
        public DateTime DataHora { get; set; }

        public List<Usuario> Curtidas { get; set; } = new List<Usuario>();
        public List<string> Comentarios { get; set; } = new List<string>();
    }
}
