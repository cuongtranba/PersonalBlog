
namespace DomainLayer.Service
{
    public interface IService<T> : ICreatable<T>, IRetrievable<T>, IUpdatable<T>, IDeletable<T>
    {
        
    }

    public interface IDeletable<T>
    {
        void Delete(T existing);
    }

    public interface IUpdatable<T>
    {
        void Update(T existing);
    }

    public interface IRetrievable<T>
    {
        T Retrieve(params object[] keys);
    }

    public interface ICreatable<T>
    {
        T Create();
    }
}
