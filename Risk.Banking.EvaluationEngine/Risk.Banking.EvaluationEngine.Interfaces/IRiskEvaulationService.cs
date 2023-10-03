using Risk.Banking.EvaluationEngine.Contracts;
using Risk.Banking.EvaluationEngine.Domain;

namespace Risk.Banking.EvaluationEngine.Interfaces
{
    public interface IRiskEvaulationService
    {
        Task<bool> EvaluateRisk(MerchantAggregate merchant, IEvent evt);
    }
}
