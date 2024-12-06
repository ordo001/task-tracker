﻿using System;
using System.Collections.Generic;

namespace task_trackerVS.Models;

public partial class User
{
    public int IdUser { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<Card> Cards { get; set; } = new List<Card>();
}
