using System.Runtime.Serialization;

namespace Risk.Banking.EvaluationEngine.Definitions
{
    [DataContract]
    public record BankAccountSnapshot
    {
        [DataMember]
        public Guid Id { get; init; }

        [DataMember]
        public string CountryIdentifier { get; init; }

        [DataMember]
        public string SortCode { get; init; }

        [DataMember]
        public int AccountNumber { get; init; }

        [DataMember]
        public double Balance { get; init; }

        [DataMember]
        public AccountType AccountType { get; init; }
    }
}
