using System;
using System.Collections.Generic;

namespace task_trackerVS.Models
{
    public partial class Section
    {
        public int IdSection { get; set; }
        public int IdWorkSpace { get; set; }
        public string NameSection { get; set; } = null!;
        public string HeadingSection { get; set; } = null!;
        public int SectionLocationX { get; set; }
        public int SectionLocationY { get; set; }

        public virtual WorkSpace IdWorkSpaceNavigation { get; set; } = null!;
    }
}
