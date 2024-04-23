using SendGrid.Helpers.Mail;
using SendGrid;
using System;
using System.Threading.Tasks;

namespace EffizyMusicSystem.Services
{
    public class EmailService : IEmailService
    {
        private readonly string _apiKey;
        public EmailService()
        {
            _apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
        }
        public async Task SendApprovalEmailAsync(string recipientEmail)
        {
            try
            {
                var client = new SendGridClient(_apiKey);
                var from = new EmailAddress("efizzymusic.ca@gmail.com", "EfizzyMusic Administrator");
                var to = new EmailAddress(recipientEmail);
                var subject = "Approval Notification";
                var plainTextContent = "Congratulations! Your instructor account has been approved.";
                var htmlContent = "<strong>Congratulations!</strong> Your instructor account has been approved.";
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                var response = await client.SendEmailAsync(msg);

                // Log success message
                Console.WriteLine("Approval email sent successfully.");
            }
            catch (Exception ex)
            {
                // Log error message
                Console.WriteLine($"Error sending approval email: {ex.Message}");
            }
        }

        public async Task SendRejectionEmailAsync(string recipientEmail)
        {
            try
            {
                var client = new SendGridClient(_apiKey);
                var from = new EmailAddress("efizzymusic.ca@gmail.com", "EfizzyMusic Administrator");
                var to = new EmailAddress(recipientEmail);
                var subject = "Rejection Notification";
                var plainTextContent = "We regret to inform you that your instructor account has been rejected.";
                var htmlContent = "<strong>We regret to inform you</strong> that your instructor account has been rejected.";
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                var response = await client.SendEmailAsync(msg);

                // Log success message
                Console.WriteLine("Rejection email sent successfully.");
            }
            catch (Exception ex)
            {
                // Log error message
                Console.WriteLine($"Error sending rejection email: {ex.Message}");
            }
        }

        public async Task SendEmailAsync(string recipientEmail, string subject, string message)
        {
            try
            {
                var client = new SendGridClient(_apiKey);
                var from = new EmailAddress("efizzymusic.ca@gmail.com", "EfizzyMusic Administrator");
                var to = new EmailAddress(recipientEmail);
                var plainTextContent = message;
                var htmlContent = message;
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                var response = await client.SendEmailAsync(msg);

                // Log success message
                Console.WriteLine("Email sent successfully.");
            }
            catch (Exception ex)
            {
                // Log error message
                Console.WriteLine($"Error sending email: {ex.Message}");
            }
        }
    }
}
