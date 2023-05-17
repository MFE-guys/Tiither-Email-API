using OperationResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitherEmail.Domain.Models;
using TitherEmail.Shared.ViewModels;

namespace TitherEmail.Domain.Services
{
    public interface ISendGridService
    {
        Task<Result<SendEmailResponseViewModel>> SendEmail(SendEmail sendEmail);
    }
}

