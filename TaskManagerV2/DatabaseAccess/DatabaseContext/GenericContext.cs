using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.DatabaseContext
{
    internal class GenericContext<T> : DbContext
        where T : class
    {
        internal DbSet<T> Items { get; set; }

        internal GenericContext()
            : base("TaskManagerContext")
        {
            Items = this.Set<T>();
        }
    }

}
