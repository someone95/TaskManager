using Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManagerV2.ViewModels.BaseViewModels;

namespace TaskManagerV2.ViewModels.Comments
{
    public class SaveCommentVM : BaseVM
    {
        public int AssignedUserId { get; set; }
        public int ParentTaskId { get; set; }
        public string CommentContent { get; set; }
        public List<User> Users { get; set; }
    }
}