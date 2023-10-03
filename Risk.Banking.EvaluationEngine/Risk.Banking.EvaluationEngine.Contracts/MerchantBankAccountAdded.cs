using System.Runtime.Serialization;

namespace Risk.Banking.EvaluationEngine.Contracts
{
    [DataContract]
    public record MerchantBankAccountAdded : IEvent
    {
        [DataMember]
        public Guid MerchantId { get; init; }

        [DataMember]
        public Guid BankAccountId { get; init; }

        [DataMember]
        public double BankAccountBalance { get; init; }
    }
}
