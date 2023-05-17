using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TitherEmail.Shared.DTOs
{
    public sealed class TransactionDTO
    {
        public string Description { get; private set; } = string.Empty;
        public string User { get; private set; } = string.Empty;

        public decimal Value { get; set; }
        public string Type { get; set; } = string.Empty;
    }
}
