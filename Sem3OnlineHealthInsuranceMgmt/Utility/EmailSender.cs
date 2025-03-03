using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Sem3OnlineHealthInsuranceMgmt.Utilities;

public class EmailSender : IEmailSender {
    public string SendGridSecret { get; set; }

    public EmailSender(IConfiguration _config) {
        SendGridSecret = _config.GetValue<string>("SendGrid:SecretKey");
    }

    public Task SendEmailAsync(string email, string subject, string htmlMessage) {
        //logic to send email

        var client = new SendGridClient(SendGridSecret);

        var from = new EmailAddress("hello@gmail.com", "InsuranceMgmt");
        var to = new EmailAddress(email);
        var message = MailHelper.CreateSingleEmail(from, to, subject, "", htmlMessage);

        return client.SendEmailAsync(message);


    }
}
