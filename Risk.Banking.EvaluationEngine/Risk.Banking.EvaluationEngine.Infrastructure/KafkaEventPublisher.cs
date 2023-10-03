using Risk.Banking.EvaluationEngine.Contracts;
using Risk.Banking.EvaluationEngine.Interfaces;

namespace Risk.Banking.EvaluationEngine.Infrastructure
{
    public class KafkaEventPublisher : IEventPublisher
    {
        public Task Publish(IEvent evt)
        {
            return Task.CompletedTask;
        }

        public Task Publish(ICollection<IEvent> events)
        {
            return Task.CompletedTask;
        }
    }
}