using Common.Entities;
using DatabaseAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManagerV2.Annotations;

namespace TaskManagerV2.ViewModels.Shared
{
    public class FilterVM : BaseListVM
    {
        [SkipFilter]
        public string Prefix { get; set; }
    }
}