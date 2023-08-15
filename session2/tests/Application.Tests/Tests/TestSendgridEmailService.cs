using Application.Services;
using Application.Tests.InputData;
using NSubstitute;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net;

namespace Application.Tests.Tests
{
    public class TestSendgridEmailService : TestBase
    {
        public TestSendgridEmailService(SetupFixture setup) : base(setup)
        {

        }

        [Fact]
        public async Task SendgridEmailService_Send_MockSendEmailAsync_UsingWiremock_Success()
        {
            //Arrange
            var sendgridMock = Substitute.For<ISendGridClient>();
            var notificationService = Substitute.For<SendGridEmailService>();
            notificationService.GetClient().Returns(sendgridMock);
            var emailMessage = SendgridMailMessageData.GetSendgridMessage;
            sendgridMock.SendEmailAsync(Arg.Is<SendGridMessage>(x => x.HtmlContent.Equals(emailMessage.HtmlContent) && x.Subject.Equals(emailMessage.Subject)))
                .Returns(new Response(HttpStatusCode.Accepted, new StringContent("Request Accepted"), new HttpResponseMessage().Headers));

            //Act
            await notificationService.Send(emailMessage.From.Email, emailMessage.From.Name, emailMessage.Personalizations.First().Tos.First().Email, emailMessage.HtmlContent, emailMessage.Subject);

            // Assert 
            await sendgridMock.Received(1).SendEmailAsync(Arg.Any<SendGridMessage>());

        }
    }
}
