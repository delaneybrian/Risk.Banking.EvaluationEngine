using Risk.Banking.EvaluationEngine.Contracts;

namespace Risk.Banking.EvaluationEngine.Interfaces
{
    public interface IEventPublisher
    {
        Task Publish(IEvent evt);

        Task Publish(ICollection<IEvent> events);
    }
}
