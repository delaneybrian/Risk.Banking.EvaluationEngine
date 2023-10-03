using Risk.Banking.EvaluationEngine.Contracts;
using Risk.Banking.EvaluationEngine.Definitions;

namespace Risk.Banking.EvaluationEngine.Domain
{
    public class MerchantAggregate
    {
        private const int MaxOpenBankAccountsPerMerchant = 10;

        public ICollection<IEvent> UppublishedEvents { get; } = new List<IEvent>();

        public Guid Id { get; private set; }

        public ICollection<BankAccount> BankAccounts { get; private set; }

        public string Name { get; private set; }

        public static MerchantAggregate FromSnapshot(MerchantSnapshot snapshot)
        {
            return new MerchantAggregate(snapshot.Id, snapshot.Name, snapshot.BankAccounts);
        }

        private MerchantAggregate(
            Guid id, 
            string name, 
            ICollection<BankAccountSnapshot> bankAccountSnapshots)
        {
            Id = id;
            Name = name;
            BankAccounts = bankAccountSnapshots.Select(s => BankAccount.FromSnapshot(s)).ToList();  
        }

        public void RecievePayment(PaymentRecieved paymentRecieved, bool riskEvaluation)
        {
            if (riskEvaluation)
            {
                UppublishedEvents.Add(new RiskEvaluationFailed());

                return;
            }

            var relevantBankAccount = BankAccounts.SingleOrDefault(x => x.Id == paymentRecieved.BankAccountId);

            if (relevantBankAccount is null)
                return;

            relevantBankAccount.ReviecePayment(paymentRecieved.PaymentAmount);
        }

        public void OpenNewBankAccount(MerchantBankAccountAdded merchantBankAccountAdded, bool riskEvaluation) 
        {
            if (riskEvaluation)
            {
                UppublishedEvents.Add(new RiskEvaluationFailed());

                return;
            }

            if (BankAccounts.Count > MaxOpenBankAccountsPerMerchant)
                return;

            var bankAccount = BankAccount.OpenNew();

            BankAccounts.Add(bankAccount);
        }

        public MerchantSnapshot ToSnapshot()
        {
            return new MerchantSnapshot
            {
                Id = Id,
                Name = Name,
                BankAccounts = BankAccounts
                    .Select(ba => ba.ToSnapshot())
                    .ToList()
            };
        }
    }
}