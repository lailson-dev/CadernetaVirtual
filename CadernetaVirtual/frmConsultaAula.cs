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
    public partial class frmConsultaAula : Form
    {
        AulaDTO dto = new AulaDTO();
        AulaBLL bll = new AulaBLL();
        public int codigo = 0;
        public frmConsultaAula()
        {
            InitializeComponent();
        }
        private void CarregaGrid()
        {
            dgvDados.DataSource = bll.Preencher();
            dtpData.Enabled = false;
            //Data, hora entrada, hora saída, disciplina, aluno, sala, serie

            dgvDados.Columns[0].HeaderText = "Data";
            dgvDados.Columns[0].Width = 80;
            dgvDados.Columns[1].HeaderText = "Entrada";
            dgvDados.Columns[1].Width = 50;
            dgvDados.Columns[2].HeaderText = "Saida";
            dgvDados.Columns[2].Width = 50;
            dgvDados.Columns[3].HeaderText = "Disciplina";
            dgvDados.Columns[3].Width = 80;
            dgvDados.Columns[4].HeaderText = "Aluno(a)";
            dgvDados.Columns[4].Width = 200;
            dgvDados.Columns[5].HeaderText = "Sala";
            dgvDados.Columns[5].Width = 55;
            dgvDados.Columns[6].HeaderText = "Serie";
            dgvDados.Columns[6].Width = 55;
            dgvDados.Columns[7].HeaderText = "Turma";
            dgvDados.Columns[7].Width = 55;
        }

        private void frmConsultaAula_Load(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void dgvDados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dtpData.Value = Convert.ToDateTime(dgvDados.Rows[e.RowIndex].Cells[0].Value);
                maskEntrada.Text = Convert.ToString(dgvDados.Rows[e.RowIndex].Cells[1].Value);
                maskSaida.Text = Convert.ToString(dgvDados.Rows[e.RowIndex].Cells[2].Value);
                //cbDisciplina.SelectedText = Convert.ToString(dgvDados.Rows[e.RowIndex].Cells[3].Value);
                txtDisciplina.Text = Convert.ToString(dgvDados.Rows[e.RowIndex].Cells[3].Value);
                //cbProfessor.SelectedValue = Convert.ToString(dgvDados.Rows[e.RowIndex].Cells[4].Value);
                txtProfessor.Text = Convert.ToString(dgvDados.Rows[e.RowIndex].Cells[4].Value);
                //cbSala.SelectedValue = Convert.ToString(dgvDados.Rows[e.RowIndex].Cells[5].Value);
                txtSala.Text = Convert.ToString(dgvDados.Rows[e.RowIndex].Cells[5].Value);
                //cbSerie.SelectedValue = Convert.ToString(dgvDados.Rows[e.RowIndex].Cells[6].Value);
                txtSerie.Text = Convert.ToString(dgvDados.Rows[e.RowIndex].Cells[6].Value);
                txtTurma.Text = Convert.ToString(dgvDados.Rows[e.RowIndex].Cells[7].Value);
            }
            catch
            {
                MessageBox.Show("Não é possível selecionar a coluna, apenas a linha.", "Aviso");
            }
        }
    }
}
