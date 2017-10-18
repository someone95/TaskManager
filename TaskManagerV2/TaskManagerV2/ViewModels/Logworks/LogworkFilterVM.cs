using Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using TaskManagerV2.Annotations;
using TaskManagerV2.ViewModels.Shared;

namespace TaskManagerV2.ViewModels.Logworks
{
    public class LogworkFilterVM : GenericFilterVM<Logwork>
    {
        [SkipFilter]
        public int Id { get; set; }
        public int LogworkHours { get; set; }
        public override System.Linq.Expressions.Expression<Func<Logwork, bool>> BuildFilter()
        {
            return (l =>
          (LogworkHours == 0 || l.LoggedHours == LogworkHours) &&
          l.ParentTaskId == Id
               );
        }
    }
}