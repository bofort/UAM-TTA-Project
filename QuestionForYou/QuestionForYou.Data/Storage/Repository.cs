using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using QuestionForYou.Data.Model;

namespace QuestionForYou.Data.Storage
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly Func<QuestionForYouContext> _contextFactory;

        public Repository(Func<QuestionForYouContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public T FindById(int id, params Expression<Func<T, object>>[] includes)
        {
            List<string> includelist = GetIncludesList(includes);

            using (var context = _contextFactory())
            {
                DbQuery<T> entity = context.Set<T>();

                includelist.ForEach(x => entity = entity.Include(x));

                return entity.FirstOrDefault(x => x.Id == id);
            }
        }

        public IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includes)
        {
            List<string> includelist = GetIncludesList(includes);

            using (var context = _contextFactory())
            {
                DbQuery<T> entity = context.Set<T>();

                includelist.ForEach(x => entity = entity.Include(x));

                return entity.AsEnumerable().ToList();

            }
        }

        public T Persist(T item)
        {
            using (var context = _contextFactory())
            {
                if (!item.Id.HasValue)
                {
                    context.Set<T>().Add(item);
                }
                else
                {
                    var original = context.Set<T>().Single(x => x.Id == item.Id);
                    context.Entry(original).CurrentValues.SetValues(item);
                }
                context.SaveChanges();
            }
            return FindById(item.Id.Value);
        }

        public void Remove(T item)
        {
            using (var context = _contextFactory())
            {
                context.Set<T>().Remove(context.Set<T>().Single(x => x.Id == item.Id));
                context.SaveChanges();
            }
        }

        private List<string> GetIncludesList(params Expression<Func<T, object>>[] includes)
        {
            var includelist = new List<string>();
            foreach (var body in includes.Select(item => item.Body as MemberExpression))
            {
                if (body == null)
                    throw new ArgumentException("The body must be a member expression");

                includelist.Add(body.Member.Name);
            }
            return includelist;
        } 

    }
}
