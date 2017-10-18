using Common.Entities;
using DatabaseAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManagerV2.Annotations;
using TaskManagerV2.ViewModels.BaseViewModels;
using TaskManagerV2.ViewModels.Shared;

namespace TaskManagerV2.Controllers
{
    [AuthenticationAnnotation]
    public abstract class BaseController<TEntity, TRepository, SaveVM, IndexVM, FilterVM> : Controller
        where TEntity : BaseEntity, new()
        where TRepository : BaseRepository<TEntity>, new()
        where SaveVM : BaseVM, new()
        where IndexVM : BaseIndexVM<TEntity, FilterVM>, new()
        where FilterVM : GenericFilterVM<TEntity>, new()
    {
        TRepository baseRepo;
        public BaseController()
        {
            baseRepo = new TRepository();
        }
        public abstract void PopulateItem(SaveVM model, TEntity item);
        public abstract void PopulateViewModel(TEntity item, SaveVM model);
        public virtual void AddItemToIndexVM(IndexVM model) { }
        public virtual void AddItemToSaveVM(SaveVM model) { }
        // GET: Base
        public ActionResult Index(IndexVM model)
        {
            model.Pager = model.Pager ?? new PagerVM();
            model.Filter = model.Filter ?? new FilterVM();
            model.Pager.Prefix = "Pager";
            model.Filter.Prefix = "Filter";
            var filter = model.Filter.BuildFilter();
            model.Pager.ItemsPerPage = model.Pager.ItemsPerPage == 0 ? 5 : model.Pager.ItemsPerPage;
            model.Pager.PageCount = (int)Math.Ceiling(baseRepo.Count(filter) / (decimal)model.Pager.ItemsPerPage);
            model.Pager.PageCount = model.Pager.PageCount == 0 ? 1 : model.Pager.PageCount;
            model.Items = baseRepo.GetAll(filter, model.Pager.CurrentPage, model.Pager.ItemsPerPage);
            AddItemToIndexVM(model);
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            SaveVM model = new SaveVM();
            TEntity item = null;
            if (id == null)
                item = new TEntity();
            else
                item = baseRepo.GetById(id.Value);
            PopulateItem(model, item);
            model.Id = item.Id;
            AddItemToSaveVM(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(SaveVM model)
        {
            TEntity item = null;
            if (model.Id <= 0)
                item = new TEntity();
            else
                item = baseRepo.GetById(model.Id);
            PopulateViewModel(item, model);
            AddItemToSaveVM(model);
            if (!ModelState.IsValid)
                return View(model);

            baseRepo.Save(item);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            SaveVM model = new SaveVM();
            TEntity item = baseRepo.GetById(id);
            if (item == null)
            {
                return RedirectToAction("Index");
            }
            PopulateItem(model, item);
            AddItemToSaveVM(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(SaveVM model)
        {
            AddItemToSaveVM(model);
            TEntity item = baseRepo.GetById(model.Id);
            baseRepo.Delete(item);
            return RedirectToAction("Index");
        }
    }
}