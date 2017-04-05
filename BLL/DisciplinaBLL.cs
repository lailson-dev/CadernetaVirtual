using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class DisciplinaBLL
    {
        DisciplinaDAL dal = new DisciplinaDAL();

        public void Inserir(DisciplinaDTO dto)
        {
            dal.Conectar();

            string query = "Insert into Disciplina(nome) values ('" + dto.Nome + "')";
            dal.ExecutarComandoSQL(query);
        }
        public DataTable Preencher()
        {
            DataTable dt = new DataTable();
            dal.Conectar();

            string query = "Select * from Disciplina";
            dt = dal.RetTable(query);

            return dt;
        }
    }
}
