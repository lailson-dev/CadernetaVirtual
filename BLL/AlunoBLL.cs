using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DTO;
using System.Data;

namespace BLL
{
    public class AlunoBLL
    {
        AlunoDAL dal = new AlunoDAL();

        public void Inserir(AlunoDTO dto)
        {
            dal.Conectar();

            string query = "Insert into Aluno (nome, responsavel, cod_sala, cod_serie, cod_turma) values ('" + dto.Nome + "', '" + dto.Responsavel + "' " +
                ", " + dto.Cod_Sala + ", " + dto.Cod_Serie + ", " + dto.Cod_Turma + ")";
            dal.ExecutarComandoSQL(query);
        }
        public void Atualizar(AlunoDTO dto)
        {
            dal.Conectar();

            string query = "Update Aluno set nome = '" + dto.Nome + "', responsavel = '" + dto.Responsavel + "' " +
                ", cod_sala = " + dto.Cod_Sala + ", cod_serie = " + dto.Cod_Serie + " where id = " + dto.Id;
            dal.ExecutarComandoSQL(query);
        }
        public void Excluir(AlunoDTO dto)
        {
            dal.Conectar();

            string query = "Delete from Aluno where id = " + dto.Id;
            dal.ExecutarComandoSQL(query);
        }
        public DataTable Preencher(AlunoDTO dto)
        {
            dal.Conectar();
            DataTable dt = new DataTable();

            string query = "select a.id, a.nome, a.responsavel, s.nome, se.nome, t.nome from Aluno a inner join Sala s on (a.cod_sala = s.id) " +
                    "inner join Serie se on(a.cod_serie = se.id) inner join Turma t on (a.cod_turma = t.id) where a.nome like '%" + dto.Nome + "%'";
            dt = dal.RetTable(query);

            return dt;
        }
        public AlunoDTO Pesquisar(int valor)
        {
            dal.Conectar();
            AlunoDTO dto = new AlunoDTO();

            string query = "Select * from Aluno where id = " + valor;
            dal.RetReader(query);

            dto.Id = dal.Id;
            dto.Nome = dal.Nome;
            dto.Responsavel = dal.Responsavel;
            dto.Cod_Sala = dal.Cod_Sala;
            dto.Cod_Serie = dal.Cod_Serie;
            dto.Cod_Turma = dal.Cod_Turma;

            return dto;
        }
    }
}
