using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessWeight.Library.Models
{
    public class UsuarioRespostaPesoDto
    {
        public int UsuarioId { get; set; }
        public int GameId { get; set; }
        public double Resposta { get; set; }
        public bool EnviouResposta { get; set; } = false;
    }
}
