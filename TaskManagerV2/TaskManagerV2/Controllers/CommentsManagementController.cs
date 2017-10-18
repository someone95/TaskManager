using Common.Entities;
using DatabaseAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManagerV2.Annotations;
using TaskManagerV2.ViewModels.BaseViewModels;
using TaskManagerV2.ViewModels.Comments;

namespace TaskManagerV2.Controllers
{
    public class CommentsManagementController : Controller
    {
        private CommentsRepository commentsRepo;
        public CommentsManagementController()
        {
            commentsRepo = new CommentsRepository();
        }

        public void PopulateItem(SaveCommentVM model, Comment item)
        {
            model.AssignedUserId = item.AssignedUserId;
            model.CommentContent = item.CommentContent;
            model.ParentTaskId = item.ParentTaskId;
        }

        public void PopulateViewModel(Comment item, SaveCommentVM model)
        {
            item.AssignedUserId = model.AssignedUserId;
            item.CommentContent = model.CommentContent;
            item.ParentTaskId = model.ParentTaskId;
        }

        [HttpGet]
        public ActionResult Edit(int? id, int parentTaskId)
        {
            UsersRepository usersRepo = new UsersRepository();
            SaveCommentVM model = new SaveCommentVM();
            Comment item = null;
            if (id == null)
                item = new Comment();
            else
                item = commentsRepo.GetById(id.Value);
            PopulateItem(model, item);
            model.Users = usersRepo.GetAll();
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(SaveCommentVM model)
        {
            UsersRepository usersRepo = new UsersRepository();
            Comment item = null;
            if (model.Id <= 0)
                item = new Comment();
            else
                item = commentsRepo.GetById(model.Id);

            PopulateViewModel(item, model);
            model.Users = usersRepo.GetAll();
            if (!ModelState.IsValid)
                return View(model);

            commentsRepo.Save(item);
            return RedirectToAction("Details", "TasksManagement", new { id = model.ParentTaskId });
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            SaveCommentVM model = new SaveCommentVM();
            Comment item = commentsRepo.GetById(id);
            if (model == null)
                return RedirectToAction("Details", "TasksManagement", new { id = model.ParentTaskId });
            PopulateItem(model, item);
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(SaveCommentVM model)
        {
            Comment item = commentsRepo.GetById(model.Id);
            commentsRepo.Delete(item);
            return RedirectToAction("Details", "TasksManagement", new { id = model.ParentTaskId });
        }
    }
}