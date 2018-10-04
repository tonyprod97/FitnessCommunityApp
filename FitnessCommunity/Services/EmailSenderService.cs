using FitnessCommunity.Helpers.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace FitnessCommunity.Services
{
    public class EmailSenderService
    {
        private readonly EmailSettings _emailSettings;

        public EmailSenderService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public void ConfigureSendingMail(string toAdress, string body, bool isUser)
        {
            var message = new MimeMessage();

            message.From.Add(new MailboxAddress("FitnessCommunity", _emailSettings.Sender));
            message.To.Add(new MailboxAddress(toAdress, toAdress));

            if (isUser)
            {
                message.Subject = "Reset Password Link";
                message.Body = new TextPart("plain")
                {
                    Text = body
                };
            }
            else
            {
                message.Subject = "Welcome to Fitness Community";
                message.Body = new TextPart("plain")
                {
                    Text = body
                };
            }

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate(_emailSettings.Sender, _emailSettings.Password);
                client.Send(message);
                client.Disconnect(true);
            }
        }

    }
}
