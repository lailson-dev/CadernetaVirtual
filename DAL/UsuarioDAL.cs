using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class UsuarioDAL
    {

        #region "-----Atributos-----"
        public int id { get; set; }
        public string usuario { get; set; }
        public string senha { get; set; }
        public int resultado { get; set; }
        public string existente;
        #endregion
        #region "-----Objetos-----"
        private SqlConnection sqlCon;
        private SqlDataAdapter adp;
        private SqlDataReader dr;
        SqlCommandBuilder cmdb;
        DadosConexao dados = new DadosConexao();
        #endregion

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
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public void ExecutarComandoSQL(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, sqlCon);
            cmd.ExecuteNonQuery();
            sqlCon.Close();
        }
        public DataTable RetornaDT(string sql)
        {
            DataTable dt = new DataTable();
            adp = new SqlDataAdapter(sql, sqlCon);
            cmdb = new SqlCommandBuilder(adp);
            adp.Fill(dt);
            return dt;
        }
        public int RetornaDR(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, sqlCon);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                resultado = 255;
            }
            return resultado;
        }
        public SqlDataReader RetornaExistente(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, sqlCon);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                existente = Convert.ToString(dr["nomeusuario"]);
            }
            return dr;
        }
    }
}
