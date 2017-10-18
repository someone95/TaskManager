using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManagerV2.ViewModels.Shared
{
    public class PagerVM
    {
        public string Prefix { get; set; }
        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }
        public int PageCount { get; set; }
    }
}