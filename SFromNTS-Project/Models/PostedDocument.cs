using System;
using System.Collections.Generic;

namespace SFromNTS_Project.Models;

public partial class PostedDocument
{
    public Guid PostId { get; set; }

    public string DocumentTitle { get; set; } = null!;

    public string DocumentType { get; set; } = null!;

    public string? DocumentDescribe { get; set; }

    public int? DocumentSize { get; set; }

    public DateTime? PostDate { get; set; }

    public bool? DocStatus { get; set; }

    public Guid? UserId { get; set; }

    public virtual ICollection<PostComment> PostComments { get; set; } = new List<PostComment>();

    public virtual PostView? PostView { get; set; }

    public virtual UserInformation? User { get; set; }

    public virtual ICollection<UserInformation> Users { get; set; } = new List<UserInformation>();
}
