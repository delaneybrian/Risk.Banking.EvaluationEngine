using System.Runtime.Serialization;

namespace Risk.Banking.EvaluationEngine.Contracts
{
    [DataContract]
    public record RiskEvaluationFailed : IEvent
    {
    }
}
