using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class ProfessorBLL
    {
        ProfessorDAL dal = new ProfessorDAL();

        public void Inserir(ProfessorDTO dto)
        {
            dal.Conectar();

            string query = "Insert into Professor(nome) values('" + dto.Nome + "')";
            dal.ExecutarComandoSQL(query);
        }
        public DataTable Preencher()
        {
            DataTable dt = new DataTable();
            dal.Conectar();

            string query = "Select * from Professor";
            dt = dal.RetTable(query);
            return dt;
        }
    }
}
