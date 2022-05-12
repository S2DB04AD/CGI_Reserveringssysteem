using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;

namespace Mailer
{
    public static class MailServer
    {
        private static SmtpClient Smc;

        // Configure server
        public static void Configure(string host, int port, string uname, string pass)
        {
            Smc = new SmtpClient();
            Smc.Connect(host, port, MailKit.Security.SecureSocketOptions.Auto);
            Smc.Authenticate(uname, pass);
        }

        // Halt server
        public static void Halt()
        {
            Smc.Disconnect(true);
        }

        public static void Send(string from, string to, string sub, string body)
        {
            // Generate mail
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(from));
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = sub;
            email.Body = new TextPart(TextFormat.Plain) { Text = body };

            // Send mail
            Smc.Send(email);
        }
    }
}