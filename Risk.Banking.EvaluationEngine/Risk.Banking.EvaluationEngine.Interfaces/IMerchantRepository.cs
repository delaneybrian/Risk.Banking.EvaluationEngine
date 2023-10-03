using Risk.Banking.EvaluationEngine.Definitions;

namespace Risk.Banking.EvaluationEngine.Interfaces
{
    public interface IMerchantRepository
    {
        Task<MerchantSnapshot> Get(Guid id);

        Task AddOrUpdate(MerchantSnapshot merchantShapshot);
    }
}