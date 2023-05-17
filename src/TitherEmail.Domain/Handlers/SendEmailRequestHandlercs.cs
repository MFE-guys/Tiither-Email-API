using MediatR;
using OperationResult;
using TitherEmail.Domain.Models;
using TitherEmail.Domain.Services;
using TitherEmail.Shared.Requests;
using TitherEmail.Shared.ViewModels;

namespace TitherEmail.Domain.Handlers
{
    public sealed class SendEmailRequestHandlercs : IRequestHandler<SendEmailRequest, Result<SendEmailResponseViewModel>>
    {
        private readonly ISendGridService _emailService;

        public SendEmailRequestHandlercs(ISendGridService emailService) 
            => _emailService = emailService;

        public async Task<Result<SendEmailResponseViewModel>> Handle(SendEmailRequest request, CancellationToken cancellationToken)
        {
            var transaction = new Transaction(
                request.Value, request.Type);

            transaction.SetDescription(request.Description);
            transaction.SetUser(request.User);

            var model = new SendEmail(request.To, transaction);

            var (isSuccess, result, exception) = await _emailService.SendEmail(model).ConfigureAwait(false);

            if (!isSuccess)
                return Result.Error<SendEmailResponseViewModel>(exception!);

            return result!;
        }
    }
}
