using Common.Entities;
using DatabaseAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManagerV2.ViewModels.BaseViewModels;
using TaskManagerV2.ViewModels.Logworks;

namespace TaskManagerV2.Controllers
{
    public class LogworksManagementController : Controller
    {
        private LogworksRepository logworkRepo;
        public LogworksManagementController()
        {
            logworkRepo = new LogworksRepository();
        }

        public void PopulateItem(SaveLogworkVM model, Logwork item)
        {
            model.LoggedHours = item.LoggedHours;
            model.ParentTaskId = item.ParentTaskId;
        }

        public void PopulateViewModel(Logwork item, SaveLogworkVM model)
        {
            item.LoggedHours = model.LoggedHours;
            item.ParentTaskId = model.ParentTaskId;
        }

        [HttpGet]
        public ActionResult Edit(int? id, int parentTaskId)
        {
            SaveLogworkVM model = new SaveLogworkVM();
            Logwork item = null;
            if (id == null)
                item = new Logwork();
            else
                item = logworkRepo.GetById(id.Value);
            PopulateItem(model, item);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(SaveLogworkVM model)
        {
            Logwork item = null;
            if (model.Id <= 0)
                item = new Logwork();
            else
                item = logworkRepo.GetById(model.Id);

            PopulateViewModel(item, model);
            if (!ModelState.IsValid)
                return View(model);

            logworkRepo.Save(item);
            return RedirectToAction("Details", "TasksManagement", new { id = model.ParentTaskId });
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            SaveLogworkVM model = new SaveLogworkVM();
            Logwork item = logworkRepo.GetById(id);
            if (model == null)
                return RedirectToAction("Details", "TasksManagement", new { id = model.ParentTaskId });
            PopulateItem(model, item);
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(SaveLogworkVM model)
        {
            Logwork item = logworkRepo.GetById(model.Id);
            logworkRepo.Delete(item);
            return RedirectToAction("Details", "TasksManagement", new { id = model.ParentTaskId });
        }

    }
}