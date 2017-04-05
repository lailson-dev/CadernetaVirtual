using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class AulaBLL
    {
        AulaDAL dal = new AulaDAL();

        public void Inserir(AulaDTO dto)
        {
            dal.Conectar();

            string query = "Insert into Aula (data, horaentrada, horasaida, cod_disciplina, cod_professor, cod_sala, cod_serie, cod_turma) " +
                " values('" + dto.Data + "', '" + dto.HoraEntrada + "', '" + dto.HoraSaida + "', " + dto.Cod_Disciplina + ", " + dto.Cod_Professor + ", " + dto.Cod_Sala + ", " + dto.Cod_Serie + ", " + dto.Cod_Turma + ")";
            dal.ExecutarComandoSQL(query);
        }
        public void Atualizar(AulaDTO dto)
        {
            dal.Conectar();

            string query = "Update Aula set data = '" + dto.Data + "', horaentrada = '" + dto.HoraEntrada + "', horasaida = '" + dto.HoraSaida + "', cod_disciplina = " + dto.Cod_Disciplina + ", cod_professor = " + dto.Cod_Professor + ", cod_sala = " + dto.Cod_Sala + ", cod_serie = " + dto.Cod_Serie + ", cod_turma = " + dto.Cod_Turma + " where id = " + dto.ID;
            dal.ExecutarComandoSQL(query);
        }
        public void Deletar(AulaDTO dto)
        {
            dal.Conectar();

            string query = "Delete from Aula where id = " + dto.ID;
            dal.ExecutarComandoSQL(query);
        }
        public DataTable Preencher()
        {
            DataTable dt = new DataTable();
            dal.Conectar();

            string query = "select a.data, a.horaentrada, a.horasaida, d.nome, p.nome, sa.nome, se.nome, t.nome from Aula a inner join Disciplina d on (a.cod_disciplina = d.id) "+
            "inner join Professor p on (a.cod_professor = p.id) inner join Sala sa on (a.cod_sala = sa.id) inner join Serie se on (a.cod_serie = se.id) inner join Turma t on (a.cod_turma = t.id)";
            dt = dal.RetTable(query);

            return dt;
        }
        public AulaDTO Pesquisar(string valor)
        {
            AulaDTO dto = new AulaDTO();
            dal.Conectar();

            string query = "";
            dal.RetReader(query);

            dto.ID = Convert.ToInt16(dal.array[0]);
            dto.Data = Convert.ToDateTime(dal.array[1]);
            dto.HoraEntrada = Convert.ToString(dal.array[2]);
            dto.HoraSaida = Convert.ToString(dal.array[3]);
            dto.Cod_Disciplina = Convert.ToInt16(dal.array[4]);
            dto.Cod_Professor = Convert.ToInt16(dal.array[5]);
            dto.Cod_Sala = Convert.ToInt16(dal.array[6]);
            dto.Cod_Serie = Convert.ToInt16(dal.array[7]);
            dto.Cod_Turma = Convert.ToInt16(dal.array[8]);

            return dto;
        }
    }
}
