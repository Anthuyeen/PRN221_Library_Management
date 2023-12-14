using System;
using System.Collections.Generic;

namespace Project_Library_Management_FA23_BL5.Models;

public partial class BookInfo
{
    public int TitleId { get; set; }

    public string Title { get; set; } = null!;

    public int InStock { get; set; }

    public int NumberOfPages { get; set; }

    public int? Frequency { get; set; }

    public int PublisherId { get; set; }

    public virtual ICollection<AuthorBook> AuthorBooks { get; set; } = new List<AuthorBook>();

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();

    public virtual Publisher Publisher { get; set; } = null!;
}
