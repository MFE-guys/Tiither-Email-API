using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TitherEmail.Domain.Models
{
    public sealed class EmailSettings
    {
        public string From { get; set; }
        public string Key { get; set; }
    }
}
