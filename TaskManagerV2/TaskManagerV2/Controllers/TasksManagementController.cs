using Common.Entities;
using DatabaseAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManagerV2.Models;
using TaskManagerV2.ViewModels.Comments;
using TaskManagerV2.ViewModels.Logworks;
using TaskManagerV2.ViewModels.Shared;
using TaskManagerV2.ViewModels.Tasks;

namespace TaskManagerV2.Controllers
{
    public class TasksManagementController : BaseController<Task, TasksRepository, SaveTaskVM, IndexTaskVM, TasksFilterVM>
    {
        public override void AddItemToIndexVM(IndexTaskVM model)
        {
            UsersRepository usersRepo = new UsersRepository();
            model.Users = usersRepo.GetAll();
        }
        public override void AddItemToSaveVM(SaveTaskVM model)
        {
            UsersRepository usersRepo = new UsersRepository();
            model.Users = usersRepo.GetAll();
        }
        public override void PopulateItem(SaveTaskVM model, Task item)
        {
            model.ParentUserId = AuthenticationManager.LoggedUser.Id;
            model.Title = item.Title;
            model.TaskContent = item.TaskContent;
            model.LoggedHours = item.LoggedHours;
            model.AssignedUserId = item.AssignedUserId;
            model.DateCreation = item.DateCreation;
            model.DateLastEdit = item.DateLastEdit;
        }

        public override void PopulateViewModel(Task item, SaveTaskVM model)
        {
            item.ParentUserId = AuthenticationManager.LoggedUser.Id;
            item.Title = model.Title;
            item.TaskContent = model.TaskContent;
            item.LoggedHours = model.LoggedHours;
            item.AssignedUserId = model.AssignedUserId;
            item.DateCreation = model.DateCreation;
            item.DateLastEdit = model.DateLastEdit;
        }
        [HttpGet]
        public ActionResult Details(TaskDetailsVM model)
        {
            
            TasksRepository tasksRepository = new TasksRepository();
            model.Item = tasksRepository.GetById(model.Id);
            if (model == null)
                return RedirectToAction("Index", "Tasks");

            UsersRepository usersRepository = new UsersRepository();
            model.Users = usersRepository.GetAll();
            CommentsRepository commentsRepo = new CommentsRepository();
            LogworksRepository logworkRepo = new LogworksRepository();
            model.CommentsPager = model.CommentsPager ?? new PagerVM();
            model.CommentsFilter = model.CommentsFilter ?? new CommentsFilterVM();
            model.CommentsFilter.Id = model.Id;
            var filter = model.CommentsFilter.BuildFilter();
            model.CommentsPager.Prefix = "CommentsPager";
            model.CommentsFilter.Prefix = "CommentsFilter";
            model.CommentsPager.ItemsPerPage = model.CommentsPager.ItemsPerPage == 0 ? 5 : model.CommentsPager.ItemsPerPage;
            model.CommentsPager.PageCount = (int)Math.Ceiling(commentsRepo.Count(filter) / (decimal)model.CommentsPager.ItemsPerPage);
            model.CommentsPager.PageCount = model.CommentsPager.PageCount == 0 ? 1 : model.CommentsPager.PageCount;
            model.Comments = commentsRepo.GetAll(filter, model.CommentsPager.CurrentPage, model.CommentsPager.ItemsPerPage);

            model.LogworksPager = model.LogworksPager ?? new PagerVM();
            model.LogworkFilter = model.LogworkFilter ?? new LogworkFilterVM();
            model.LogworkFilter.Id = model.Id;
            var logworkFilter = model.LogworkFilter.BuildFilter();
            model.LogworksPager.Prefix = "LogworksPager";
            model.LogworkFilter.Prefix = "LogworkFilter";
            model.LogworksPager.ItemsPerPage = model.LogworksPager.ItemsPerPage == 0 ? 5 : model.LogworksPager.ItemsPerPage;
            model.LogworksPager.PageCount = (int)Math.Ceiling(logworkRepo.Count(logworkFilter) / (decimal)model.LogworksPager.ItemsPerPage);
            model.LogworksPager.PageCount = model.LogworksPager.PageCount == 0 ? 1 : model.LogworksPager.PageCount;
            model.Logworks = logworkRepo.GetAll(logworkFilter, model.LogworksPager.CurrentPage, model.LogworksPager.ItemsPerPage);

            return View(model);
        }
    }
}