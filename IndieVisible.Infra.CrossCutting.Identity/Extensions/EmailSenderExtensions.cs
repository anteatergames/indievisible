using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace IndieVisible.Infra.CrossCutting.Identity.Services
{
    public static class EmailSenderExtensions
    {
        public static Task SendEmailConfirmationAsync(this IEmailSender emailSender, string email, string link)
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

            return emailSender.SendEmailAsync(email, "d-0be6280da017483fb8f759ec3d3c8797", request);
        }
        public static Task SendEmailPasswordResetAsync(this IEmailSender emailSender, string email, string link)
        {
            EmailSendRequest request = new EmailSendRequest
            {
                ActionUrl = link,
                TextBeforeAction = "You requested for a password reset. Click the button below and choose a new password.",
                TextAfterAction = "Do not share your password with anyone."
            };

            return emailSender.SendEmailAsync(email, "d-a440f7da0dc04eca98ee514b100ccde7", request);
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
