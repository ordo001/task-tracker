using System;
using System.Collections.Generic;

namespace task_trackerVS.Models;

public partial class Card
{
    public int IdCard { get; set; }

    public string Heading { get; set; } = null!;

    public int Content { get; set; }

    public int IdUser { get; set; }

    public int IdSection { get; set; }

    public virtual Section IdSectionNavigation { get; set; } = null!;
}
