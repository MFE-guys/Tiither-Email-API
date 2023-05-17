using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TitherEmail.Domain.Models
{
    public sealed class SendEmail
    {
        public SendEmail(string to, Transaction transaction)
        {
            To = to;
            Transaction = transaction;
        }
        public string User { get; set; }
        public string To { get; private set; } = string.Empty;
        public Transaction Transaction { get; private set; }

        public void SetToAddress(string to) => To = to;
        public void SetTransaction(Transaction objectTransaction) => Transaction = objectTransaction;
    }
}
