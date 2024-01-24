namespace GuessWeight.Api.Entities
{
    public class Game:EntityGenerics
    {
        public string Name { get; set; }
        public bool StartGame { get; set; } = false;
        public int ObjetoPesoId { get; set; }
        public ObjetoPeso ObjetoPeso { get; set; }
        public int UsuarioWinId { get; set; }
        public string? UsuarioWinNome { get; set; }
        public bool Finaliza { get; set; } = false;
        public int SalaId { get; set; }
    }
}
