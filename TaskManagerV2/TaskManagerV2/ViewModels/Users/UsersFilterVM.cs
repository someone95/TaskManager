using Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManagerV2.ViewModels.Shared;
using System.Linq.Expressions;
using TaskManagerV2.Annotations;

namespace TaskManagerV2.ViewModels.Users
{
    public class UsersFilterVM : GenericFilterVM<User>
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public override Expression<Func<User, bool>> BuildFilter()
        {
            return (u =>
                (string.IsNullOrEmpty(Username) || u.Username.Contains(Username)) &&
                (string.IsNullOrEmpty(FirstName) || u.FirstName.Contains(FirstName)) &&
                (string.IsNullOrEmpty(LastName) || u.LastName.Contains(LastName))
                );
        }
    }
}