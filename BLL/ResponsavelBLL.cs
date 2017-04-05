using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class ResponsavelBLL
    {
        ResponsavelDAL dal = new ResponsavelDAL();

        public List<ResponsavelDTO> Localizar(String valor)
        {
            List<ResponsavelDTO> dto = new List<ResponsavelDTO>();
            dal.Conectar();

            try
            {
                string query = "select distinct responsavel from Aluno " +
                "inner join Faltas on (Aluno.id = Faltas.cod_id_aluno) where Faltas.data = '" + valor + "'";
                dto = dal.RetornaList(query);
                return dto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
