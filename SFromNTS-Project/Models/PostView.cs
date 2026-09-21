using System;
using System.Collections.Generic;

namespace SFromNTS_Project.Models;

public partial class PostView
{
    public Guid PostId { get; set; }

    public int? ViewCount { get; set; }

    public virtual PostedDocument Post { get; set; } = null!;
}
