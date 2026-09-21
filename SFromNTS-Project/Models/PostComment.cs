using System;
using System.Collections.Generic;

namespace SFromNTS_Project.Models;

public partial class PostComment
{
    public Guid CommentId { get; set; }

    public string Content { get; set; } = null!;

    public DateTime? CommentDate { get; set; }

    public bool? CommentStatus { get; set; }

    public Guid? UserId { get; set; }

    public Guid? PostId { get; set; }

    public Guid? ParentCommentId { get; set; }

    public virtual ICollection<PostComment> InverseParentComment { get; set; } = new List<PostComment>();

    public virtual PostComment? ParentComment { get; set; }

    public virtual PostedDocument? Post { get; set; }

    public virtual UserInformation? User { get; set; }
}
