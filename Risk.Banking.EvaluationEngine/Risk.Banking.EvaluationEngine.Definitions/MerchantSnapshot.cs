using System.Runtime.Serialization;

namespace Risk.Banking.EvaluationEngine.Definitions
{
    [DataContract]
    public record MerchantSnapshot
    {
        [DataMember]
        public Guid Id { get; init; }

        [DataMember]
        public string Name { get; init; }

        [DataMember]
        public ICollection<BankAccountSnapshot> BankAccounts { get; init; }
    }
}