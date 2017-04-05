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
    public partial class frmCadastroMultiplo : Form
    {
        public frmCadastroMultiplo()
        {
            InitializeComponent();
        }
        private void CarregaComboBox()
        {
            //ComboBox Professor
            ProfessorBLL professorbll = new ProfessorBLL();
            cbbProfessor.DataSource = professorbll.Preencher();
            cbbProfessor.DisplayMember = "nome";
            cbbProfessor.ValueMember = "id";
            //ComboBox Disciplina
            DisciplinaBLL disciplinabll = new DisciplinaBLL();
            cbbDisciplina.DataSource = disciplinabll.Preencher();
            cbbDisciplina.DisplayMember = "nome";
            cbbDisciplina.ValueMember = "id";
            //ComboBox Sala
            SalaBLL salabll = new SalaBLL();
            cbbSala.DataSource = salabll.Preencher();
            cbbSala.DisplayMember = "nome";
            cbbSala.ValueMember = "id";
            //ComboBox Serie
            SerieBLL seriebll = new SerieBLL();
            cbbSerie.DataSource = seriebll.Preencher();
            cbbSerie.DisplayMember = "nome";
            cbbSerie.ValueMember = "id";
            //ComboBox Turma
            TurmaBLL turmabll = new TurmaBLL();
            cbbTurma.DataSource = turmabll.Preencher();
            cbbTurma.DisplayMember = "nome";
            cbbTurma.ValueMember = "id";
        }
        private void LimpaTela(int op)
        {
            if (op == 1)
            {
                txtSala.Clear();
                txtSerie.Clear();
                txtTurma.Clear();
            }
            if (op == 2)
                txtProfessor.Clear();
            if (op == 3)
                txtDisciplina.Clear();
            if (op == 4)
            {
                dtpData.Value = DateTime.Now;
                mtbEntrada.Clear();
                mtbSaida.Clear();
            }
        }
        private void btCadastrarTurma_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSala.Text))
            {
                SalaDTO dto = new SalaDTO();
                SalaBLL bll = new SalaBLL();

                string sala = txtSala.Text.Replace("'", "''");

                dto.Nome = sala;

                bll.Inserir(dto);
                MessageBox.Show("Cadastro efetuado com sucesso!", "Sucesso");
                LimpaTela(1);
            }
            else if (!string.IsNullOrEmpty(txtSerie.Text))
            {
                SerieBLL bll = new SerieBLL();
                SerieDTO dto = new SerieDTO();

                string serie = txtSerie.Text.Replace("'", "''");

                dto.Nome = serie;

                bll.Inserir(dto);
                MessageBox.Show("Cadastro efetuado com sucesso!", "Sucesso");
                LimpaTela(1);
            }
            else if (!string.IsNullOrEmpty(txtTurma.Text))
            {
                TurmaBLL bll = new TurmaBLL();
                TurmaDTO dto = new TurmaDTO();

                string turma = txtTurma.Text.Replace("'", "''");

                dto.Nome = turma;
                bll.Inserir(dto);
                MessageBox.Show("Cadastro efetuado com sucesso!", "Sucesso");
                LimpaTela(1);
            }
            else
            {
                MessageBox.Show("Por favor preencha um ou mais campos antes de cadastrar.", "Aviso");
                return;
            }
        }

        private void btCadastrarAula_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(mtbEntrada.Text) || string.IsNullOrEmpty(mtbSaida.Text))
            {
                MessageBox.Show("Por favor preencha todos os campos.", "Aviso");
                return;
            }
            else
            {
                AulaBLL bll = new AulaBLL();
                AulaDTO dto = new AulaDTO();

                dto.Data = dtpData.Value;
                dto.HoraEntrada = mtbEntrada.Text;
                dto.HoraSaida = mtbSaida.Text;
                dto.Cod_Disciplina = Convert.ToInt16(cbbDisciplina.SelectedValue);
                dto.Cod_Professor = Convert.ToInt16(cbbProfessor.SelectedValue);
                dto.Cod_Sala = Convert.ToInt16(cbbSala.SelectedValue);
                dto.Cod_Serie = Convert.ToInt16(cbbSerie.SelectedValue);
                dto.Cod_Turma = Convert.ToInt16(cbbTurma.SelectedValue);

                bll.Inserir(dto);
                MessageBox.Show("Cadastro efetuado com sucesso!", "Sucesso");
                LimpaTela(4);
            }
        }

        private void frmCadastroMultiplo_Load(object sender, EventArgs e)
        {
            dtpData.Value = DateTime.Now;
            CarregaComboBox();
        }

        private void btCadastrarDisciplina_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDisciplina.Text))
            {
                DisciplinaBLL bll = new DisciplinaBLL();
                DisciplinaDTO dto = new DisciplinaDTO();

                string nome = txtDisciplina.Text.Replace("'", "''");

                dto.Nome = txtDisciplina.Text;

                bll.Inserir(dto);
                MessageBox.Show("Cadastro efetuado com sucesso!", "Sucesso");
                LimpaTela(3);
                return;
            }
            MessageBox.Show("Por favor preencha o campo.", "Aviso");
            return;
        }

        private void btCadastrarProfessor_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtProfessor.Text))
            {
                ProfessorBLL bll = new ProfessorBLL();
                ProfessorDTO dto = new ProfessorDTO();

                string nome = txtProfessor.Text.Replace("'", "''");

                dto.Nome = nome;
                bll.Inserir(dto);
                MessageBox.Show("Cadastro efetuado com sucesso!", "Sucesso");
                LimpaTela(2);
                return;
            }
            MessageBox.Show("Por favor preencha o campo.", "Aviso");
            return;
        }
    }
}
