using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CadernetaVirtual
{
    public partial class frmConsultaAluno : Form
    {
        AlunoBLL bll = new AlunoBLL();
        AlunoDTO dto = new AlunoDTO();
        public int codigo = 0;
        public frmConsultaAluno()
        {
            InitializeComponent();
        }
        private void CarregaGrid()
        {
            dgvDados.Columns[0].HeaderText = "ID";
            dgvDados.Columns[0].Width = 30;
            dgvDados.Columns[1].HeaderText = "Aluno(a)";
            dgvDados.Columns[1].Width = 200;
            dgvDados.Columns[2].HeaderText = "Responsavel";
            dgvDados.Columns[2].Width = 150;
            dgvDados.Columns[3].HeaderText = "Sala";
            dgvDados.Columns[3].Width = 45;
            dgvDados.Columns[4].HeaderText = "Serie";
            dgvDados.Columns[4].Width = 45;
            dgvDados.Columns[5].HeaderText = "Turma";
            dgvDados.Columns[5].Width = 45;
        }

        private void frmConsultaAluno_Load(object sender, EventArgs e)
        {
            btPesquisar_Click(sender, e);
            CarregaGrid();   
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            string nome = txtPesquisa.Text.Replace("'", "''");
            dto.Nome = nome;
            dgvDados.DataSource = bll.Preencher(dto);
        }

        private void dgvDados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                codigo = Convert.ToInt32(dgvDados.Rows[e.RowIndex].Cells[0].Value);
                this.Close();
            }
        }
    }
}
