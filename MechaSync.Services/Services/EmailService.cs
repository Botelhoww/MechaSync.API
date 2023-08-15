using System.Net.Mail;

namespace MechaSync.Services.Services;

public class EmailService
{
    public static void Enviar(string from, string to, string header, string body)
    {
        var mail = new MailMessage(from, to);

        var client = new SmtpClient
        {
            Port = 25,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = true,
            Host = "smtp.google.com"
        };

        mail.Subject = header;
        mail.Body = body;

        client.Send(mail);
    }

    public static bool IsValid(string email)
    {
        if (email.Contains("@"))
            return true;

        return false;
    }
}