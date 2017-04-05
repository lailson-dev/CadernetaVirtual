using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class TurmaBLL
    {
        TurmaDAL dal = new TurmaDAL();

        public void Inserir(TurmaDTO dto)
        {
            dal.Conectar();

            string query = "Insert into Turma(nome) values ('" + dto.Nome + "')";
            dal.ExecutarComandoSQL(query);
        }
        public void Excluir(AlunoDTO dto)
        {
            dal.Conectar();

            string query = "Delete from Turma where id = " + dto.Id;
            dal.ExecutarComandoSQL(query);
        }
        public DataTable Preencher()
        {
            dal.Conectar();
            DataTable dt = new DataTable();

            string query = "Select * from Turma";
            dt = dal.RetTable(query);
            return dt;
        }
    }
}
