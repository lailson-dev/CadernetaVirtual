using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class SalaBLL
    {
        SalaDAL dal = new SalaDAL();

        public void Inserir(SalaDTO dto)
        {
            dal.Conectar();

            string query = "Insert into Sala(nome) values ('" + dto.Nome + "')";
            dal.ExecutarComandoSQL(query);
        }
        public void Excluir(AlunoDTO dto)
        {
            dal.Conectar();

            string query = "Delete from Sala where id = " + dto.Id;
            dal.ExecutarComandoSQL(query);
        }
        public DataTable Preencher()
        {
            dal.Conectar();
            DataTable dt = new DataTable();

            string query = "Select * from Sala";
            dt = dal.RetTable(query);
            return dt;
        }
    }
}
