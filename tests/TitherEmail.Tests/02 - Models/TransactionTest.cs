using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitherEmail.Domain.Models;

namespace TitherEmail.Domain
{
    public class TransactionTest
    {
        [Fact]
        public void Should_Create_An_Instance_Success()
        {
            // ARRANGE
            var user = "Eduardo Nery";
            var description = "Pagamento referente ao mês de Janeiro";
            var type = "Entrada";
            var value = 50;

            // ACT
            var transaction = new Transaction(value, type);
            transaction.SetUser(user);
            transaction.SetDescription(description);

            // ASSERT
            Assert.NotNull(transaction);
            Assert.Equal(value, transaction.Value);
            Assert.Equal(user, transaction.User);
            Assert.Equal(description, transaction.Description);
        }
    }
}
