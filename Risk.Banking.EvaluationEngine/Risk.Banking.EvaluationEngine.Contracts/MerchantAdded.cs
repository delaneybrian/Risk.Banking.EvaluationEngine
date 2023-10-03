using System.Runtime.Serialization;

namespace Risk.Banking.EvaluationEngine.Contracts
{
    [DataContract]
    public record MerchantAdded : IEvent
    {
        [DataMember]
        public Guid Id { get; init; }

        [DataMember] 
        public string Name { get; init; }
    }
}