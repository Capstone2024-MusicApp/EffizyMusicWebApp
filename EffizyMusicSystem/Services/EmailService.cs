using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Mail;
using SendGrid;
using System;
using System.Threading.Tasks;
using EffizyMusicSystem.DAL;

namespace EffizyMusicSystem.Services
{
    public class EmailService : IEmailService
    {
        private readonly EffizyMusicContext _context;

        public EmailService(EffizyMusicContext context)
        {
            _context = context;
        }

        public async Task<string> GetApiKeyAsync()
        {
            var apiKeyEntity = await _context.ApiKeyConfig.FirstOrDefaultAsync();
            if (apiKeyEntity == null)
            {
                throw new InvalidOperationException("API key not found in the database.");
            }
            return apiKeyEntity.Key;
        }

        public async Task SendApprovalEmailAsync(string recipientEmail)
        {
            try
            {
                var apiKey = await GetApiKeyAsync();
                var client = new SendGridClient(apiKey);
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
                var apiKey = await GetApiKeyAsync();
                var client = new SendGridClient(apiKey);
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
                var apiKey = await GetApiKeyAsync();
                var client = new SendGridClient(apiKey);
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
