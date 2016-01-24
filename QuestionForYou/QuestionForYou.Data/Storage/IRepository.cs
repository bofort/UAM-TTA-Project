using QuestionForYou.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace QuestionForYou.Data.Storage
{
    public interface IRepository<T> where T : class, IEntity
    {
        IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includes);

        T FindById(int? id, params Expression<Func<T, object>>[] includes);

        T Persist(T item);

        void Remove(T item);
    }
}