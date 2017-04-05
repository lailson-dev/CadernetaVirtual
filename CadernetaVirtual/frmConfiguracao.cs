using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CadernetaVirtual
{
    public partial class frmConfiguracao : Form
    {
        private string caminho = @"Configuração.txt";
        private string arquivo;
        private string mensagem;
        public frmConfiguracao()
        {
            InitializeComponent();
        }

        private void btSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            Criar();
        }
        private void frmConfiguracao_Load(object sender, EventArgs e)
        {
            txtServidor.Focus();
            MetodoParaLerLinhaArquivo();
        }
        private void Criar()
        {
            string servidor = txtServidor.Text;
            string banco = txtBancoDados.Text;
            string user = txtUsuario.Text;
            string pwd = txtSenha.Text;

            try
            {
                //Usarei a cláusula using como boas práticas de programação em todos os métodos
                //Instancio a classe FileStream, uso a classe File e o método Create para criar o
                //arquivo passando como parâmetro a variável strPathFile, que contém o arquivo
                using (FileStream fs = File.Create(caminho))
                {
                    //Crio outro using, dentro dele instancio o StreamWriter (classe para gravar os dados)
                    //que recebe como parâmetro a variável fs, referente ao FileStream criado anteriormente
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        //Uso o método Write para escrever algo em nosso arquivo texto
                        sw.Write(@"Data Source={0};Initial Catalog={1};Persist Security info=true;user={2};password={3}", servidor, banco, user, pwd);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //Se tudo ocorrer bem, exibo a mensagem ao usuário.
            MessageBox.Show("Arquivo criado com sucesso!!!");
        }
        private void MetodoParaLerLinhaArquivo()
        {
            List<string> mensagemLinha = new List<string>();

            //using (OpenFileDialog openFileDialog = new OpenFileDialog())
            //{
            //    openFileDialog.Title = "xxxxxxxxxo";
            //    openFileDialog.InitialDirectory = @"C:\Users\Familia\Documents\Visual Studio 2013\Projects\CadernetaVirtual\CadernetaVirtual\bin\Debug"; //Se ja quiser em abrir em um diretorio especifico
            //    openFileDialog.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
            //    openFileDialog.FilterIndex = 2;
            //    openFileDialog.RestoreDirectory = true;
            //    if (openFileDialog.ShowDialog() == DialogResult.OK)
            //    {
            //        arquivo = openFileDialog.FileName;
            //    }
            //    if (String.IsNullOrEmpty(arquivo))
            //    {
            //        MessageBox.Show("Arquivo Invalido", "Salvar Como", MessageBoxButtons.OK);
            //    }
            //    else
            //    {
            using (StreamReader texto = new StreamReader(caminho))
            {
                while ((mensagem = texto.ReadLine()) != null)
                {
                    mensagemLinha.Add(mensagem);
                }
            }
            int registro = mensagemLinha.Count; //total de linhas do arquivo.
            for (int i = 0; i < mensagemLinha.Count; i++)
            {
                txtTeste.Text += mensagemLinha[i];
                File.WriteAllText(caminho, mensagemLinha[i]);
            }
            //Data Source=.\SQLEXPRESS;Initial Catalog=SisGalileu;Persist Security info=true;user=sa;password=414541111111111        

            int servidor = txtTeste.Text.IndexOf("", txtTeste.Text.IndexOf('='));
            var server = txtTeste.Text.Substring(servidor + 1, txtTeste.Text.IndexOf(';', servidor + 1) - servidor - 1);

            var initial = ";Initial Catalog=";
            var tamanho = servidor + server.Length + initial.Length;

            //int bancodedados = txtTeste.Text.IndexOf(tamanho, txtTeste.Text.IndexOf('='));            
            var banco = txtTeste.Text.Substring(tamanho + 1, txtTeste.Text.IndexOf(';', tamanho + 1) - tamanho - 1);

            var persist = ";Persist Security info=true;user=";
            var tamanho2 = tamanho + banco.Length + persist.Length;

            var user = txtTeste.Text.Substring(tamanho2 + 1, txtTeste.Text.IndexOf(';', tamanho2 + 1) - tamanho2 - 1);

            var ultimo = ";password=";
            var tamanho3 = tamanho2 + user.Length + ultimo.Length;

            txtServidor.Text = server;
            txtBancoDados.Text = banco;
            txtUsuario.Text = user;
            txtSenha.Text = txtTeste.Text.Substring(tamanho3 + 1);
        }
        //  }
        //}
    }
}
