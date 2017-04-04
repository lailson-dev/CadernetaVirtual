using DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class AulaDAL
    {
        #region "-----Objetos-----"
        SqlConnection sqlCon;
        SqlCommand cmd;
        SqlCommandBuilder cmdb;
        SqlDataReader dr = null;
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
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(SQL, sqlCon);
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
                array[2] = Convert.ToString(dr["horaentrada"]);
                array[3] = Convert.ToString(dr["horasaida"]);
                array[4] = Convert.ToInt16(dr["cod_disciplina"]);
                array[5] = Convert.ToInt16(dr["cod_professor"]);
                array[6] = Convert.ToInt16(dr["cod_sala"]);
                array[7] = Convert.ToInt16(dr["cod_serie"]);
                array[8] = Convert.ToInt16(dr["cod_turma"]);
            }
            return dr;
        }
    }
}
