//This is a Value Object -> Contains logic but two value objects are essentially the same things 

namespace Risk.Banking.EvaluationEngine.Domain
{
    public class BankBalance : IEquatable<BankBalance>
    {
        private int MaxWithdrawelAmount = 10000;

        private int MaxDepositAmount = 10000;

        private int MaxAllowedBalance = 100000;

        private int MaxOverdraftLimit = 3000;

        public BankBalance(double currentBalance)
        {
            CurrentBalance = currentBalance;

            if (CurrentBalance < 0)
                IsInOverdraft = true;
        }

        public double CurrentBalance { get; private set; }

        public bool IsInOverdraft { get; private set; }

        public void CreditAccount(double amountToCredit)
        {
            if (!CanCreditAccount(amountToCredit))
                throw new AggregateException("Cannot Credit Bank Balance");

            CurrentBalance = CurrentBalance + amountToCredit;

            if (CurrentBalance > 0)
                IsInOverdraft = false;
        }

        public void DebitAccount(double amountToDebit)
        {
            if (!CanDebitAccount(amountToDebit))
                throw new AggregateException("Cannot Debit Bank Balance");

            CurrentBalance = CurrentBalance - amountToDebit;

            if (CurrentBalance < 0)
                IsInOverdraft = true;
        }

        public bool Equals(BankBalance? other)
        {
            return other.CurrentBalance == CurrentBalance;
        }

        private bool CanCreditAccount(double amountToCredit)
        {
            if (amountToCredit > MaxDepositAmount)
                return false;

            if (CurrentBalance + amountToCredit > MaxAllowedBalance)
                return false;

            return true;
        }

        private bool CanDebitAccount(double amountToDebit)
        {
            if (amountToDebit > MaxWithdrawelAmount)
                return false;

            if (amountToDebit > CurrentBalance + MaxOverdraftLimit)
                return false;

            return true;
        }
    }
}
