using Microsoft.AspNet.Identity;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace WebApi.Services
{
    /// <summary>
    /// Servicio que permite las notificaciones por correo electronico.
    /// </summary>
    public class EmailService : IIdentityMessageService
    {
        private SmtpClient smtpCliente = new SmtpClient();
        private NetworkCredential credential;
        private MailMessage message;
        private string host;
        private int port;
        private string accountEmail;

        /// <summary>
        /// Permite el envio de correos electronicos atravez de SMTP.
        /// </summary>
        /// <param name="accountEmail"></param>
        /// <param name="password"></param>
        public EmailService()
        {
            this.host = ConfigurationManager.AppSettings["emailService:host"];
            this.port = int.Parse(ConfigurationManager.AppSettings["emailService:port"]);
            string accountPass = ConfigurationManager.AppSettings["emailService:accountPass"];
            accountEmail = ConfigurationManager.AppSettings["emailService:accountEmail"];

            this.credential = new NetworkCredential(accountEmail, accountPass);
            this.smtpCliente.EnableSsl = true;
            this.smtpCliente.Credentials = this.credential;
            this.smtpCliente.Port = this.port;
            this.smtpCliente.Host = this.host;
        }

        public async Task SendAsync(IdentityMessage message)
        {
            this.message = new MailMessage(accountEmail, message.Destination);
            this.message.Body = message.Body;
            this.message.Subject = message.Subject;
            await Task.Run(() => this.smtpCliente.SendAsync(this.message, "Sending.."));
        }
    }
}