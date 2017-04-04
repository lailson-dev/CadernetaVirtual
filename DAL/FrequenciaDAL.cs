using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class FrequenciaDAL
    {
        private int ausente;

        public int Ausente
        {
            get { return ausente; }
            set { ausente = value; }
        }
        private int presente;
        public int Presente
        {
            get { return presente; }
            set { presente = value; }
        }

        DadosConexao dados = new DadosConexao();

        private SqlConnection sqlCon;
        private DataTable dt;
        private SqlDataAdapter adp;
        private SqlCommandBuilder cmdb;

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
            SqlCommand cmd = new SqlCommand(SQL, sqlCon);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                presente = Convert.ToInt32(reader["total"]);
                ausente = Convert.ToInt32(reader["total"]);
            }
            return reader;
        }
    }
}
