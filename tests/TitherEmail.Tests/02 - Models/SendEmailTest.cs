using TitherEmail.Domain.Models;

namespace TitherEmail.Domain
{
    public class SendEmailTest
    {
        [Fact]
        public void Should_Create_An_Instance_Success()
        {
            // ACT
            var sendEmail = new SendEmail("email@email.com", new Transaction(0, ""));

            // ASSERT
            Assert.NotNull(sendEmail);
            Assert.Equal("email@email.com", sendEmail.To);
        }
    }
}