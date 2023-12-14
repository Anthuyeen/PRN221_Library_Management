using System;
using System.Collections.Generic;

namespace Project_Library_Management_FA23_BL5.Models;

public partial class Reader
{
    public int CardNumber { get; set; }

    public string FullName { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public DateTime CardCreationDate { get; set; }

    public string Address { get; set; } = null!;

    public string Occupation { get; set; } = null!;

    public virtual ICollection<LendBookDetail> LendBookDetails { get; set; } = new List<LendBookDetail>();

    public virtual ICollection<ReturnBook> ReturnBooks { get; set; } = new List<ReturnBook>();
}
