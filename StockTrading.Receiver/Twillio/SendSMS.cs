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
        public void InitializeSMS()
        {
            const string accountSid = "";
            const string authToken = "";

            TwilioClient.Init(accountSid, authToken);


        }

        public void sendSMS(string operation, string name)
        {
            string bodyMessage;
            if (operation == "ADDED")
            {
                bodyMessage = $"'{operation}' stock {name} to the database";

            }
            else
            {
                bodyMessage = $"'{operation}' stock {name} from the database";

            }

            var message = MessageResource.Create(
            body: bodyMessage,
            from: new PhoneNumber(""),
            to: new PhoneNumber("")

        );
        }

        public void sendSMS(string operation, string name, string price)
        {
            string bodyMessage = $"'{operation}' stock {name} with a new price of {price}.";

            var message = MessageResource.Create(
            body: bodyMessage,
            from: new PhoneNumber(""),
            to: new PhoneNumber("")

        );
        }
    }
}
