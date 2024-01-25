using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessWeight.Library.Models
{
    public class GameDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool StartGame { get; set; } 
        public string ObjetoNome { get; set; } 
        public double ObjetoPeso { get; set; } 
        public int UsuarioWinId { get; set; }
        public string? UsuarioWinNome { get; set; }
        public bool Finaliza { get; set; }
        public int SalaId { get; set; }
    }
}
