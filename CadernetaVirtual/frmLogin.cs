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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btEntrar_Click(object sender, EventArgs e)
        {
            UsuarioBLL bll = new UsuarioBLL();
            UsuarioDTO dto = new UsuarioDTO();

            if (bll.Autenticar(txtUsuario.Text, txtSenha.Text) > 0)
            {
                this.Hide();
                frmPrincipal f = new frmPrincipal();
                f.ShowDialog();
                this.Dispose();
            }
            else if (string.IsNullOrEmpty(txtUsuario.Text) && string.IsNullOrEmpty(txtSenha.Text))
            {
                MessageBox.Show("Por favor, preencha os campos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Erro ao logar no sistema.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btSair_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
        private void Abrir()
        {
            try
            {
                DTO.DadosConexao.StringConexao = System.IO.File.ReadAllText(@"Configuração.txt");
            }
            catch
            {
                MessageBox.Show("Não há conexão com o banco de dados. Vá para Configurações > Banco de dados > Configurar e informe a conexão com o servidor.", "Conexão perdida");
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            Abrir();
        }
    }
}
