using System;
using System.Collections.Generic;

namespace task_trackerVS.Models
{
    public partial class User
    {
        public User()
        {
            //WorkSpaces = new HashSet<WorkSpace>();
        }

        public int IdUser { get; set; }
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Role { get; set; } = null!;
        public string Name { get; set; } = null!;

        //public virtual ICollection<WorkSpace> WorkSpaces { get; set; }
        public virtual List<WorkSpace> WorkSpaces { get; set; }
    }
}
