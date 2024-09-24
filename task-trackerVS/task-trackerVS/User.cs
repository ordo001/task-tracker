using System;
using System.Collections.Generic;

namespace task_trackerVS;

public partial class User
{
    public int IdUser { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int Access { get; set; }
}
