using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessWeight.Library.Models
{
    public class SalaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public int QuantidadePartida { get; set; }
        public int QuantidadeTempo { get; set; }
       public List<UsuarioDto>? Usuarios { get; set; }
    }
}
