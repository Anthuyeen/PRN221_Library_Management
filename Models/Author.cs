using System;
using System.Collections.Generic;

namespace Project_Library_Management_FA23_BL5.Models;

public partial class Author
{
    public int AuthorId { get; set; }

    public string AuthorName { get; set; } = null!;

    public virtual ICollection<AuthorBook> AuthorBooks { get; set; } = new List<AuthorBook>();
}
