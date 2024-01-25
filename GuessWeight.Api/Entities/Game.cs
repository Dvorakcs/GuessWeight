namespace GuessWeight.Api.Entities
{
    public class Game:EntityGenerics
    {
        public string Name { get; set; }
        public bool StartGame { get; set; } = false;
        public string ObjetoNome { get; set; } = "Elefante";
        public double ObjetoPeso { get; set; } = 300;
        public int UsuarioWinId { get; set; }
        public string? UsuarioWinNome { get; set; }
        public bool Finaliza { get; set; } = false;
        public int SalaId { get; set; }
    }
}
