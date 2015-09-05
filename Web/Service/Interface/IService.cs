using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Web.Service.Interface
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
        T Retrieve(int keys);

        List<TResult> GetAll<TResult>(Expression<Func<T, bool>> predicate, Expression<Func<T, TResult>> selector) where TResult : class;

        List<TResult> GetAll<TResult>(Expression<Func<T, TResult>> selector)
            where TResult : class;
    }

    public interface ICreatable<T>
    {
        void Create(T model);
    }
}
