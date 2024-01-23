namespace GuessWeight.Api.Entities
{
    public class Round:EntityGenerics
    {
        public string Nome { get; set; }
        public int SalaId { get; set; } 
        public Sala Sala { get; set; }
    }
}
