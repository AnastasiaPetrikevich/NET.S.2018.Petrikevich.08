using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    /// <summary>
    /// Methods for work with accounts.
    /// </summary>
    public static class AccountService
    {
        /// <summary>
        /// Types of bank accounts.
        /// </summary>
        public enum AccountType
        {
            Base,
            Silver,
            Gold,
            Platinum
        }

        /// <summary>
        /// Create new bank account.
        /// </summary>
        /// <param name="firstName">First name of the account owner. </param>
        /// <param name="lastName">Last name of the account owner. </param>
        /// <param name="accountType">Account type.</param>
        /// <returns>New bank account.</returns>
        public static Account CreateNewAccount(string firstName, string lastName, AccountType accountType)
        {
            string accountNumber = GenerateAccountNumber();
            switch (accountType)
            {
                case AccountType.Base:
                    return new BaseAccount(accountNumber, firstName, lastName);

                case AccountType.Silver:
                    return new SilverAccount(accountNumber, firstName, lastName);

                case AccountType.Gold:
                    return new GoldAccount(accountNumber, firstName, lastName);

                case AccountType.Platinum:
                    return new PlatinumAccount(accountNumber, firstName, lastName);

                default:
                    return null;
            }

        }

        /// <summary>
        /// Replenishes the account.
        /// </summary>
        /// <param name="account">Account.</param>
        /// <param name="amount">Amount for replenishment.</param>
        public static void Deposit(this Account account, decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException(nameof(amount));
            }

            account.Balance += amount;
            account.BenefitPoint += account.CalculateBenefitPoint(amount);
        }

        /// <summary>
        /// Debits from the account.
        /// </summary>
        /// <param name="account">Account.</param>
        /// <param name="amount">Debit amount.</param>
        public static void Whithdraw(this Account account, decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException(nameof(amount));
            }

            account.Balance -= amount;
            account.BenefitPoint -= account.CalculateBenefitPoint(amount);
        }

        /// <summary>
        /// Close bank account.
        /// </summary>
        public static void CloseAccount(ref Account account)
        {
            account = null;
        }

        /// <summary>
        /// Generate account number.
        /// </summary>
        /// <returns>String representation of the account number.</returns>
        private static string GenerateAccountNumber()
        {
            StringBuilder accountNumber = new StringBuilder();
            Random rand = new Random();
            for (int i = 0; i < 2; i++)
            {
                char n = (char)rand.Next('A', 'Z');
                accountNumber.Append(n);
            }

            for (int i = 0; i < 8; i++)
            {
                int n = rand.Next(1, 10);
                accountNumber.Append(n);
            }

            return accountNumber.ToString();
        }

    }
}
