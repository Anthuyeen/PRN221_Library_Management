using System;
using System.Collections.Generic;

namespace Project_Library_Management_FA23_BL5.Models;

public partial class ReturnBook
{
    public int ReturnId { get; set; }

    public int CardNumber { get; set; }

    public int LibrarianId { get; set; }

    public DateTime ReturnDate { get; set; }

    public virtual Reader CardNumberNavigation { get; set; } = null!;

    public virtual Librarian Librarian { get; set; } = null!;

    public virtual ICollection<ReturnBookDetail> ReturnBookDetails { get; set; } = new List<ReturnBookDetail>();
}
