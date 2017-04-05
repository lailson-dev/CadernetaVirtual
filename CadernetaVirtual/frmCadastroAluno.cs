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
    public partial class frmCadastroAluno : Form
    {
        AlunoDTO dto = new AlunoDTO();
        AlunoBLL bll = new AlunoBLL();
        public int codigo = 0;
        public frmCadastroAluno()
        {
            InitializeComponent();
        }
        private void AlteraBotoes(int op)
        {
            btInserir.Enabled = false;
            btAlterar.Enabled = false;
            btGravar.Enabled = false;
            btExcluir.Enabled = false;
            btPesquisar.Enabled = false;
            btCancelar.Enabled = false;
            groupBox1.Enabled = false;

            if (op == 0)//Form_Load
            {
                btInserir.Enabled = true;
                btPesquisar.Enabled = true;
            }
            if (op == 1)//Inserir
            {
                groupBox1.Enabled = true;
                btGravar.Enabled = true;
                btExcluir.Enabled = true;
                btCancelar.Enabled = true;
                txtAluno.Focus();
            }
            if (op == 2)//Alterar
            {
                groupBox1.Enabled = true;
                btCancelar.Enabled = true;
                btExcluir.Enabled = true;
                btGravar.Enabled = true;
                txtAluno.Focus();
            }
            if (op == 3)//Pesquisar
            {
                btAlterar.Enabled = true;
                btExcluir.Enabled = true;
                btCancelar.Enabled = true;
            }
        }
        private void LimpaTudo()
        {
            txtMatricula.Clear();
            txtAluno.Clear();
            txtResponsavel.Clear();
            cbbSala.SelectedIndex = 0;
            cbbSerie.SelectedIndex = 0;
            cbbTurma.SelectedIndex = 0;
        }
        private void frmCadastroAluno_Load(object sender, EventArgs e)
        {
            AlteraBotoes(0);
            CarregaComboBox();
        }

        private void btInserir_Click(object sender, EventArgs e)
        {
            AlteraBotoes(1);
            LimpaTudo();
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            LimpaTudo();
            AlteraBotoes(0);
        }

        private void btGravar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMatricula.Text))
            {
                if (!string.IsNullOrEmpty(txtAluno.Text))
                {
                    string aluno = txtAluno.Text.Replace("'", "''");

                    dto.Nome = aluno;
                    dto.Responsavel = txtResponsavel.Text;
                    dto.Cod_Sala = Convert.ToInt16(cbbSala.SelectedIndex + 1);
                    dto.Cod_Serie = Convert.ToInt16(cbbSerie.SelectedIndex + 1);
                    dto.Cod_Turma = Convert.ToInt16(cbbTurma.SelectedIndex + 1);

                    bll.Inserir(dto);
                    MessageBox.Show("Cadastro efetuado com sucesso!", "Sucesso");
                }
                MessageBox.Show("Por favor, informe o nome do(a) aluno(a).", "Aviso");
                return;
            }
            else
            {
                string aluno = txtAluno.Text.Replace("'", "''");

                dto.Id = Convert.ToInt16(txtMatricula.Text);
                dto.Nome = aluno;
                dto.Responsavel = txtResponsavel.Text;
                dto.Cod_Sala = Convert.ToInt16(cbbSala.SelectedIndex + 1);
                dto.Cod_Serie = Convert.ToInt16(cbbSerie.SelectedIndex + 1);
                dto.Cod_Turma = Convert.ToInt16(cbbTurma.SelectedIndex + 1);

                bll.Atualizar(dto);
                MessageBox.Show("Cadastro atualizado com sucesso!", "Sucesso");
            }
            LimpaTudo();
            AlteraBotoes(0);
        }

        private void CarregaComboBox()
        {
            //ComboBox Sala
            SalaBLL salabll = new SalaBLL();
            cbbSala.DataSource = salabll.Preencher();
            cbbSala.DisplayMember = "nome";
            cbbSala.ValueMember = "nome";
            //ComboBox Serie
            SerieBLL seriebll = new SerieBLL();
            cbbSerie.DataSource = seriebll.Preencher();
            cbbSerie.DisplayMember = "nome";
            cbbSerie.ValueMember = "nome";
            //ComboBox Turma
            TurmaBLL turmabll = new TurmaBLL();
            cbbTurma.DataSource = turmabll.Preencher();
            cbbTurma.DisplayMember = "nome";
            cbbTurma.ValueMember = "nome";
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            frmConsultaAluno f = new frmConsultaAluno();
            f.ShowDialog();
            if (f.codigo != 0)
            {
                AlunoDTO dto = bll.Pesquisar(f.codigo);
                txtMatricula.Text = Convert.ToString(dto.Id);
                txtAluno.Text = dto.Nome;
                txtResponsavel.Text = dto.Responsavel;
                cbbSala.SelectedIndex = dto.Cod_Sala - 1;
                cbbSerie.SelectedIndex = dto.Cod_Serie - 1;
                cbbTurma.SelectedIndex = dto.Cod_Turma - 1;
            }
            AlteraBotoes(3);
            f.Dispose();
        }

        private void btAlterar_Click(object sender, EventArgs e)
        {
            AlteraBotoes(2);
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja excluir esse registro?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dto.Id = Convert.ToInt16(txtMatricula.Text);
                bll.Excluir(dto);
                MessageBox.Show("Registro deletado com sucesso!", "Sucesso");
                LimpaTudo();
                AlteraBotoes(0);
            }
            return;
        }
    }
}
