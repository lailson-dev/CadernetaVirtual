using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class FaltaDAL
    {
        #region "-----Objetos-----"
        SqlConnection sqlCon;
        SqlCommand cmd;
        SqlCommandBuilder cmdb;
        SqlDataAdapter adp;
        SqlDataReader dr;
        DataTable dt;
        #endregion

        public ArrayList array = new ArrayList();
        DadosConexao dados = new DadosConexao();

        public void Conectar()
        {
            string strConexao = dados.strConexao;

            try
            {
                sqlCon = new SqlConnection(strConexao);
                sqlCon.Open();
            }
            catch (SqlException ex) { throw new Exception(ex.Message); }
        }
        public void ExecutarComandoSQL(string SQL)
        {
            cmd = new SqlCommand(SQL, sqlCon);
            cmd.ExecuteNonQuery();
            sqlCon.Close();
        }
        public DataTable RetTable(string SQL)
        {
            dt = new DataTable();
            adp = new SqlDataAdapter(SQL, sqlCon);
            cmdb = new SqlCommandBuilder(adp);
            adp.Fill(dt);
            return dt;
        }
        public SqlDataReader RetReader(string SQL)
        {
            cmd = new SqlCommand(SQL, sqlCon);
            dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                array[0] = Convert.ToInt16(dr["id"]);
                array[1] = Convert.ToDateTime(dr["data"]);
                array[2] = Convert.ToInt16(dr["presente"]);
                array[3] = Convert.ToInt16(dr["ausente"]);
                array[4] = Convert.ToInt16(dr["cod_disciplina"]);
                array[5] = Convert.ToInt16(dr["cod_id_aluno"]);
                array[6] = Convert.ToInt16(dr["cod_professor"]);
            }
            return dr;
        }
    }
}
