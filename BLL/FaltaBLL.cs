using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class FaltaBLL
    {
        FaltaDAL dal = new FaltaDAL();

        public void Inserir(FaltaDTO dto)
        {
            dal.Conectar();

            string query = "Insert into Faltas(data, presente, ausente, cod_disciplina, cod_id_aluno, cod_professor) " +
                " values('" + dto.Data + "', " + dto.Presente + ", " + dto.Ausente + ", " + dto.Cod_Disciplina + ", " + dto.Cod_ID_Aluno + ", " + dto.Cod_Professor + ")";
            dal.ExecutarComandoSQL(query);
        }
        public DataTable Preencher(string valor, string escolha)
        {
            DataTable dt = new DataTable();
            dal.Conectar();
            string query;

            if (escolha == "presenças")
            {
                query = "SELECT A.id, A.Nome [Aluno(a)], count(F.presente) AS Presenças, D.Nome [Disciplina], P.Nome [Professor] FROM Faltas F INNER JOIN ALUNO A ON A.ID = F.Cod_ID_Aluno INNER JOIN DISCIPLINA D ON D.ID = F.Cod_Disciplina " +
                "INNER JOIN PROFESSOR P ON P.ID = F.Cod_Professor WHERE A.Nome LIKE '%" + valor + "%' and f.presente = 1 GROUP BY A.id, A.Nome,D.Nome, P.Nome order by a.nome asc,d.nome asc";
            }
            else if (escolha == "ausencias")
            {
                query = "SELECT A.id, A.Nome [Aluno(a)], count(F.ausente) AS Ausências, D.Nome [Disciplina], P.Nome [Professor] FROM Faltas F INNER JOIN ALUNO A ON A.ID = F.Cod_ID_Aluno INNER JOIN DISCIPLINA D ON D.ID = F.Cod_Disciplina " +
                "INNER JOIN PROFESSOR P ON P.ID = F.Cod_Professor WHERE A.Nome LIKE '%" + valor + "%' and f.ausente = 1 GROUP BY A.id, A.Nome, D.Nome, P.Nome order by a.nome asc,d.nome asc";
            }
            else
            {
                query = "SELECT A.id [id], A.Nome[Aluno(a)], count(F.presente) AS Presenças, isnull(D.Nome,'') [Disciplina], isnull(P.Nome,'') [Professor], F.data [Data] FROM Faltas F INNER JOIN ALUNO A ON A.ID = F.Cod_ID_Aluno INNER JOIN DISCIPLINA D ON D.ID = F.Cod_Disciplina " +
                "LEFT JOIN PROFESSOR P ON P.ID = F.Cod_Professor WHERE A.Nome LIKE '%" + valor + "%' and f.presente = 1 GROUP BY A.id, A.Nome, D.Nome, P.Nome, F.data order by a.nome asc,d.nome asc";
            }

            dt = dal.RetTable(query);
            return dt;
        }
        public FaltaDTO Pesquisar(int valor)
        {
            FaltaDTO dto = new FaltaDTO();
            dal.Conectar();

            string query = "select f.id, data, presente, ausente, a.nome, d.nome, p.nome " +
            "from Faltas f inner join Aluno a on (a.id = f.cod_id_aluno) " +
            "inner join Disciplina d on (d.id = f.cod_disciplina) " +
            "inner join Professor p on (p.id = f.cod_professor) where id = " + valor;
            dal.RetReader(query);

            dto.ID = Convert.ToInt16(dal.array[0]);
            dto.Data = Convert.ToDateTime(dal.array[1]);
            dto.Presente = Convert.ToInt16(dal.array[2]);
            dto.Ausente = Convert.ToInt16(dal.array[3]);
            dto.Cod_Disciplina = Convert.ToInt16(dal.array[4]);
            dto.Cod_ID_Aluno = Convert.ToInt16(dal.array[5]);
            dto.Cod_Professor = Convert.ToInt16(dal.array[6]);

            return dto;
        }
    }
}
