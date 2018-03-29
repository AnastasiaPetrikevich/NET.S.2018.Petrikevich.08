using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    /// <summary>
    /// Base Bank Account.
    /// </summary>
    public class BaseAccount : Account
    {
        private decimal percent = 0.01m;

        public BaseAccount(string accountNumber, string firstName, string lastName) : base(accountNumber, firstName,
            lastName)
        {
            BenefitPoint = 0;
        }

        protected override bool IsValidBalance(decimal value) => value > 0;
        protected internal override int CalculateBenefitPoint(decimal amount) => (int)Math.Round(amount * percent + Balance * percent);
    }
}
