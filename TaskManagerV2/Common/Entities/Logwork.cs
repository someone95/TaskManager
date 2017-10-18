using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public class Logwork : BaseEntity
    {
        public int ParentTaskId { get; set; }
        public int LoggedHours { get; set; }
    }
}
