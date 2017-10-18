using Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManagerV2.ViewModels.Comments;
using TaskManagerV2.ViewModels.Logworks;
using TaskManagerV2.ViewModels.Shared;

namespace TaskManagerV2.ViewModels.Tasks
{
    public class TaskDetailsVM
    {
        public int Id { get; set; }
        public Task Item { get; set; }
        public List<Comment> Comments { get; set; }
        public PagerVM CommentsPager { get; set; }
        public CommentsFilterVM CommentsFilter { get; set; }
        public List<Logwork> Logworks { get; set; }
        public LogworkFilterVM LogworkFilter { get; set; }
        public PagerVM LogworksPager { get; set; }
        public List<User> Users { get; set; }
    }
}