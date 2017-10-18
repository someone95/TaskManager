using Common.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TaskManagerV2.ViewModels.BaseViewModels;

namespace TaskManagerV2.ViewModels.Tasks
{
    public class SaveTaskVM : BaseVM
    {
        public int ParentUserId { get; set; }
        public string Title { get; set; }
        public string TaskContent { get; set; }
        public int AssignedUserId { get; set; }
        public int LoggedHours { get; set; }
        [Required]
        public DateTime? DateCreation { get; set; }
        [Required]
        public DateTime? DateLastEdit { get; set; }
        public List<User> Users { get; set; }
    }
}