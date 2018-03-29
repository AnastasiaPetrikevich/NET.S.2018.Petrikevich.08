using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    /// <summary>
    /// Silver Bank Account.
    /// </summary>
    public class SilverAccount : Account
    {
        private int minBalance = -1000;
        private decimal percent = 0.02m;

        public SilverAccount(string accountNumber, string firstName, string lastName) : base(accountNumber, firstName,
            lastName)
        {
            BenefitPoint = 3;
        }

        protected override bool IsValidBalance(decimal value) => value >= minBalance;
        protected internal override int CalculateBenefitPoint(decimal amount) => (int)Math.Round(amount * percent + Balance * percent);
    }
}
