using Common.Entities;
using DatabaseAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManagerV2.Annotations;

namespace TaskManagerV2.ViewModels.Shared
{
    public class BaseListVM

    {
        [SkipFilter]
        public List<User> Users { get; set; }
        [SkipFilter]
        public List<Task> Tasks { get; set; }
        [SkipFilter]
        public List<Comment> Comments { get; set; }
        [SkipFilter]
        public List<Logwork> Logworks { get; set; }
        public BaseListVM()
        {
            Users = new UsersRepository().GetAll();
            Tasks = new TasksRepository().GetAll();
            Comments = new CommentsRepository().GetAll();
            Logworks = new LogworksRepository().GetAll();
        }
    }
}