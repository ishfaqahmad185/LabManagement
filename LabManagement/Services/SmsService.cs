using Twilio.Types;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace LabManagement.Services
{
    public class SmsService
    {
        private readonly string _accountSid = "your_account_sid";
        private readonly string _authToken = "your_auth_token";
        private readonly string _fromPhoneNumber = "+1234567890"; // Twilio verified phone number

        public SmsService()
        {
            TwilioClient.Init(_accountSid, _authToken);
        }

        public void SendSms(string toPhoneNumber, string messageBody)
        {
            var to = new PhoneNumber(toPhoneNumber);
            var messageOptions = new CreateMessageOptions(to)
            {
                From = new PhoneNumber(_fromPhoneNumber),
                Body = messageBody
            };

            var message = MessageResource.Create(messageOptions);

            Console.WriteLine($"Message sent with SID: {message.Sid}");
        }
    }

}
