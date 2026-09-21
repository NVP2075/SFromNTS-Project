using System;
using System.Collections.Generic;

namespace SFromNTS_Project.Models;

public partial class UserInformation
{
    public Guid UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string UserSurname { get; set; } = null!;

    public DateTime? DateOfBirth { get; set; }

    public string? Occupation { get; set; }

    public virtual ICollection<PostComment> PostComments { get; set; } = new List<PostComment>();

    public virtual ICollection<PostedDocument> PostedDocuments { get; set; } = new List<PostedDocument>();

    public virtual UserAccount User { get; set; } = null!;

    public virtual ICollection<PostedDocument> Posts { get; set; } = new List<PostedDocument>();
}
