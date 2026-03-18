using SendGrid;
using SendGrid.Helpers.Mail;

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
            // Try multiple ways to read the API key
            var apiKey = Environment.GetEnvironmentVariable("EmailSettings__SendGridApiKey")
                      ?? _config["EmailSettings:SendGridApiKey"]
                      ?? "";

            var receiverEmail = Environment.GetEnvironmentVariable("EmailSettings__ReceiverEmail")
                             ?? _config["EmailSettings:ReceiverEmail"]
                             ?? "";

            Console.WriteLine($"API Key found: {!string.IsNullOrEmpty(apiKey)}");
            Console.WriteLine($"API Key length: {apiKey.Length}");

            // Clean the key — remove any hidden characters
            apiKey = apiKey.Trim().Replace("\n", "").Replace("\r", "").Replace(" ", "");

            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("johnspeak153@gmail.com", "Portfolio Contact");
            var to = new EmailAddress(receiverEmail, "Jef");
            var subject = $"New Portfolio Message from {senderName}";
            var body = $@"
        <h2 style='color:#00c49f'>New message from your portfolio!</h2>
        <p><strong>From:</strong> {senderName}</p>
        <p><strong>Their Email:</strong> {senderEmail}</p>
        <p><strong>Message:</strong></p>
        <p>{message}</p>
        <hr/>
        <p>Click Reply to respond directly to {senderName}.</p>
    ";

            var msg = MailHelper.CreateSingleEmail(from, to, subject, "", body);
            msg.SetReplyTo(new EmailAddress(senderEmail, senderName));

            var response = await client.SendEmailAsync(msg);
            Console.WriteLine($"SendGrid Status: {response.StatusCode}");
        }
    }
}