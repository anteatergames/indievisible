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
                ActionUrl = link,
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

        public static Task SendEmailApplicationAsync(this INotificationSender notificationSender, string emailPoster, string emailApplicant, string link)
        {
            EmailSendRequest request = new EmailSendRequest
            {
                ActionUrl = link,
                ActionText = "Go to the job position",
                Greeting = "Hi there",
                TextBeforeAction = string.Format("We have great news! Recently you posted a job position on the INDIEVISIBLE Jobs and now someone applied to the job position you posted. The applicant's email is {0}", emailApplicant),
                TextAfterAction = "Log in to the INDIEVISIBLE platform to evaluate the applicants.",
                ByeText = "Thank you for helping the game development industry. We hope you find a good collaborator so we all can grow together."
            };

            return notificationSender.SendEmailAsync(emailPoster, "d-826fd97ae44d409f85408d64918c7be8", request);
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