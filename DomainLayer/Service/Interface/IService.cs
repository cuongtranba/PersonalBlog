
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DAL.Entities;

namespace DomainLayer.Service.Interface
{
    public interface IService<T> : ICreatable<T>, IRetrievable<T>, IUpdatable<T>, IDeletable<T>
    {
    }

    public interface IDeletable<T>
    {
        void Delete(T model);
    }

    public interface IUpdatable<T>
    {
        void Update(T model);
    }

    public interface IRetrievable<T>
    {
        T Retrieve(params object[] keys);
        List<T> GetAll(Expression<Func<T, bool>> predicate, bool isTracking = true);
        List<T> GetAll(bool isTracking = true);
    }

    public interface ICreatable<T>
    {
        T Create();
    }
}
