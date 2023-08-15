using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tests.InputData
{
    public class SendgridMailMessageData
    {
        public static SendGridMessage GetSendgridMessage
        {
            get
            {
                return new SendGridMessage()
                {
                    From = new EmailAddress("support@kavi.app", "Kavi Support"),
                    Subject = "ISendGridClient test",
                    HtmlContent = "Hi, /n Test ISendGridClient by mocking",
                    Personalizations = new List<Personalization>()
                    {
                        new Personalization()
                        {
                            Tos = new List<EmailAddress>()
                            {
                                new EmailAddress("suresh+1@thinkbridge.in")
                            }
                        }
                    }
                };
            }
        }
    }
}
