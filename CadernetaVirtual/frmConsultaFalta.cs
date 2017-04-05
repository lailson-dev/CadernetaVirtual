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
    public partial class frmConsultaFalta : Form
    {
        FaltaDTO dto = new FaltaDTO();
        FaltaBLL bll = new FaltaBLL();
        private string opcao = string.Empty;
        public frmConsultaFalta()
        {
            InitializeComponent();
        }
        private void LimpaTela()
        {
            foreach (var item in groupBox1.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Text = string.Empty;
                }
                else if (item is DateTimePicker)
                {
                    ((DateTimePicker)item).Value = DateTime.Now;
                }
            }
        }
        private void CarregaComboBox()
        {
            dtpData.Enabled = false;
            //id, data, presente, ausente, aluno, disciplina, responsavel            

            dgvDados.Columns[0].HeaderText = "ID";
            dgvDados.Columns[0].Width = 30;
            dgvDados.Columns[1].HeaderText = "Aluno(a)";
            dgvDados.Columns[1].Width = 225;
            if (rbPresencas.Checked == true)
                dgvDados.Columns[2].HeaderText = "Presença";
            else
                dgvDados.Columns[2].HeaderText = "Ausências";
            dgvDados.Columns[2].Width = 80;
            dgvDados.Columns[3].HeaderText = "Disciplina";
            dgvDados.Columns[3].Width = 80;
            dgvDados.Columns[4].HeaderText = "Professor";
            dgvDados.Columns[4].Width = 180;
        }
        private void frmConsultaFalta_Load(object sender, EventArgs e)
        {
            btPesquisar_Click(sender, e);
            CarregaComboBox();
        }
        private void btPesquisar_Click(object sender, EventArgs e)
        {
            if (rbPresencas.Checked == true)
                opcao = "presenças";
            else if (rbAusencias.Checked == true)
                opcao = "ausencias";
            //else if (rbDisciplinas.Checked == true)
            //    opcao = "disciplinas";
            else
                opcao = "datas";

            dgvDados.DataSource = bll.Preencher(txtAluno.Text, opcao);
            opcao = string.Empty;
        }
        private void dgvDados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            LimpaTela();

            try
            {
                if (rbPresencas.Checked == true || rbAusencias.Checked == true)
                {
                    txtMatricula.Text = Convert.ToString(dgvDados.Rows[e.RowIndex].Cells[0].Value);
                    txtAluno.Text = Convert.ToString(dgvDados.Rows[e.RowIndex].Cells[1].Value);
                    txtPresencaAusencia.Text = Convert.ToString(dgvDados.Rows[e.RowIndex].Cells[2].Value);
                    txtDisciplina.Text = Convert.ToString(dgvDados.Rows[e.RowIndex].Cells[3].Value);
                    txtProfessor.Text = Convert.ToString(dgvDados.Rows[e.RowIndex].Cells[4].Value);
                }
                else if (rbDatas.Checked == true)
                {
                    txtMatricula.Text = Convert.ToString(dgvDados.Rows[e.RowIndex].Cells[0].Value);
                    txtAluno.Text = Convert.ToString(dgvDados.Rows[e.RowIndex].Cells[1].Value);
                    txtPresencaAusencia.Text = Convert.ToString(dgvDados.Rows[e.RowIndex].Cells[2].Value);
                    txtDisciplina.Text = Convert.ToString(dgvDados.Rows[e.RowIndex].Cells[3].Value);
                    txtProfessor.Text = Convert.ToString(dgvDados.Rows[e.RowIndex].Cells[4].Value);
                    dtpData.Value = Convert.ToDateTime(dgvDados.Rows[e.RowIndex].Cells[5].Value);
                }
            }
            catch
            {
                MessageBox.Show("Não é possível selecionar a coluna, somente a linha.", "Aviso");
            }
        }
    }
}
