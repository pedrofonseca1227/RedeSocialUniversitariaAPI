namespace RedeSocialUniversitaria.Domain.Entities
{
    public class Evento
    {
        public Guid Id { get; set; }
        public required string Nome { get; set; }
        public required string Local { get; set; }
        public required string Descricao { get; set; }
        public DateTime DataHora { get; set; }

        public bool ExigeInscricao { get; set; }

        public List<Usuario> Inscritos { get; set; } = new List<Usuario>();

        public void InscreverUsuario(Usuario usuario)
        {
            Inscritos.Add(usuario);
        }
    }

}
