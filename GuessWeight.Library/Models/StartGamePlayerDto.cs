using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessWeight.Library.Models
{
    public class StartGamePlayerDto
    {
        public int UsuaroId { get; set; }
        public int SalaId { get; set; }
        public bool UsuarioStartGame {  get; set; }
    }
}
