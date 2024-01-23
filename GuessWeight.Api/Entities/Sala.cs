namespace GuessWeight.Api.Entities
{
    public class Sala:EntityGenerics
    {
        public string Nome { get; set; }
        public string Senha { get; set; }
        public int QuantidadePartida { get; set; }
        public int QuantidadeTempo { get; set; }

    }
}
