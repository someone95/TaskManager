using Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManagerV2.ViewModels.BaseViewModels;

namespace TaskManagerV2.ViewModels.Tasks
{
    public class IndexTaskVM : BaseIndexVM<Task, TasksFilterVM>
    {
        public List<User> Users { get; set; }
    }
}