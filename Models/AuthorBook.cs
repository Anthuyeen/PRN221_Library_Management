using System;
using System.Collections.Generic;

namespace Project_Library_Management_FA23_BL5.Models;

public partial class AuthorBook
{
    public int AuthorId { get; set; }

    public int TitleId { get; set; }

    public string AuthorRole { get; set; } = null!;

    public virtual Author Author { get; set; } = null!;

    public virtual BookInfo Title { get; set; } = null!;
}
