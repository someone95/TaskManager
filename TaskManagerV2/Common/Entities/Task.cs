using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public class Task : BaseEntity
    {
        public int ParentUserId { get; set; }
        public string Title { get; set; }
        public string TaskContent { get; set; }
        public int AssignedUserId { get; set; }
        public int LoggedHours { get; set; }
        public DateTime? DateCreation { get; set; }
        public DateTime? DateLastEdit { get; set; }
    }
}
