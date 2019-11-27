using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
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
            string apiKey = Environment.GetEnvironmentVariable("SENDGRID_APIKEY");
            if (string.IsNullOrEmpty(apiKey))
            {
                apiKey = _configuration.GetSection("SENDGRID_APIKEY").Value;
            }
            SendGridClient client = new SendGridClient(apiKey);
            EmailAddress from = new EmailAddress("slavebot@indievisible.net", "INDIEVISIBLE Community");

            SendGridMessage msg = new SendGridMessage()
            {
                From = from,
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };

            msg.AddTo(new EmailAddress(email));

            await client.SendEmailAsync(msg);
        }

        public async Task SendEmailAsync(string email, string templateId, object templateData)
        {
            string apiKey = Environment.GetEnvironmentVariable("SENDGRID_APIKEY");
            if (string.IsNullOrEmpty(apiKey))
            {
                apiKey = _configuration.GetSection("SENDGRID_APIKEY").Value;
            }
            SendGridClient client = new SendGridClient(apiKey);
            EmailAddress from = new EmailAddress("slavebot@indievisible.net", "INDIEVISIBLE Community");

            SendGridMessage msg = new SendGridMessage()
            {
                From = from,
                TemplateId = templateId
            };

            msg.SetTemplateData(templateData);

            msg.AddTo(new EmailAddress(email));

            await client.SendEmailAsync(msg);
        }
    }
}