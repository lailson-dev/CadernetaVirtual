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
    public partial class frmCadastroUsuario : Form
    {
        UsuarioDTO dto = new UsuarioDTO();
        UsuarioBLL bll = new UsuarioBLL();
        string verificou;
        public frmCadastroUsuario()
        {
            InitializeComponent();
        }

        private void btCadastrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUser.Text) && string.IsNullOrEmpty(txtSenha.Text) && string.IsNullOrEmpty(txtConfirmaSenha.Text) && string.IsNullOrEmpty(txtNome.Text))
            {
                MessageBox.Show("Os campos não podem ficar em branco.", "Aviso");
            }
            else if (txtSenha.Text != txtConfirmaSenha.Text || string.IsNullOrEmpty(txtSenha.Text) || string.IsNullOrEmpty(txtConfirmaSenha.Text))
            {
                MessageBox.Show("Por favor, verifique se as senhas foram digitadas corretamente", "Aviso");
            }
            else
            {
                if (VerificaNome(txtUser.Text) == false)
                {
                    string nome = txtNome.Text.Replace("'", "''");
                    string modificado = txtUser.Text.Replace("'", "''");
                    dto.Usuario = modificado;
                    dto.Senha = txtSenha.Text;
                    dto.Nome = nome;
                    bll.Inserir(dto);
                    MessageBox.Show("Cadastro efetuado com sucesso!", "Sucesso");
                    txtUser.Clear();
                    txtSenha.Clear();
                    txtConfirmaSenha.Clear();
                    txtNome.Clear();
                }
                else
                {
                    MessageBox.Show("O usuário informado já existe no banco de dados.", "Aviso");
                }
            }
        }
        private bool VerificaNome(string nome)
        {
            dto = bll.VerificaUsuario(nome);
            if (dto.Nome != null)
                return true;
            else
                return false;
        }

        private void frmCadastroUsuario_Load(object sender, EventArgs e)
        {
            txtNome.Focus();
        }
    }
}
