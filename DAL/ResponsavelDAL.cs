using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class ResponsavelDAL
    {
        private SqlConnection sqlCon;
        private SqlDataReader dr;
        DadosConexao dados = new DadosConexao();

        public void Conectar()
        {
            if (sqlCon != null)
                sqlCon.Close();

            string strCon = dados.strConexao;
            try
            {
                sqlCon = new SqlConnection(strCon);
                sqlCon.Open();
            }
            catch (SqlException er)
            {
                throw new Exception(er.Message);
            }

        }
        public List<ResponsavelDTO> RetornaList(string sql)
        {
            List<ResponsavelDTO> lista = new List<ResponsavelDTO>();
            ResponsavelDTO dto = new ResponsavelDTO();

            SqlCommand cmd = new SqlCommand(sql, sqlCon);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                dto.EmailResponsavel.Add(dr.GetString(0));
                lista.Add(dto);
            }
            return lista;
        }
    }
}
