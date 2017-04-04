using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class FaltaDTO
    {
        public int ID { get; set; }
        public DateTime Data { get; set; }
        public int Presente { get; set; }
        public int Ausente { get; set; }
        public int Cod_Disciplina { get; set; }
        public int Cod_ID_Aluno { get; set; }
        public int Cod_Professor { get; set; }
    }
}
