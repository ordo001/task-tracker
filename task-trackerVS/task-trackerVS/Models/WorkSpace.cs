using System;
using System.Collections.Generic;

namespace task_trackerVS.Models
{
    public partial class WorkSpace
    {
        public WorkSpace()
        {
            Sections = new HashSet<Section>();
            //Users = new HashSet<User>();
        }

        public int IdWorkSpace { get; set; }
        public string WorkSpaceName { get; set; } = null!;
        public byte[]? Image { get; set; }

        public virtual ICollection<Section> Sections { get; set; }

        public virtual List<User> Users { get; set; } = new List<User>();
    }
}
