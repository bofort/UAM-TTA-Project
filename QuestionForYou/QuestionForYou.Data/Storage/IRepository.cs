using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using QuestionForYou.Data.Model;

namespace QuestionForYou.Data.Storage
{
    public interface IRepository<T> where T : class, IEntity
    {
        IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includes);

        T FindById(int id, params Expression<Func<T, object>>[] includes);

        T Persist(T item);

        void Remove(T item);
    }
}
