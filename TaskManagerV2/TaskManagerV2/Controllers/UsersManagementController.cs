using Common.Entities;
using DatabaseAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManagerV2.ViewModels.Shared;
using TaskManagerV2.ViewModels.Users;
using TaskManagerV2.Annotations;

namespace TaskManagerV2.Controllers
{
    [AdministrationAnnotation]
    public class UsersManagementController : BaseController<User, UsersRepository, SaveUserVM, IndexUserVM, UsersFilterVM>
    {
        public override void PopulateItem(SaveUserVM model, User item)
        {
            model.Username = item.Username;
            model.Password = item.Password;
            model.FirstName = item.FirstName;
            model.LastName = item.LastName;
            model.IsAdmin = item.IsAdmin;
        }

        public override void PopulateViewModel(User item, SaveUserVM model)
        {
            item.Username = model.Username;
            item.Password = model.Password;
            item.FirstName = model.FirstName;
            item.LastName = model.LastName;
            item.IsAdmin = model.IsAdmin;
        }
    }
}