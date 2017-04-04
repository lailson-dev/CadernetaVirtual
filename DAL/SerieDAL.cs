using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class SerieDAL
    {
        #region "-----Objetos-----"
        SqlConnection sqlCon;
        SqlCommand cmd;
        SqlCommandBuilder cmdb;
        #endregion
        DadosConexao dados = new DadosConexao();
        public void Conectar()
        {
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
        public void ExecutarComandoSQL(string SQL)
        {
            cmd = new SqlCommand(SQL, sqlCon);
            cmd.ExecuteNonQuery();
            sqlCon.Close();
        }
        public DataTable RetTable(string SQL)
        {
            SqlDataAdapter adp = new SqlDataAdapter(SQL, sqlCon);
            DataTable dt = new DataTable();
            cmdb = new SqlCommandBuilder(adp);
            adp.Fill(dt);
            return dt;
        }
    }
}
