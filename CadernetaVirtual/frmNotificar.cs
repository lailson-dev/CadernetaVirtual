using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace CadernetaVirtual
{
    public partial class frmNotificar : Form
    {
        private MailMessage Email;
        Stopwatch Stop = new Stopwatch();
        ResponsavelBLL bll = new ResponsavelBLL();
        DateTime data = DateTime.Now;
        public frmNotificar()
        {
            InitializeComponent();
        }

        private void frmNotificar_Load(object sender, EventArgs e)
        {
            string dataagora = string.Format(data.ToShortDateString());

            List<ResponsavelDTO> emailsdistintos = new List<ResponsavelDTO>();

            List<ResponsavelDTO> modelos = new List<ResponsavelDTO>();
            modelos = bll.Localizar((dataagora));
            emailsdistintos = modelos.Distinct().ToList();

            foreach (var modelo in emailsdistintos)
            {
                txtEmails.Text = string.Join(", ", modelo.EmailResponsavel.ToArray());
            }
        }

        private void btEnviar_Click(object sender, EventArgs e)
        {
            string dataagora = string.Format(data.ToShortDateString());
            List<ResponsavelDTO> modelos = bll.Localizar(dataagora);
            try
            {
                Email = new MailMessage();
                Email.From = (new MailAddress("paraemail@email.com.br"));
                if (!string.IsNullOrEmpty(txtEmails.Text))
                {
                    Email.To.Add(txtEmails.Text);
                    Email.Subject = "Alerta aos pais";
                    Email.IsBodyHtml = true;
                    Email.Body = "Olá, Sr(a), </br></br></br>comunico-o que o vosso filho não compareceu à escola hoje.</br></br></br>att,</br></br></br>a direção";
                    SmtpClient cliente = new SmtpClient("smtp.live.com", 587);
                    cliente.Credentials = new System.Net.NetworkCredential("meuemail@email.com.br", "senha");
                    cliente.EnableSsl = true;
                    cliente.Send(Email);

                    MessageBox.Show("E-mail enviado com sucesso!", "Sucesso");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Por favor, informe um e-mail", "Aviso");
                    return;
                }
            }
            catch (SmtpException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
