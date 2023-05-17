using FluentEmail.Core;
using OperationResult;
using TitherEmail.Domain.Models;
using TitherEmail.Domain.Services;
using TitherEmail.Shared.ViewModels;

namespace TitherEmail.Services
{
    public sealed class SendGridService : ISendGridService
    {
        private readonly IFluentEmail _mailService;

        public SendGridService(IFluentEmail mailService)
            => _mailService = mailService;

        public async Task<Result<SendEmailResponseViewModel>> SendEmail(SendEmail sendEmail)
        {
            try
            {
                _mailService.To(sendEmail.To);
                _mailService.Subject("Teste");
                _mailService.Tag("teste");
                _mailService.UsingTemplateFromFile($"{Directory.GetCurrentDirectory()}/Templates/Transaction.cshtml", new
                {
                    User = sendEmail.Transaction.User,
                    Type = sendEmail.Transaction.Type,
                    Amount = sendEmail.Transaction.Value,
                    Description = sendEmail.Transaction.Description,
                });

                var result = await _mailService.SendAsync();

                if (!result.Successful)
                    return Result.Error<SendEmailResponseViewModel>(new Exception(result.ErrorMessages.ElementAt(0)));

                return new SendEmailResponseViewModel
                {
                    Id = result.MessageId,
                    IsSuccess = result.Successful
                };
            }
            catch (Exception exception)
            {
                return Result.Error<SendEmailResponseViewModel>(exception);
            }
        }
    }
}
