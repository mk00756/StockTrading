using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace StockTrading.Receiver.Twillio
{
    public class SendSMS
    {
        const string fromNumber = "";
        const string toNumber = "";

        public void InitializeSMS()
        {
            var accountSid = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
            var authToken = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN");

            TwilioClient.Init(accountSid, authToken);
            
        }

        public void sendSMS(string operation, string name)
        {

            string bodyMessage;
            if (operation == "ADDED")
            {
                bodyMessage = $"'{operation}' stock '{name}' to the database";

            }
            else
            {
                bodyMessage = $"'{operation}' stock '{name}' from the database";

            }

            var message = MessageResource.Create(
            body: bodyMessage,
            from: new PhoneNumber(fromNumber),
            to: new PhoneNumber(toNumber)

        );
        }

        public void sendSMS(string operation, string name, string price)
        {
            string bodyMessage = $"'{operation}' stock '{name}' with a new price of {price}.";

            var message = MessageResource.Create(
            body: bodyMessage,
            from: new PhoneNumber(fromNumber),
            to: new PhoneNumber(toNumber)

        );
        }
    }
}
