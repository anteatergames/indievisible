using IndieVisible.Infra.CrossCutting.Abstractions;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace IndieVisible.Infra.CrossCutting.Identity.Services
{
    public static class EmailSenderExtensions
    {
        public static Task SendEmailConfirmationAsync(this INotificationSender notificationSender, string email, string link)
        {
            EmailSendRequest request = new EmailSendRequest
            {
                ActionUrl = HtmlEncoder.Default.Encode(link),
                ActionText = "Confirm your email",
                Greeting = "Hi there,",
                TextBeforeAction = "You just registered yourself at INDIEVISIBLE community. Now you need to confirm your email.",
                TextAfterAction = "After confirmation you will be able to enjoy interacting with other fellow game developers.",
                ByeText = "And welcome to YOUR community."
            };

            return notificationSender.SendEmailAsync(email, "d-186b082218114c889a72a197c6ec2fa3", request);
        }

        public static Task SendEmailPasswordResetAsync(this INotificationSender notificationSender, string email, string link)
        {
            EmailSendRequest request = new EmailSendRequest
            {
                ActionUrl = link,
                TextBeforeAction = "You requested for a password reset. Click the button below and choose a new password.",
                TextAfterAction = "Do not share your password with anyone."
            };

            return notificationSender.SendEmailAsync(email, "d-d0224f347d57420bb39a025787b6443a", request);
        }

        public class EmailSendRequest
        {
            public string ActionUrl { get; set; }
            public string ActionText { get; set; }
            public string Greeting { get; set; }
            public string TextBeforeAction { get; set; }
            public string TextAfterAction { get; set; }
            public string ByeText { get; set; }
        }
    }
}