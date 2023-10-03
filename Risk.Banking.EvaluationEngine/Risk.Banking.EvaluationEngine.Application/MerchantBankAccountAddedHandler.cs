using Risk.Banking.EvaluationEngine.Contracts;
using Risk.Banking.EvaluationEngine.Domain;
using Risk.Banking.EvaluationEngine.Interfaces;

namespace Risk.Banking.EvaluationEngine.Application
{
    public class MerchantBankAccountAddedHandler : IHandler<MerchantBankAccountAdded>
    {
        private readonly IMerchantRepository _merchantRepository;
        private readonly IEventPublisher _eventPublisher;
        private readonly IRiskEvaulationService _riskEvaulationService;

        public MerchantBankAccountAddedHandler(
            IMerchantRepository merchantRepository,
            IEventPublisher eventPublisher,
            IRiskEvaulationService riskEvaulationService)
        {
            _merchantRepository = merchantRepository;
            _eventPublisher = eventPublisher;
            _riskEvaulationService = riskEvaulationService;
        }

        public async Task Handle(MerchantBankAccountAdded evt)
        {
            var merchantShapshot = await _merchantRepository.Get(evt.MerchantId);

            var merchant = MerchantAggregate.FromSnapshot(merchantShapshot);

            var riskEvaluation = await _riskEvaulationService.EvaluateRisk(merchant, evt);

            merchant.OpenNewBankAccount(evt, riskEvaluation);

            foreach (var eventToPublish in merchant.UppublishedEvents)
            {
                await _eventPublisher.Publish(eventToPublish);
            }

            var updatedSnapshot = merchant.ToSnapshot();

            await _merchantRepository.AddOrUpdate(updatedSnapshot);
        }
    }
}
