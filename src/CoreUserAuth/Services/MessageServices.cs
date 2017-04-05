using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace CoreUserAuth.Services
{
    // This class is used by the application to send Email and SMS
    // when you turn on two-factor authentication in ASP.NET Identity.
    // For more details see this link http://go.microsoft.com/fwlink/?LinkID=532713
    public class AuthMessageSender : IEmailSender, ISmsSender
    {

        public AuthMessageSenderOptions Options { get; } //set only via Secret Manager
        public SMSoptions SmSoptions { get; set; }

        public AuthMessageSender(IOptions<AuthMessageSenderOptions> optionsAccessor, IOptions<SMSoptions> smsOptions )
        {
            Options = optionsAccessor.Value;
            SmSoptions = smsOptions.Value;
        }


        public Task SendEmailAsync(string email, string subject, string message)
        {
            // Plug in your email service here to send an email.
            Execute(Options.SendGridKey, subject, message, email).Wait();
            return Task.FromResult(0);
        }
        public async Task Execute(string apiKey, string subject, string message, string email)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("noreply@niel.com", "Niel"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email));
            var response = await client.SendEmailAsync(msg);
        }

        public Task SendSmsAsync(string number, string message)
        {
            // Plug in your SMS service here to send a text message.
            // Your Account SID from twilio.com/console
            var accountSid = SmSoptions.AccountSid;
            // Your Auth Token from twilio.com/console
            var authToken = SmSoptions.AuthToken;

            TwilioClient.Init(accountSid, authToken);

            var msg = MessageResource.Create(
              to: new PhoneNumber(number),
              from: new PhoneNumber("(334) 239-3473"),
              body: message);

            return Task.FromResult(0);
        }
    }
}
