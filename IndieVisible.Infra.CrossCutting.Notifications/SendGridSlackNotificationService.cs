using IndieVisible.Infra.CrossCutting.Abstractions;
using IndieVisible.Infra.CrossCutting.Notifications.Slack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Net;
using System.Threading.Tasks;

namespace IndieVisible.Infra.CrossCutting.Notifications
{
    public class SendGridSlackNotificationService : INotificationSender
    {
        private readonly IConfiguration configuration;
        private readonly ILogger logger;

        public SendGridSlackNotificationService(IConfiguration configuration, ILogger<SendGridSlackNotificationService> logger)
        {
            this.configuration = configuration;
            this.logger = logger;
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            string apiKey = Environment.GetEnvironmentVariable("SENDGRID_APIKEY");
            if (string.IsNullOrEmpty(apiKey))
            {
                apiKey = configuration.GetSection("SENDGRID_APIKEY").Value;
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
                apiKey = configuration.GetSection("SENDGRID_APIKEY").Value;
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

        public Task SendTeamNotificationAsync(string message)
        {
            SlackMessage slackMessage = new SlackMessage(message);

            RestClient client = new RestClient("https://hooks.slack.com/services/TEH1D2GF4/B0123NPCQDD");

            RestRequest request = new RestRequest("/M2YMReQBumxAp2DrHhdVDI9p", Method.POST);

            DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            string jsonToSend = JsonConvert.SerializeObject(slackMessage, new JsonSerializerSettings
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented
            });

            request.AddParameter("application/json; charset=utf-8", jsonToSend, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            try
            {
                client.ExecuteAsync(request, response =>
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        logger.LogInformation("Notification sent");
                    }
                    else
                    {
                        string jsonResponse = JsonConvert.SerializeObject(response);
                        logger.LogWarning(jsonResponse);
                    }
                });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error on sending notification to Slack");
            }

            return Task.CompletedTask;
        }
    }
}