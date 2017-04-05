using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace CadernetaVirtual
{
    public partial class frmRelatarErro : Form
    {
        public frmRelatarErro()
        {
            InitializeComponent();
        }
        private void btEnviar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDescricao.Text) && !string.IsNullOrEmpty(txtQntd.Text))
            {
                try
                {
                    MailMessage mail = new MailMessage();

                    mail.From = new MailAddress("meuemail@email.com.br");
                    mail.To.Add("paraemail@email.com.br"); // para
                    mail.Subject = "ENCONTREI UM ERRO"; // assunto
                    mail.IsBodyHtml = true;
                    mail.Body = txtDescricao.Text + "</br></br></br>" + "Quantas vezes isso já aconteceu? " + txtQntd.Text + " vezes"; // mensagem

                    // em caso de anexos
                    //mail.Attachments.Add(new Attachment(@"C:\teste.txt"));

                    var smtp = new SmtpClient("smtp.live.com");

                    smtp.EnableSsl = true; // GMail requer SSL
                    smtp.Port = 587;       // porta para SSL
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network; // modo de envio
                    smtp.UseDefaultCredentials = false; // vamos utilizar credencias especificas

                    // seu usuário e senha para autenticação
                    smtp.Credentials = new NetworkCredential("meuemail@email.com.br", "minhasenha");

                    // envia o e-mail
                    smtp.Send(mail);

                    MessageBox.Show("E-mail enviado com sucesso!", "Sucesso");
                    txtDescricao.Clear();
                    txtQntd.Clear();
                }
                catch (SmtpException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Por favor, verifique se os campos estão preenchidos.", "Aviso");
            }
        }
        private void txtQntd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
    }
}
