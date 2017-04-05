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
    public partial class frmCadastroFalta : Form
    {
        AlunoBLL bll = new AlunoBLL();
        AlunoDTO dto = new AlunoDTO();
        public string decisao;
        public int total;
        public frmCadastroFalta()
        {
            InitializeComponent();
        }
        public void VerificaRadioButton()
        {
            if (rbPresencas.Checked == true)
            {
                decisao = "presente";
                return;
            }
            if (rbAusencias.Checked == true)
                decisao = "ausente";
        }
        private void CarregaComboBox()
        {
            ProfessorBLL professor = new ProfessorBLL();
            cbbProfessor.DataSource = professor.Preencher();
            cbbProfessor.DisplayMember = "nome";
            cbbProfessor.ValueMember = "id";
            DisciplinaBLL disciplina = new DisciplinaBLL();
            cbbDisciplina.DataSource = disciplina.Preencher();
            cbbDisciplina.DisplayMember = "nome";
            cbbDisciplina.ValueMember = "id";
        }
        private void CarregaGrid()
        {
            dgvDados.DataSource = bll.Preencher(dto);

            dgvDados.Columns[0].HeaderText = "ID";
            dgvDados.Columns[0].Width = 30;
            dgvDados.Columns[1].HeaderText = "Aluno(a)";
            dgvDados.Columns[1].Width = 200;
            dgvDados.Columns[2].HeaderText = "Responsável";
            dgvDados.Columns[2].Width = 150;
            dgvDados.Columns[3].HeaderText = "Sala";
            dgvDados.Columns[3].Width = 55;
            dgvDados.Columns[4].HeaderText = "Serie";
            dgvDados.Columns[4].Width = 55;
            dgvDados.Columns[5].HeaderText = "Turma";
            dgvDados.Columns[5].Width = 55;
        }
        private void LimpaTela()
        {
            txtMatricula.Clear();
            txtAluno.Clear();
            cbbDisciplina.SelectedIndex = 0;
            cbbProfessor.SelectedIndex = 0;
            rbPrensente.Checked = true;
            rbPresencas.Checked = true;
        }
        private void frmCadastroFalta_Load(object sender, EventArgs e)
        {
            dtpData.Value = DateTime.Now;
            CarregaGrid();
            CarregaComboBox();
        }
        private void btPesquisar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtAluno.Text))
            {
                string nome = txtAluno.Text.Replace("'", "''");
                dto.Nome = nome;
                dgvDados.DataSource = bll.Preencher(dto);
                return;
            }
        }
        private void dgvDados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtMatricula.Text = Convert.ToString(dgvDados.Rows[e.RowIndex].Cells[0].Value);
                txtAluno.Text = Convert.ToString(dgvDados.Rows[e.RowIndex].Cells[1].Value);
            }
            catch { MessageBox.Show("Por favor, selecione a célula e não a coluna.", "Aviso"); }
        }
        private void btCadastrar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMatricula.Text) && !string.IsNullOrEmpty(txtAluno.Text))
            {
                FaltaBLL faltasbll = new FaltaBLL();
                FaltaDTO faltasdto = new FaltaDTO();

                faltasdto.Data = Convert.ToDateTime(dtpData.Value.ToShortDateString());
                if (rbPrensente.Checked == true)
                {
                    int presente = 1;
                    faltasdto.Presente = presente;
                }
                else
                {
                    int ausente = 1;
                    faltasdto.Ausente = ausente;
                }
                faltasdto.Cod_ID_Aluno = Convert.ToInt16(txtMatricula.Text);
                faltasdto.Cod_Disciplina = Convert.ToInt16(cbbDisciplina.SelectedIndex + 1);
                faltasdto.Cod_Professor = Convert.ToInt16(cbbProfessor.SelectedIndex + 1);

                faltasbll.Inserir(faltasdto);
                MessageBox.Show("Cadastro efetuado com sucesso!", "Sucesso");
                LimpaTela();
                return;
            }
            MessageBox.Show("Por favor dê um duplo click no nome de um(a) aluno(a).", "Aviso");
            return;
        }
        private void btVisualizar_Click(object sender, EventArgs e)
        {
            FrequenciaBLL fbll = new FrequenciaBLL();
            FrequenciaDTO fdto = new FrequenciaDTO();

            VerificaRadioButton();

            if (txtMatricula.Text == string.Empty)
            {
                MessageBox.Show("Por favor, selecione um(a) aluno(a).", "Na moral pai");
                return;
            }
            else
            {
                fdto = fbll.Localizar(decisao, Convert.ToInt32(txtMatricula.Text));
                if (rbPresencas.Checked == true && fdto.Presente != 0)
                {
                    total = fdto.Presente;

                    MessageBox.Show("" + total.ToString() + " presenças até o momento.", "Presenças", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;

                }
                else if (rbPresencas.Checked == true && fdto.Presente == 0)
                {
                    MessageBox.Show("Nenhuma presença foi cadastrada até o momento.", "Ops");
                    return;
                }
                else if (rbAusencias.Checked == true && fdto.Ausente != 0)
                {
                    total = fdto.Ausente;

                    MessageBox.Show("" + total.ToString() + " faltas até o momento.", "Ausências", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    MessageBox.Show("Nenhuma ausencia foi cadastrada até o momento.", "Ops");
                    return;
                }
            }
        }
    }
}
