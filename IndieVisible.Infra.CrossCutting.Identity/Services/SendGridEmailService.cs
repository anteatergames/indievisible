using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IndieVisible.Infra.CrossCutting.Identity.Services
{
    public class SendGridEmailService : IEmailSender
    {


        private readonly IConfiguration _configuration;
        public SendGridEmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var apiKey = Environment.GetEnvironmentVariable("SENDGRID_APIKEY");
            if (string.IsNullOrEmpty(apiKey))
            {
                apiKey = _configuration.GetSection("SENDGRID_APIKEY").Value;
            }
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("slavebot@indievisible.net", "INDIEVISIBLE Community");

            var msg = new SendGridMessage()
            {
                From = from,
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };

            msg.AddTo(new EmailAddress(email));

            var response = await client.SendEmailAsync(msg);
        }
    }
}
