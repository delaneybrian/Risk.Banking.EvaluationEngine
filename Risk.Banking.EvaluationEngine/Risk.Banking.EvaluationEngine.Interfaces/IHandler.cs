namespace Risk.Banking.EvaluationEngine.Interfaces
{
    public interface IHandler<T>
    {
        Task Handle(T msg);
    }
}
