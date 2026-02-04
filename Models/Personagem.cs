using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoNaruto.Models
{
    public class Personagem
    {
        // campos da tabela personagem
        public int Id  { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
    }
}