using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessWeight.Library.Models
{
    public class CreateSala
    {
        public int usuarioIdAdmin {  get; set; } 
        public SalaDto SalaDto { get; set; }
    }
}
