using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class AulaDTO
    {
        public int ID { get; set; }
        public DateTime Data { get; set; }
        public string HoraEntrada { get; set; }
        public string HoraSaida { get; set; }
        public int Cod_Disciplina { get; set; }
        public int Cod_Professor { get; set; }
        public int Cod_Sala { get; set; }
        public int Cod_Serie { get; set; }
        public int Cod_Turma { get; set; }
    }
}
