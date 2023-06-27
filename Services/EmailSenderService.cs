using Portfolio.Models;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Portfolio.Interfaces
{
    public class EmailSenderService : IEmailService
    {
        private readonly IConfiguration configuration;

        public EmailSenderService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task Send(ContactDTO contact)
        {
            var apiKey = configuration.GetValue<string>("SENDGRID_API_KEY");
            var email = configuration.GetValue<string>("SENDGRID_FROM");
            var name = configuration.GetValue<string>("SENDGRID_NAME");

            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(email, name);
            var subject = $"The client {contact.name} wants to contact you";
            var to = new EmailAddress(email, name);
            var messagePlainText = contact.message;
            var htmlcontent = $@"De: {contact.name} - 
Email: {contact.email}
Mensaje: {contact.message}";

            var singleEmail = MailHelper.CreateSingleEmail(from, to, subject, messagePlainText, htmlcontent);

            var answer = await client.SendEmailAsync(singleEmail);
        }
    }
}
