using Microsoft.AspNet.Identity;
using SendWithUs.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace WebApi.Services
{
    public class EmailService : IIdentityMessageService
    {
        public async Task SendAsync(IdentityMessage message)
        {
            await configSendGridasync(message);
        }
        
        /// <summary>
        /// Nos permite configurar todo lo necesario para el envio del correo
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private async Task configSendGridasync(IdentityMessage message)
        {
            var data = new Dictionary<string, string>
            {
                {
                    "text_message", message.Body
                }                

            };

            var TemplateId = ConfigurationManager.AppSettings["emailService:Template_Id"];
            var KeyId = ConfigurationManager.AppSettings["emailService:Key_Api"];

            var request = new SendRequest(TemplateId, message.Destination, data);
            var client = new SendWithUsClient(KeyId);
            var response = await client.SendAsync(request);
        }
    }
}