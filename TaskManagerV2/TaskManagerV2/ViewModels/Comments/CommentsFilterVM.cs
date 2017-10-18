using Common.Entities;
using DatabaseAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using TaskManagerV2.Annotations;
using TaskManagerV2.ViewModels.Shared;

namespace TaskManagerV2.ViewModels.Comments
{
    public class CommentsFilterVM : GenericFilterVM<Comment>
    {
        [SkipFilter]
        public int Id { get; set; }
        [UsersDropdown]
        public int AssignedUserId { get; set; }
        public string CommentContent { get; set; }
        public override Expression<Func<Comment, bool>> BuildFilter()
        {
            return (c =>
           (string.IsNullOrEmpty(CommentContent) || c.CommentContent.Contains(CommentContent)) &&
           c.ParentTaskId == Id &&
           (c.AssignedUserId == AssignedUserId || AssignedUserId == 0)
                );
        }
    }
}