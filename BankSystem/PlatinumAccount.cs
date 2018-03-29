using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    /// <summary>
    /// Platinum Bank Account.
    /// </summary>
    public class PlatinumAccount : Account
    {
        private int minBalance = -10000;
        private decimal percent = 0.04m;
        
        public PlatinumAccount(string accountNumber, string firstName, string lastName) : base(accountNumber, firstName,
            lastName)
        {
            BenefitPoint = 10;
        }

        protected override bool IsValidBalance(decimal value) => value >= minBalance;
        protected internal override int CalculateBenefitPoint(decimal amount) => (int)Math.Round(amount * percent + Balance *percent);
    }
}
