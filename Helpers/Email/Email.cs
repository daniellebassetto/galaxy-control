using System.Net;
using System.Net.Mail;

namespace GalaxyControl.Helpers;

public class Email(IConfiguration configuration) : IEmail
{
    private readonly IConfiguration _configuration = configuration;

    public bool Send(string email, string subject, string message)
    {
        try
        {
            string host = _configuration["SMTP:Host"]!;
            string name = _configuration["SMTP:Name"]!;
            string userName = _configuration["SMTP:UserName"]!;
            string password = _configuration["SMTP:Password"]!;
            int port = Convert.ToInt32(_configuration["SMTP:Port"]);

            MailMessage mail = new()
            {
                From = new MailAddress(userName, name)
            };

            mail.To.Add(email);
            mail.Subject = subject;
            mail.Body = message;
            mail.IsBodyHtml = true;

            using SmtpClient smtp = new(host, port);
            smtp.Credentials = new NetworkCredential(userName, password);
            smtp.EnableSsl = true;
            smtp.Send(mail);
            return true;
        }
        catch { return false; }
    }
}