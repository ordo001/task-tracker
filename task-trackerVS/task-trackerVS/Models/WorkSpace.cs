using System;
using System.Collections.Generic;

namespace task_trackerVS.Models
{
    public partial class WorkSpace
    {
        public WorkSpace()
        {
            Sections = new HashSet<Section>();
            Users = new HashSet<User>();
        }

        public int IdWorkSpace { get; set; }
        public string WorkSpaceName { get; set; } = null!;

        public virtual ICollection<Section> Sections { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
