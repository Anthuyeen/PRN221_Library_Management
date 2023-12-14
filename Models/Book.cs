using System;
using System.Collections.Generic;

namespace Project_Library_Management_FA23_BL5.Models;

public partial class Book
{
    public int BookId { get; set; }

    public int TitleId { get; set; }

    public int Condition { get; set; }

    public virtual ICollection<ReturnBookDetail> ReturnBookDetails { get; set; } = new List<ReturnBookDetail>();

    public virtual BookInfo Title { get; set; } = null!;

    public virtual ICollection<LendBookDetail> LendBookDetails { get; set; } = new List<LendBookDetail>();
}
