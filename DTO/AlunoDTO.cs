using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class AlunoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Responsavel { get; set; }
        public int Cod_Sala { get; set; }
        public int Cod_Serie { get; set; }
        public int Cod_Turma { get; set; }
    }
}
