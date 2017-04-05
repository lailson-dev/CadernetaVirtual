using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DTO;
using System.IO;

namespace CadernetaVirtual
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void alunoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastroAluno aluno = new frmCadastroAluno();
            aluno.ShowDialog();
            aluno.Dispose();
        }

        private void turmaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastroMultiplo multiplo = new frmCadastroMultiplo();
            multiplo.ShowDialog();
            multiplo.Dispose();
        }

        private void frequênciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastroFalta falta = new frmCadastroFalta();
            falta.ShowDialog();
            falta.Dispose();
        }

        private void aulaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmConsultaAula aula = new frmConsultaAula();
            aula.ShowDialog();
            aula.Dispose();
        }

        private void alunoaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmConsultaAluno aluno = new frmConsultaAluno();
            aluno.ShowDialog();
            aluno.Dispose();
        }

        private void frequênciaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmConsultaFalta falta = new frmConsultaFalta();
            falta.ShowDialog();
            falta.Dispose();
        }

        private void notificarOResponsávelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNotificar notificar = new frmNotificar();
            notificar.ShowDialog();
            notificar.Dispose();
        }

        private void blocoDeNotasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("notepad.exe");
        }

        private void calculadoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc.exe");
        }

        private void explorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe");
        }

        private void aToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSobre sobre = new frmSobre();
            sobre.ShowDialog();
            sobre.Dispose();
        }

        private void relatarUmBugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRelatarErro erro = new frmRelatarErro();
            erro.ShowDialog();
            erro.Dispose();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            Abrir();
        }
        private void Abrir()
        {
            try
            {
                DadosConexao.StringConexao = System.IO.File.ReadAllText(@"Configuração.txt");
            }
            catch
            {
                MessageBox.Show("Não há conexão com o banco de dados. Vá para Configurações > Banco de dados > Configurar e informe a conexão com o servidor.", "Conexão perdida");
            }
        }

        private void configurarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConfiguracao configurar = new frmConfiguracao();
            configurar.ShowDialog();
            configurar.Dispose();
        }
        private void finalizarSessãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
            frmLogin f = new frmLogin();
            f.ShowDialog();
        }

        private void cadastrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastroUsuario user = new frmCadastroUsuario();
            user.ShowDialog();
            user.Dispose();
        }

        private void frmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
