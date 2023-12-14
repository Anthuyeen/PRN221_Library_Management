using System;
using System.Collections.Generic;

namespace Project_Library_Management_FA23_BL5.Models;

public partial class Librarian
{
    public int LibrarianId { get; set; }

    public string LibrarianName { get; set; } = null!;

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();

    public virtual ICollection<LendBookDetail> LendBookDetails { get; set; } = new List<LendBookDetail>();

    public virtual ICollection<ReturnBook> ReturnBooks { get; set; } = new List<ReturnBook>();
}
