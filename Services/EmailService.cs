using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace JefPortfolio.Services
{
    public class EmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendContactEmailAsync(string senderName, string senderEmail, string message)
        {
            // Read settings safely
            var smtpHost = _config["EmailSettings:SmtpHost"] ?? "smtp.gmail.com";
            var smtpPort = _config["EmailSettings:SmtpPort"] ?? "465";
            var senderAcc = _config["EmailSettings:SenderEmail"] ?? "";
            var password = _config["EmailSettings:SenderPassword"] ?? "";
            var receiverAcc = _config["EmailSettings:ReceiverEmail"] ?? "";

            var email = new MimeMessage();

            // Your Gmail sends it
            email.From.Add(new MailboxAddress("Portfolio Contact", senderAcc));

            // You receive it
            email.To.Add(new MailboxAddress("Jef", receiverAcc));

            // When you click Reply — goes back to the viewer
            email.ReplyTo.Add(new MailboxAddress(senderName, senderEmail));

            email.Subject = $"Portfolio Message from {senderName}";

            email.Body = new TextPart("html")
            {
                Text = $@"
                    <h2>New message from your portfolio!</h2>
                    <p><strong>From:</strong> {senderName}</p>
                    <p><strong>Their Email:</strong> {senderEmail}</p>
                    <p><strong>Message:</strong></p>
                    <p>{message}</p>
                    <hr/>
                    <p>Click Reply to respond directly to {senderName}.</p>
                "
            };

            // Send with 10 second timeout
            using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            using var smtp = new SmtpClient();

            await smtp.ConnectAsync(smtpHost, int.Parse(smtpPort),
                SecureSocketOptions.SslOnConnect, cts.Token);

            await smtp.AuthenticateAsync(senderAcc, password, cts.Token);
            await smtp.SendAsync(email, cts.Token);
            await smtp.DisconnectAsync(true, cts.Token);
        }
    }
}