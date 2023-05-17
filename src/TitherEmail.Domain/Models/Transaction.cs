using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TitherEmail.Domain.Models
{
    public sealed class Transaction
    {
        public Transaction(decimal value, string type)
        {
            Value = value;
            Type = type;
        }

        public string Description { get; private set; } = string.Empty;
        public string User { get; private set; } = string.Empty;

        public decimal Value { get; set; }
        public string Type { get; set; }

        public void SetDescription(string value) => Description = value;
        public void SetUser(string value) => User = value;
    }
}
