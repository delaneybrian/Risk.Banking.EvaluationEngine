using Risk.Banking.EvaluationEngine.Definitions;

namespace Risk.Banking.EvaluationEngine.Domain
{
    public class BankAccount
    {
        public Guid Id { get; private set; }

        public IBAN IBAN { get; private set; }

        public BankBalance Balance { get; private set; }

        public AccountType AccountType { get; private set; }

        public static BankAccount FromSnapshot(BankAccountSnapshot bankAccountSnapshot)
        {
            return new BankAccount(
                bankAccountSnapshot.Id,
                bankAccountSnapshot.AccountNumber,
                bankAccountSnapshot.SortCode,
                bankAccountSnapshot.CountryIdentifier,
                bankAccountSnapshot.Balance,
                bankAccountSnapshot.AccountType);
        }

        public static BankAccount OpenNew()
        {
            return new BankAccount(
                Guid.NewGuid(),
                123456,
                "BOFI4544",
                "IE200056",
                0,
                Definitions.AccountType.Standard);
        }

        private BankAccount
            (Guid id, 
            int accountNumber, 
            string sortCode, 
            string countryIdentifier, 
            double currentBalance,
            Definitions.AccountType accountType)
        {
            Id = id;
            IBAN = new IBAN(accountNumber, sortCode, countryIdentifier);
            Balance = new BankBalance(currentBalance);
            AccountType = AccountType.FromSnapshot(accountType);
        }

        public void ReviecePayment(double paymentAmount)
        {
            if (AccountType != AccountType.Standard)
                return;

            Balance.DebitAccount(paymentAmount);
        }

        public BankAccountSnapshot ToSnapshot()
        {
            return new BankAccountSnapshot
            {
                AccountNumber = IBAN.AccountNumber,
                CountryIdentifier = IBAN.CountryIdentifier,
                SortCode = IBAN.SortCode,
                Balance = Balance.CurrentBalance,
                Id = Id,
                AccountType = AccountType.ToSnapshot()
            };
        }
    }
}
