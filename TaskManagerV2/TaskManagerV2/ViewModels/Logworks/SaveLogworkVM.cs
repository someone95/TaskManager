using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManagerV2.ViewModels.BaseViewModels;

namespace TaskManagerV2.ViewModels.Logworks
{
    public class SaveLogworkVM : BaseVM
    {
        public int ParentTaskId { get; set; }
        public int LoggedHours { get; set; }
    }
}