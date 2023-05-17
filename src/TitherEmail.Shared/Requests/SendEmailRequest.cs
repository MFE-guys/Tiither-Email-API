using MediatR;
using OperationResult;
using TitherEmail.Shared.ViewModels;

namespace TitherEmail.Shared.Requests
{
    public sealed class SendEmailRequest : IRequest<Result<SendEmailResponseViewModel>>
    {
        public string To { get; set; } = "";
        public string Description { get; set; }
        public string User { get; set; }

        public decimal Value { get; set; }
        public string Type { get; set; }
    }
}
