namespace GuessWeight.Api.Entities
{
    public class UsuarioRespostaPeso:EntityGenerics
    {
        public int UsuarioId { get; set; }
        public int GameId { get; set; }
        public double Resposta { get; set; }
        public bool EnviouResposta { get; set; } = false;
    }
}
