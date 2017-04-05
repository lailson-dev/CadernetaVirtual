using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BLL
{
    public class UsuarioBLL
    {
        UsuarioDAL dal = new UsuarioDAL();

        public void Inserir(UsuarioDTO dto)
        {
            dal.Conectar();

            try
            {
                string query = "INSERT INTO Usuario (nome, nomeusuario, senha) VALUES ('" + dto.Nome + "', '" + dto.Usuario + "', CONVERT(VARBINARY(255), PWDENCRYPT('" + dto.Senha + "')))";

                dal.ExecutarComandoSQL(query);
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public int Autenticar(string usuario, string senha)
        {
            UsuarioDTO dto = new UsuarioDTO();
            int resultado = 0;

            dal.Conectar();

            try
            {
                string query = "SELECT * FROM Usuario WHERE nomeusuario = '" + usuario + "' and PWDCOMPARE('" + senha + "', senha) = 1";
                dal.RetornaDR(query);

                resultado = dal.resultado;

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public UsuarioDTO VerificaUsuario(string nome)
        {
            UsuarioDTO dto = new UsuarioDTO();
            dal.Conectar();

            string query = "Select nomeusuario from Usuario where nomeusuario = '" + nome + "'";
            dal.RetornaExistente(query);

            dto.Nome = dal.existente;

            return dto;
        }
    }
}
