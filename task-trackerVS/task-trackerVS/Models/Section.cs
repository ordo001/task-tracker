using System;
using System.Collections.Generic;

namespace task_trackerVS.Models;

public partial class Section
{
    public int IdSection { get; set; }

    public string NameSection { get; set; } = null!;

    public string HeadingSection { get; set; } = null!;

    public int SectionLocationY { get; set; }

    public int SectionLocationX { get; set; }

    public virtual ICollection<Card> Cards { get; set; } = new List<Card>();
}
