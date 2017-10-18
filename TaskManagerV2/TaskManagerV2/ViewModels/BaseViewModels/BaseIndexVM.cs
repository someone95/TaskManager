using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManagerV2.ViewModels.Shared;

namespace TaskManagerV2.ViewModels.BaseViewModels
{
    public class BaseIndexVM<TEntity, FilterVM>
    {
        public List<TEntity> Items { get; set; }
        public PagerVM Pager { get; set; }
        public FilterVM Filter { get; set; }
    }
}