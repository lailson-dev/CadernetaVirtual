using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class FrequenciaBLL
    {
        FrequenciaDAL dal = new FrequenciaDAL();

        public FrequenciaDTO Localizar(string decisao, int valor)
        {
            FrequenciaDTO dto = new FrequenciaDTO();
            dal.Conectar();

            dal.RetReader("select f.cod_id_aluno, sum(" + decisao + ") as Total from Faltas f inner join Aluno a on f.cod_id_aluno = a.id " +
            "where f.cod_id_aluno = " + valor + " group by f.cod_id_aluno");

            if (decisao == "presente")
                dto.Presente = dal.Presente;
            else
                dto.Ausente = dal.Ausente;

            return dto;
        }
    }
}
