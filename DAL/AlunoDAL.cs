using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class AlunoDAL
    {
        #region "----Propriedades----"
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Responsavel { get; set; }
        public int Cod_Sala { get; set; }
        public int Cod_Serie { get; set; }
        public int Cod_Turma { get; set; }
        #endregion
        #region "-----Objetos-----"
        SqlConnection Conn;
        SqlDataReader dr;
        SqlCommand cmd;
        SqlCommandBuilder cmdb;
        #endregion

        DadosConexao dados = new DadosConexao();
        public void Conectar()
        {
            string strCon = dados.strConexao;

            try
            {
                Conn = new SqlConnection(strCon);
                Conn.Open();
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ExecutarComandoSQL(string SQL)
        {
            cmd = new SqlCommand(SQL, Conn);
            cmd.ExecuteNonQuery();
            Conn.Close();
        }
        public DataTable RetTable(string SQL)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(SQL, Conn);
            cmdb = new SqlCommandBuilder(adp);
            adp.Fill(dt);
            return dt;
        }
        public SqlDataReader RetReader(string SQL)
        {
            cmd = new SqlCommand(SQL, Conn);
            dr = cmd.ExecuteReader();
            dr.Read();

            if (dr.HasRows)
            {
                Id = Convert.ToInt32(dr["id"]);
                Nome = Convert.ToString(dr["nome"]);
                Responsavel = Convert.ToString(dr["responsavel"]);
                Cod_Sala = Convert.ToInt16(dr["cod_sala"]);
                Cod_Serie = Convert.ToInt16(dr["cod_serie"]);
                Cod_Turma = Convert.ToInt16(dr["cod_turma"]);
            }
            return dr;
        }
    }
}
