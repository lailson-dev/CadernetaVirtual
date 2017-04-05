using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class SerieBLL
    {
        SerieDAL dal = new SerieDAL();

        public void Inserir(SerieDTO dto)
        {
            dal.Conectar();

            string query = "Insert into Serie(nome) values ('" + dto.Nome + "')";
            dal.ExecutarComandoSQL(query);
        }
        public void Excluir(AlunoDTO dto)
        {
            dal.Conectar();

            string query = "Delete from Serie where id = " + dto.Id;
            dal.ExecutarComandoSQL(query);
        }
        public DataTable Preencher()
        {
            dal.Conectar();
            DataTable dt = new DataTable();

            string query = "Select * from Serie";
            dt = dal.RetTable(query);
            return dt;
        }
    }
}
