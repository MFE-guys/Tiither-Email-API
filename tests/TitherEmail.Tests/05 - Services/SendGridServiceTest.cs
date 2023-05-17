using FluentEmail.Core;
using FluentEmail.Core.Models;
using Moq;
using TitherEmail.Domain.Models;

namespace TitherEmail.Services
{
    public class SendGridServiceTest
    {
        private Mock<IFluentEmail> _mailService;
        private SendGridService _service;

        public SendGridServiceTest()
        {
            _mailService = new Mock<IFluentEmail>();
            _service = new SendGridService(_mailService.Object); 
        }  

        [Fact]
        public async Task Should_Send_Email_Success()
        {
            // ARRANGE
            var sendEmail = new SendEmail(
                "to@email.com", 
                new Transaction(100, "Entrada"));

            _mailService.Setup(x => x.SendAsync(null)).Returns(Task.FromResult(new SendResponse { MessageId = "123"}));

            // ACT
            var (isSuccess, result, exception) = 
                await _service.SendEmail(sendEmail);

            // ASSERT
            Assert.NotNull(result);
            Assert.NotEmpty(result.Id);
            Assert.True(result.IsSuccess);
            Assert.True(isSuccess);
        }

        [Fact]
        public async Task Should_Send_Email_Fail()
        {
            // ARRANGE
            var sendEmail = new SendEmail(
                "to@email.com",
                new Transaction(100, "Entrada"));

            _mailService.Setup(x => x.SendAsync(null)).Returns(Task.FromResult(new SendResponse { ErrorMessages = new List<string> { "Erro" } }));

            // ACT
            var (isSuccess, result, exception) =
                await _service.SendEmail(sendEmail);

            // ASSERT
            Assert.NotNull(exception);
            Assert.False(isSuccess);
        }
    }
}
