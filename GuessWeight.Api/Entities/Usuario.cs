namespace GuessWeight.Api.Entities
{
    public class Usuario:EntityGenerics
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public int PontosTotal {  get; set; }

        public int SalaId { get; set; }
    }
}
