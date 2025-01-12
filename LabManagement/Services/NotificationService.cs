using SendGrid.Helpers.Mail;
using SendGrid;
using Twilio.Clients;
using Twilio.Types;
using Twilio.Rest.Api.V2010.Account;

namespace LabManagement.Services
{
    public class NotificationService
    {
        private readonly string _twilioAccountSid = "your_twilio_account_sid";
        private readonly string _twilioAuthToken = "your_twilio_auth_token";
        private readonly string _sendGridApiKey = "your_sendgrid_api_key";

        public void SendSms(string to, string messageBody)
        {
            var client = new TwilioRestClient(_twilioAccountSid, _twilioAuthToken);
            var messageOptions = new CreateMessageOptions(new PhoneNumber(to))
            {
                Body = messageBody,
                From = new PhoneNumber("your_twilio_phone_number")
            };
            //client.Messages.Create(messageOptions);
            var message = MessageResource.Create(messageOptions);
        }

        public void SendEmail(string to, string subject, string body)
        {
            var client = new SendGridClient(_sendGridApiKey);
            var from = new EmailAddress("no-reply@labmanagementsystem.com", "Lab Management System");
            var toEmail = new EmailAddress(to);
            var msg = MailHelper.CreateSingleEmail(from, toEmail, subject, body, body);
            client.SendEmailAsync(msg);
        }
    }
}
