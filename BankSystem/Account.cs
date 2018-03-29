using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    /// <summary>
    /// Bank Account.
    /// </summary>
    public abstract class Account
    {
        #region Fields
        /// <summary>
        /// Account number.
        /// </summary>
        private string accountNumber;

        /// <summary>
        /// First name of the account owner. 
        /// </summary>
        private string firstName;

        /// <summary>
        /// Last name of the account owner. 
        /// </summary>
        private string lastName;

        /// <summary>
        /// Balance. 
        /// </summary>
        private decimal balance;

        /// <summary>
        /// Benefit points. 
        /// </summary>
        private int benefitPoint;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a bank account.
        /// </summary>
        public Account(string accountNumber, string firstName, string lastName)
        {
            AccountNumber = accountNumber;
            FirstName = firstName;
            LastName = lastName;
        }
        #endregion


        #region Properties
        /// <summary>
        /// Gets and sets the account number. 
        /// </summary>
        public string AccountNumber
        {
            get => accountNumber;
            protected internal set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    accountNumber = value;
                }
                else
                {
                    throw new ArgumentException(nameof(accountNumber));
                }
            }
        }

        /// <summary>
        /// Gets and sets the first name of the account owner.
        /// </summary>
        public string FirstName
        {
            get => firstName;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    firstName = value;
                }
                else
                {
                    throw new ArgumentException(nameof(firstName));
                }
            }
        }

        /// <summary>
        /// Gets and sets the last name of the account owner.
        /// </summary>
        public string LastName
        {
            get => lastName;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    lastName = value;
                }
                else
                {
                    throw new ArgumentException(nameof(lastName));
                }
            }
        }

        /// <summary>
        /// Gets and sets the account balance.
        /// </summary>
        public decimal Balance
        {
            get => balance;
            protected internal set
            {
                if (IsValidBalance(value))
                {
                    balance = value;
                }
                else
                {
                    throw new ArgumentException(nameof(balance));
                }
            }
        }

        /// <summary>
        /// Gets and sets the account benefit points.
        /// </summary>
        public int BenefitPoint
        {
            get => benefitPoint;
            protected internal set => benefitPoint = value;
        }
        #endregion
        
        #region Methods
        /// <summary>
        /// Override method ToString() of System.Object.
        /// </summary>
        public override string ToString()
        {
            return $"Owner: {FirstName} {LastName}, balance:{Balance}, benefit points: {BenefitPoint}.";
        }

        /// <summary>
        /// Abstract method. Cheks the value of the balance.
        /// </summary>
        protected abstract bool IsValidBalance(decimal value);

        /// <summary>
        /// Abstract method. Calculates benefit points.
        /// </summary>
        protected internal abstract int CalculateBenefitPoint(decimal amount);
        #endregion



    }
}
