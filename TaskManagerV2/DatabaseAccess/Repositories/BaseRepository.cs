using Common.Entities;
using DatabaseAccess.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Repositories
{
    public class BaseRepository<T>
        where T : BaseEntity, new()
    {
        private GenericContext<T> Context { get; set; }
        protected DbSet<T> Items { get; set; }

        public BaseRepository()
        {
            Context = new GenericContext<T>();
            Items = this.Context.Set<T>();
        }
        public List<T> GetAll(Expression<Func<T, bool>> filter = null, int? page = null, int? pageSize = null)
        {
            IQueryable<T> result = Items;
            if (filter != null)
                result = result.Where(filter);

            if (page != null && pageSize != null)
                result = result.OrderBy(i => i.Id).Skip(page.Value * pageSize.Value).Take(pageSize.Value);

            return result.ToList();
        }
        public int Count(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> result = Items;
            if (filter != null)
                result = result.Where(filter);

            return result.Count();
        }
        public void Save(T item)
        {
            if (item.Id <= 0)
                Items.Add(item);
            else
                Context.Entry(item).State = EntityState.Modified;

            Context.SaveChanges();
        }
        public void Delete(T item)
        {
            Context.Entry(item).State = EntityState.Deleted;
            Items.Remove(item);
            Context.SaveChanges();
        }
        public T GetById(int id)
        {
            T item = Items.Find(id);
            return item;
        }
    }
}
