﻿using System;
using System.Collections.Generic;

namespace Project_Library_Management_FA23_BL5.Models;

public partial class LendBookDetail
{
    public int LendBookDetailId { get; set; }

    public int CardNumber { get; set; }

    public int LibrarianId { get; set; }

    public DateTime LendDate { get; set; }

    public DateTime ExpectedReturnDate { get; set; }

    public int? ReturnCondition { get; set; }

    public virtual Reader CardNumberNavigation { get; set; } = null!;

    public virtual Librarian Librarian { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();

    
   
}
