using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    class DadosConexao
    {
        //protected static string server = DTO.DadosConexao.Server;
        //protected static string banco = DTO.DadosConexao.Banco;
        //protected static string user = DTO.DadosConexao.User;
        //protected static string pwd = DTO.DadosConexao.Pwd;

        public static string stringconexao = DTO.DadosConexao.StringConexao;

        public String strConexao
        {
            get
            {
                return string.Format(@"{0}", stringconexao);
            }
        }
    }
}
