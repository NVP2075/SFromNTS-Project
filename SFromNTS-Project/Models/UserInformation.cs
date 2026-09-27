using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SFromNTS_Project.Models;

public partial class UserInformation
{
    public Guid UserId { get; set; }
    [Required]
    public string UserName { get; set; } = null!;
    [Required]
    public string UserSurname { get; set; } = null!;
    [Required]
    public DateTime? DateOfBirth { get; set; }
    [Required]
    public string? Occupation { get; set; }

    public virtual ICollection<PostComment> PostComments { get; set; } = new List<PostComment>();

    public virtual ICollection<PostedDocument> PostedDocuments { get; set; } = new List<PostedDocument>();

    public virtual UserAccount User { get; set; } = null!;

    public virtual ICollection<PostedDocument> Posts { get; set; } = new List<PostedDocument>();
}
