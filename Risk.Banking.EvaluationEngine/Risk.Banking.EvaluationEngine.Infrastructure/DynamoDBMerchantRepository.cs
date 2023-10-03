using Risk.Banking.EvaluationEngine.Definitions;
using Risk.Banking.EvaluationEngine.Interfaces;

namespace Risk.Banking.EvaluationEngine.Infrastructure
{
    public class DynamoDBMerchantRepository : IMerchantRepository
    {
        public Task AddOrUpdate(MerchantSnapshot merchantShapshot)
        {
            return Task.CompletedTask;
        }

        public Task<MerchantSnapshot> Get(Guid id)
        {
            return Task.FromResult(new MerchantSnapshot());
        }
    }
}
