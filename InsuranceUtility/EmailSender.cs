namespace InsuranceUtility;

public class EmailSender : Microsoft.AspNetCore.Identity.UI.Services.IEmailSender 
{
    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        return Task.CompletedTask;
    }
}