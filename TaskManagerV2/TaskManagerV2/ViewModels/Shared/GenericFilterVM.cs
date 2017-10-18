using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using TaskManagerV2.Annotations;

namespace TaskManagerV2.ViewModels.Shared
{
    public abstract class GenericFilterVM<T> : FilterVM
    {
        public abstract Expression<Func<T, bool>> BuildFilter();
    }
}