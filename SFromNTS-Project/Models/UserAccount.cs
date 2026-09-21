using System;
using System.Collections.Generic;

namespace SFromNTS_Project.Models;

public partial class UserAccount
{
    public Guid UserId { get; set; }

    public string AccountName { get; set; } = null!;

    public string HashedPassword { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime? CreateDate { get; set; }

    public bool? AccountStatus { get; set; }

    public virtual UserInformation? UserInformation { get; set; }
}
