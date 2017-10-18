using Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManagerV2.ViewModels.Shared;
using System.Linq.Expressions;
using TaskManagerV2.Models;

namespace TaskManagerV2.ViewModels.Tasks
{
    public class TasksFilterVM : GenericFilterVM<Task>
    {
        public string Title { get; set; }
        public string TaskContent { get; set; }
        public float LoggedHours { get; set; }

        public override Expression<Func<Task, bool>> BuildFilter()
        {
            return (t =>
            (string.IsNullOrEmpty(Title) || t.Title.Contains(Title)) &&
            (string.IsNullOrEmpty(TaskContent) || t.TaskContent.Contains(TaskContent)) &&
            (LoggedHours == 0 || t.LoggedHours == LoggedHours) &&
            (t.AssignedUserId == AuthenticationManager.LoggedUser.Id || t.ParentUserId == AuthenticationManager.LoggedUser.Id)
            );
        }
    }
}