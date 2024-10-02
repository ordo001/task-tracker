using System;
using System.Collections.Generic;

namespace task_trackerVS.Models;

public partial class Card
{
    public int IdCard { get; set; }

    public string NameCard { get; set; } = null!;

    public string Heading { get; set; } = null!;

    public string Content { get; set; } = null!;

    public int? IdUser { get; set; }

    public int IdSection { get; set; }

    public int CardLocationY { get; set; }

    public virtual Section IdSectionNavigation { get; set; } = null!;

    public virtual User? IdUserNavigation { get; set; }
}
