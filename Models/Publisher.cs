using System;
using System.Collections.Generic;

namespace Project_Library_Management_FA23_BL5.Models;

public partial class Publisher
{
    public int PublisherId { get; set; }

    public string PublisherName { get; set; } = null!;

    public virtual ICollection<BookInfo> BookInfos { get; set; } = new List<BookInfo>();
}
